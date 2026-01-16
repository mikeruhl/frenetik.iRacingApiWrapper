using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Enums;
using Frenetik.iRacingApiWrapper.Extensions;
using Frenetik.iRacingApiWrapper.Models;
using Frenetik.iRacingApiWrapper.Service;
using Frenetik.iRacingApiWrapper.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using System.Globalization;
using System.Text.Json;
using System.Net.Http.Json;

namespace Frenetik.iRacingApiWrapper;

/// <summary>
/// iRacing API Wrapper
/// </summary>
public class IRacingApiService : IIRacingApiService
{
    private readonly IRacingDataSettings _settings;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<IRacingApiService> _logger;
    private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;
    private readonly string _httpClientName;

    private const string Iso8601DateFormat = "yyyy-MM-ddTHH:mmZ";

    /// <summary>
    /// HTTP client name for all iRacing API requests
    /// </summary>
    public const string HttpClientName = "IRacing";

    /// <summary>
    /// Constructor for IRacingApiService
    /// </summary>
    /// <param name="httpClientFactory">HTTP client factory for creating clients per request</param>
    /// <param name="settings">iRacing API settings (optional - defaults to standard configuration if not provided)</param>
    /// <param name="logger">Logger instance</param>
    /// <param name="httpClientName">Optional HTTP client name (defaults to "IRacing" for backwards compatibility)</param>
    public IRacingApiService(IHttpClientFactory httpClientFactory, IOptions<IRacingDataSettings> settings, ILogger<IRacingApiService> logger, string? httpClientName = null)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        ArgumentNullException.ThrowIfNull(logger);

        _settings = settings.Value;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _httpClientName = httpClientName ?? HttpClientName;
        _retryPolicy = RetryPolicyBuilder.BuildPolicy(_settings.RetryPolicy, _logger);
    }

    /// <inheritdoc />
    public Task<Dictionary<string, Dictionary<string, EndpointDetails>>> GetDoc() => GetResources<Dictionary<string, Dictionary<string, EndpointDetails>>>("/doc", false);

    /// <inheritdoc />
    public Task<IEnumerable<Constant>> GetConstantsCategories() => GetResources<IEnumerable<Constant>>("/constants/categories", false);

    /// <inheritdoc />
    public Task<IEnumerable<Constant>> GetConstantsDivisions() => GetResources<IEnumerable<Constant>>("/constants/divisions", false);

    /// <inheritdoc />
    public Task<IEnumerable<Constant>> GetConstantsEventTypes() => GetResources<IEnumerable<Constant>>("/constants/event_types", false);

    /// <inheritdoc />
    public async Task<IEnumerable<CarAsset>> GetCarAssets() => (await GetResources<Dictionary<string, CarAsset>>("/car/assets", true)).Values;

    /// <inheritdoc />
    public Task<IEnumerable<Car>> GetCars() => GetResources<IEnumerable<Car>>("/car/get", true);

    /// <inheritdoc />
    public Task<IEnumerable<CarClass>> GetCarClasses() => GetResources<IEnumerable<CarClass>>("/carclass/get", true);

    /// <inheritdoc />
    public Task<SessionResult> GetHostedCombinedSessions() => GetResources<SessionResult>("/hosted/combined_sessions", true);

    /// <inheritdoc />
    public Task<SessionResult> GetHostedCombinedSession(int packageId) => GetResources<SessionResult>("/hosted/combined_sessions", true, new Dictionary<string, string> { { "package_Id", packageId.ToString() } });

    /// <inheritdoc />
    public Task<SessionResult> GetHostedSessions() => GetResources<SessionResult>("/hosted/sessions", true);

    /// <inheritdoc />
    public Task<SessionResult> GetCustLeagueSessionResults(bool mine = false, int? packageId = null) => GetResources<SessionResult>("/league/cust_league_sessions", true, BuildParameters(["mine", "package_id"], [mine, packageId]));

    /// <inheritdoc />
    public Task<LeagueResult> SearchLeagues(string? search = null, string? tag = null, bool? restrictToMember = null, bool? restrictToRecruiting = null, bool? restrictToFriends = null, bool? restrictToWatched = null,
        bool? minimumRosterCount = null, bool? maximumRosterCount = null, int? lowerBound = null, int? upperBound = null, LeagueSortValue? sort = null, SortOrder? order = null) =>
        GetResources<LeagueResult>("/league/directory", true, BuildParameters(["search", "tag", "restrict_to_member", "restrict_to_recruiting", "restrict_to_friends", "restrict_to_watched", "minimum_roster_count", "maximum_roster_count", "lowerbound", "upperbound", "sort", "order"],
            [search, tag, restrictToMember, restrictToRecruiting, restrictToFriends, restrictToWatched, minimumRosterCount, maximumRosterCount, lowerBound, upperBound, sort?.GetEnumMemberValue(), order?.GetEnumMemberValue()]));

    /// <inheritdoc />
    public Task<LeagueDetailed> GetLeagueById(int leagueId, bool? includeLicenses = null) => GetResources<LeagueDetailed>($"/league/get", true, BuildParameters(["league_id", "include_licenses"], [leagueId, includeLicenses]));

    /// <inheritdoc />
    public Task<PointsSystemResponse> GetPointsSystems(int leagueId, int? seasonId = null) => GetResources<PointsSystemResponse>($"/league/get_points_systems", true, BuildParameters(["league_id", "season_id"], [leagueId, seasonId]));

    /// <inheritdoc />
    public Task<List<LeagueMembership>> GetLeagueMembership(int customerId, bool? includeLeague = null) => GetResources<List<LeagueMembership>>($"/league/membership", true, BuildParameters(["cust_id", "include_league"], [customerId, includeLeague]));

    /// <inheritdoc />
    public Task<LeagueSeasonResult> GetLeagueSeasons(int leagueId, bool? retired = null) => GetResources<LeagueSeasonResult>($"/league/seasons", true, BuildParameters(["league_id", "return"], [leagueId, retired]));

    /// <inheritdoc />
    public Task<LeagueSeasonStandingsResult> GetLeagueSeasonStandings(int leagueId, int seasonId, int? carClassId = null, int? carId = null) => GetResources<LeagueSeasonStandingsResult>($"/league/season_standings", true, BuildParameters(["league_id", "season_id", "car_class_id", "car_id"], [leagueId, seasonId, carClassId, carId]));

    /// <inheritdoc />
    public Task<LeagueSeasonSessionsResult> GetLeagueSeasonsSessions(int leagueId, int seasonId, bool? resultsOnly = null) => GetResources<LeagueSeasonSessionsResult>($"/league/season_sessions", true, BuildParameters(["league_id", "season_id", "results_only"], [leagueId, seasonId, resultsOnly]));

    /// <inheritdoc />
    public Task<List<Country>> LookupCountries() => GetResources<List<Country>>("/lookup/countries", true);

    /// <inheritdoc />
    public Task<List<Driver>> LookupDrivers(string searchTerm, int? leagueId = null) => GetResources<List<Driver>>("/lookup/drivers", true, BuildParameters(["search_term", "league_id"], [searchTerm, leagueId]));

    /// <inheritdoc />
    public Task<List<LookupResult>> Lookup(Dictionary<string, string[]> lookups) => GetResources<List<LookupResult>>("/lookup/get", true, lookups.SelectMany(kvp => kvp.Value.Select(v => new KeyValuePair<string, string>(kvp.Key, v))));

    /// <inheritdoc />
    public Task<List<LookupLicenseResult>> LookupLicenses() => GetResources<List<LookupLicenseResult>>("/lookup/licenses", true);

    /// <inheritdoc />
    public Task<List<MemberAward>> GetMemberAwards(int? customerId = null) => GetResources<List<MemberAward>>($"/member/awards", true, BuildParameters(["cust_id"], [customerId]));

    /// <inheritdoc />
    public Task<MemberChartData> GetMemberChartData(int categoryId, int chartType, int? customerId = null) => GetResources<MemberChartData>($"/member/chart_data", true, BuildParameters(["category_id", "chart_type", "cust_id"], [categoryId, chartType, customerId]));

    /// <inheritdoc />
    public Task<MembersResult> GetMember(IEnumerable<int> customerIds, bool includeLicenses) => GetResources<MembersResult>($"/member/get", true, BuildParameters(["cust_ids", "include_licenses"], [CreateCsv(customerIds), includeLicenses]));

    /// <inheritdoc />
    public Task<MemberInfo> GetMemberInfo() => GetResources<MemberInfo>("/member/info", true);

    /// <inheritdoc />
    public Task<List<MemberParticipationCredits>> GetMemberParticipationCredits() => GetResources<List<MemberParticipationCredits>>("member/participation_credits", true);

    /// <inheritdoc />
    public Task<MemberProfile> GetMemberProfile(int? customerId = null) => GetResources<MemberProfile>("/member/profile", true, BuildParameters(["cust_id"], [customerId]));

    /// <inheritdoc />
    public Task<SubSessionResults> GetResults(int subSessionId, bool? includeLicenses = null) => GetResources<SubSessionResults>($"/results/get", true, BuildParameters(["subsession_id", "include_licenses"], [subSessionId, includeLicenses]));

    /// <inheritdoc />
    public Task<ResultEventLogs> GetResultsEventLogs(int subSessionId, int simSessionNumber) => GetResources<ResultEventLogs>($"/results/event_log", true, BuildParameters(["subsession_id", "simsession_number"], [subSessionId, simSessionNumber]));

    /// <inheritdoc />
    public Task<ResultsLapChartData> GetResultsLapChartData(int subSessionId, int simSessionNumber) => GetResources<ResultsLapChartData>($"/results/lap_chart_data", true, BuildParameters(["subsession_id", "simsession_number"], [subSessionId, simSessionNumber]));

    /// <inheritdoc />
    public Task<ResultLapData> GetResultsLapData(int subSessionId, int simSessionNumber, int? customerId = null, int? teamId = null) => GetResources<ResultLapData>($"/results/lap_data", true, BuildParameters(["subsession_id", "simsession_number", "cust_id", "team_id"], [subSessionId, simSessionNumber, customerId, teamId]));

    /// <inheritdoc />
    public Task<ResultSearchHosted> GetResultsSearchHosted(DateTimeOffset? startRangeBegin = null, DateTimeOffset? startRangeEnd = null, DateTimeOffset? finishRangeBegin = null, DateTimeOffset? finishRangeEnd = null, int? custId = null, int? teamId = null, int? hostCustId = null, string? sessionName = null, int? leagueId = null, int? leagueSeasonId = null, int? carId = null, int? trackId = null, IEnumerable<int>? categoryIds = null) =>
        GetResources<ResultSearchHosted>("/results/search_hosted", false, BuildParameters(["start_range_begin", "start_range_end", "finish_range_begin", "finish_range_end", "cust_id", "team_id", "host_cust_id", "session_name", "league_id", "league_season_id", "car_id", "track_id", "category_ids"],
                       [startRangeBegin?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), startRangeEnd?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), finishRangeBegin?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), finishRangeEnd?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), custId, teamId, hostCustId, sessionName, leagueId, leagueSeasonId, carId, trackId, CreateCsv(categoryIds)]));

    /// <inheritdoc />
    public Task<ResultsSearchSeries> GetResultsSearchSeries(int? seasonYear = null, int? seasonQuarter = null, DateTimeOffset? startRangeBegin = null, DateTimeOffset? startRangeEnd = null, DateTimeOffset? finishRangeBegin = null, DateTimeOffset? finishRangeEnd = null, int? customerId = null, int? teamId = null, int? seriesId = null, int? raceWeekNum = null, bool? officialOnly = null, IEnumerable<int>? eventTypes = null, IEnumerable<int>? categoryIds = null) =>
        GetResources<ResultsSearchSeries>("/results/search_series", false, BuildParameters(["season_year", "season_quarter", "start_range_begin", "start_range_end", "finish_range_begin", "finish_range_end", "cust_id", "team_id", "series_id", "race_week_num", "official_only", "event_types", "category_ids"],
            [
                seasonYear,
                seasonQuarter,
                startRangeBegin?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture),
                startRangeEnd?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture),
                finishRangeBegin?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture),
                finishRangeEnd?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture),
                customerId,
                teamId,
                seriesId,
                raceWeekNum,
                officialOnly,
                CreateCsv(eventTypes),
                CreateCsv(categoryIds)
            ]));

    /// <inheritdoc />
    public Task<ResultsSeasonResults> GetResultsSeasonResults(int seasonId, int? eventType = null, int? raceWeekNum = null) =>
        GetResources<ResultsSeasonResults>("/results/season_results", true, BuildParameters(["season_id", "event_type", "race_week_num"], [seasonId, eventType, raceWeekNum]));


    /// <inheritdoc />
    public Task<SeasonListResult> GetSeasonList(int seasonYear, int seasonQuarter) =>
        GetResources<SeasonListResult>("/season/list", true, BuildParameters(["season_year", "season_quarter"], [seasonYear, seasonQuarter]));

    /// <inheritdoc />
    public Task<SeasonRaceGuideResults> GetSeasonRaceGuide(DateTime? from = null, bool? includeEndAfterFrom = null) =>
        GetResources<SeasonRaceGuideResults>("season/race_guide", true, BuildParameters(["from", "include_end_after_from"], [from?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), includeEndAfterFrom]));

    /// <inheritdoc />
    public Task<SeasonSpectatorSubSessionIdsResult> GetSeasonSpectatorSubSessionIds(IEnumerable<int>? eventTypes = null) =>
        GetResources<SeasonSpectatorSubSessionIdsResult>("/season/spectator_subsessionids", true, BuildParameters(["event_types"], [CreateCsv(eventTypes)]));

    /// <inheritdoc />
    public Task<Dictionary<string, SeriesAsset>> GetSeriesAssets() => GetResources<Dictionary<string, SeriesAsset>>("/series/assets", true);

    /// <inheritdoc />
    public Task<List<SeriesResult>> GetSeries() => GetResources<List<SeriesResult>>("/series/get", true);

    /// <inheritdoc />
    public Task<SeriesPastSeasonResult> GetSeriesPastSeasons(int seriesId) => GetResources<SeriesPastSeasonResult>($"/series/past_seasons", true, BuildParameters(["series_id"], [seriesId]));

    /// <inheritdoc />
    public Task<List<SeriesSeasonsResult>> GetSeriesSeasons(bool? includeSeries = null) => GetResources<List<SeriesSeasonsResult>>("/series/seasons", true, BuildParameters(["include_series"], [includeSeries]));

    /// <inheritdoc />
    public Task<List<SeriesStats>> GetSeriesStats() => GetResources<List<SeriesStats>>("/series/stats_series", true);

    /// <inheritdoc />
    public Task<StatsMemberBests> GetStatsMemberBests(int? customerId = null, int? carId = null) => GetResources<StatsMemberBests>("/stats/member_bests", true, BuildParameters(["cust_id", "car_id"], [customerId, carId]));

    /// <inheritdoc />
    public Task<StatsMemberCareer> GetStatsMemberCareer(int? customerId = null) => GetResources<StatsMemberCareer>("/stats/member_career", true, BuildParameters(["cust_id"], [customerId]));

    /// <inheritdoc />
    public Task<StatsMemberDivision> GetStatsMemberDivision(int seasonId, int eventType) => GetResources<StatsMemberDivision>("/stats/member_division", true, BuildParameters(["season_id", "event_type"], [seasonId, eventType]));

    /// <inheritdoc />
    public Task<StatsMemberRecapResult> GetStatsMemberRecap(int? customerId = null, int? year = null, int? seasonId = null) => GetResources<StatsMemberRecapResult>("/stats/member_recap", true, BuildParameters(["cust_id", "year", "season_id"], [customerId, year, seasonId]));

    /// <inheritdoc />
    public Task<StatsMemberRecentRacesResult> GetStatsMemberRecentRaces(int? customerId = null) => GetResources<StatsMemberRecentRacesResult>("/stats/member_recent_races", true, BuildParameters(["cust_id"], [customerId]));

    /// <inheritdoc />
    public Task<StatsMemberSummaryResult> GetStatsMemberSummary(int? customerId = null) => GetResources<StatsMemberSummaryResult>("/stats/member_summary", true, BuildParameters(["cust_id"], [customerId]));

    /// <inheritdoc />
    public Task<StatsMemberYearlyResult> GetStatsMemberYearly(int? customerId = null) => GetResources<StatsMemberYearlyResult>("/stats/member_yearly", true, BuildParameters(["cust_id"], [customerId]));

    /// <inheritdoc />
    public Task<StatsSeasonDriverStandingsResult> GetStatsSeasonDriverStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null) =>
        GetResources<StatsSeasonDriverStandingsResult>("/stats/season_driver_standings", true, BuildParameters(["season_id", "car_class_id", "division", "race_week_num"], [seasonId, carClassId, division, raceWeekNum]));

    /// <inheritdoc />
    public Task<StatsSeasonSuperSessionStandingsResult> GetStatsSeasonSuperSessionStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null) =>
        GetResources<StatsSeasonSuperSessionStandingsResult>("/stats/season_supersession_standings", true, BuildParameters(["season_id", "car_class_id", "division", "race_week_num"], [seasonId, carClassId, division, raceWeekNum]));

    /// <inheritdoc />
    public Task<StatsSeasonTeamStandingsResult> GetStatsSeasonTeamStandings(int seasonId, int carClassId, int? raceWeekNum = null) =>
        GetResources<StatsSeasonTeamStandingsResult>("/stats/season_team_standings", true, BuildParameters(["season_id", "car_class_id", "race_week_num"], [seasonId, carClassId, raceWeekNum]));

    /// <inheritdoc />
    public Task<StatsSeasonTtStandingsResult> GetStatsSeasonTtStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null) =>
        GetResources<StatsSeasonTtStandingsResult>("/stats/season_tt_standings", true, BuildParameters(["season_id", "car_class_id", "division", "race_week_num"], [seasonId, carClassId, division, raceWeekNum]));

    /// <inheritdoc />
    public Task<StatsSeasonTtResults> GetStatsSeasonTtResults(int seasonId, int carClassId, int raceWeekNum, int? division = null) =>
        GetResources<StatsSeasonTtResults>("/stats/season_tt_results", true, BuildParameters(["season_id", "car_class_id", "race_week_num", "division"], [seasonId, carClassId, raceWeekNum, division]));

    /// <inheritdoc />
    public Task<StatsWorldRecordResults> GetStatsWorldRecordResults(int carId, int trackId, int? seasonYear = null, int? seasonQuarter = null) =>
        GetResources<StatsWorldRecordResults>("/stats/world_records", true, BuildParameters(["car_id", "track_id", "season_year", "season_quarter"], [carId, trackId, seasonYear, seasonQuarter]));

    /// <inheritdoc />
    public Task<StatsSeasonQualifyResults> GetStatsSeasonQualifyResults(int seasonId, int carClassId, int raceWeekNum, int? division = null) =>
        GetResources<StatsSeasonQualifyResults>("/stats/season_qualify_results", true, BuildParameters(["season_id", "car_class_id", "race_week_num", "division"], [seasonId, carClassId, raceWeekNum, division]));

    /// <inheritdoc />
    public Task<TeamResult> GetTeam(int teamId, bool? includeLicenses = null) => GetResources<TeamResult>($"/team/get", true, BuildParameters(["team_id", "include_licenses"], [teamId, includeLicenses]));

    //TODO: Complete /data/time_attack/member_season_results

    /// <inheritdoc />
    public Task<Dictionary<string, TrackDetailsResult>> GetTrackAssets() => GetResources<Dictionary<string, TrackDetailsResult>>("/track/assets", true);

    /// <inheritdoc />
    public Task<List<TrackResult>> GetTracks() => GetResources<List<TrackResult>>("/track/get", true);

    /// <inheritdoc />
    public async Task<List<T>> GetChunkInfoData<T>(IChunkInfo<T> chunkedObject) where T : class => CompressLists(await GetAssets<List<T>>(chunkedObject.ChunkInfo.BaseDownloadUrl, chunkedObject.ChunkInfo.ChunkFileNames));

    /// <inheritdoc />
    public async IAsyncEnumerable<List<T>> GetChunkInfoDataPageAsyncEnumerable<T>(IChunkInfo<T> chunkedObject) where T : class
    {
        foreach (var file in chunkedObject.ChunkInfo.ChunkFileNames)
        {
            yield return (await GetAssets<List<T>>(chunkedObject.ChunkInfo.BaseDownloadUrl, new List<string> { file })).First();
        }
    }

    /// <summary>
    /// Get resources from the iRacing API
    /// </summary>
    private async Task<T> GetResources<T>(string path, bool followLink, IEnumerable<KeyValuePair<string, string>>? parameters = null)
    {
        var url = BuildUrl(_settings.BaseUrl, GetCombinedPath(path), parameters);

        if (!followLink)
        {
            return await GetFromApi<T>(url);
        }
        else
        {
            var link = await GetFromApi<ResourceLink>(url);
            return await GetFromApi<T>(link.Link);
        }
    }

    private async Task<List<T>> GetAssets<T>(string baseUrl, List<string> assets)
    {
        if (assets.Count == 0)
        {
            return new List<T>();
        }

        _logger.LogInformation($"Getting {assets.Count} assets from {baseUrl}");

        using var semaphore = new SemaphoreSlim(_settings.MaxParallelAssetRequests);

        var tasks = assets.Select(async asset =>
        {
            await semaphore.WaitAsync();
            try
            {
                var url = $"{baseUrl.TrimEnd('/')}/{asset.TrimStart('/')}";
                return await GetFromApi<T>(url);
            }
            finally
            {
                semaphore.Release();
            }
        });

        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    private async Task<T> GetFromApi<T>(string url)
    {
        var httpClient = _httpClientFactory.CreateClient(_httpClientName);

        using var response = await _retryPolicy.ExecuteAsync(async () =>
        {
            return await httpClient.GetAsync(url);
        });

        if (!response.IsSuccessStatusCode)
        {
            ErrorResponse? errorResponse = null;
            string? rawContent = null;

            try
            {
                errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            }
            catch (JsonException)
            {
                rawContent = await response.Content.ReadAsStringAsync();
            }

            var error = errorResponse?.Error;
            var message = errorResponse?.Message;

            if (string.IsNullOrWhiteSpace(message))
            {
                rawContent ??= await response.Content.ReadAsStringAsync();
                message = $"Request to {url} failed with status code {(int)response.StatusCode} ({response.ReasonPhrase}). Response content: {rawContent}";
            }

            throw new ErrorResponseException(response.StatusCode, error ?? string.Empty, message);
        }

        var result = await response.Content.ReadFromJsonAsync<T>();
        if (result == null)
        {
            throw new InvalidOperationException($"Failed to deserialize response from {url}");
        }

        return result;
    }

    private string GetCombinedPath(string path)
    {
        return GetPrecedingSlashed("data") + GetPrecedingSlashed(path);
    }

    private string GetPrecedingSlashed(string path)
    {
        return path.StartsWith("/") ? path : $"/{path}";
    }

    private static string CreateCsv<T>(IEnumerable<T>? values)
    {
        if (values == null)
        {
            return string.Empty;
        }
        return string.Join(',', values.Select(v => v?.ToString() ?? string.Empty).Where(v => !string.IsNullOrWhiteSpace(v)));
    }

    private IEnumerable<KeyValuePair<string, string>> BuildParameters(string[] keys, object?[] values)
    {
        if (keys.Length != values.Length)
        {
            throw new ArgumentException("Keys and values must be the same length");
        }

        var parameters = new List<KeyValuePair<string, string>>();

        for (int i = 0; i < keys.Length; i++)
        {
            var value = values[i]?.ToString();
            if (value != null && !string.IsNullOrWhiteSpace(value))
            {
                parameters.Add(new(keys[i], value));
            }
        }

        return parameters;
    }

    private static string BuildUrl(string baseUrl, string path, IEnumerable<KeyValuePair<string, string>>? parameters = null)
    {
        var url = $"{baseUrl.TrimEnd('/')}/{path.TrimStart('/')}";

        if (parameters == null || !parameters.Any())
        {
            return url;
        }

        var queryString = string.Join("&", parameters
            .Where(p => !string.IsNullOrWhiteSpace(p.Value))
            .Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));

        return string.IsNullOrEmpty(queryString) ? url : $"{url}?{queryString}";
    }

    private static List<T> CompressLists<T>(List<List<T>> listOfList)
    {
        var response = new List<T>();
        foreach (var list in listOfList)
        {
            response.AddRange(list);
        }
        return response;
    }
}
