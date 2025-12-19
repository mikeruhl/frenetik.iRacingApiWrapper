using Frenetik.iRacingApiWrapper.Config;
using Frenetik.iRacingApiWrapper.Enums;
using Frenetik.iRacingApiWrapper.Extensions;
using Frenetik.iRacingApiWrapper.Models;
using Frenetik.iRacingApiWrapper.Service;
using Frenetik.iRacingApiWrapper.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text.Json;
using System.Net.Http.Json;

namespace Frenetik.iRacingApiWrapper;

/// <summary>
/// iRacing API Wrapper
/// </summary>
public class IRacingApiService
{
    private readonly IRacingDataSettings _settings = new();
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<IRacingApiService> _logger;
    private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

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
    public IRacingApiService(IHttpClientFactory httpClientFactory, IOptions<IRacingDataSettings>? settings, ILogger<IRacingApiService> logger)
    {
        ArgumentNullException.ThrowIfNull(httpClientFactory);
        ArgumentNullException.ThrowIfNull(logger);

        _settings = settings?.Value ?? new IRacingDataSettings();
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _retryPolicy = RetryPolicyBuilder.BuildPolicy(_settings.RetryPolicy, _logger);
    }

    /// <summary>
    /// Gets documentation for all available endpoints, including required and optional parameters.
    /// Each endpoint is a dictionary with the key being the endpoint name and the value being a dictionary of the endpoint details.
    /// </summary>
    /// <returns></returns>
    public Task<Dictionary<string, Dictionary<string, EndpointDetails>>> GetDoc() => GetResources<Dictionary<string, Dictionary<string, EndpointDetails>>>("/doc", false);

    /// <summary>
    /// Get Category constants
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Constant>> GetConstantsCategories() => GetResources<IEnumerable<Constant>>("/constants/categories", false);

    /// <summary>
    /// Get Division constants
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Constant>> GetConstantsDivisions() => GetResources<IEnumerable<Constant>>("/constants/divisions", false);

    /// <summary>
    /// Get EventType constants
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Constant>> GetConstantsEventTypes() => GetResources<IEnumerable<Constant>>("/constants/event_types", false);

    /// <summary>
    /// Get car assets
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CarAsset>> GetCarAssets() => (await GetResources<Dictionary<string, CarAsset>>("/car/assets", true)).Values;

    /// <summary>
    /// Get cars
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Car>> GetCars() => GetResources<IEnumerable<Car>>("/car/get", true);

    /// <summary>
    /// Get car classes
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<CarClass>> GetCarClasses() => GetResources<IEnumerable<CarClass>>("/carclass/get", true);

    /// <summary>
    /// Get hosted combined sessions
    /// </summary>
    /// <returns></returns>
    public Task<SessionResult> GetHostedCombinedSessions() => GetResources<SessionResult>("/hosted/combined_sessions", true);

    /// <summary>
    /// Get hosted combined session by package id
    /// </summary>
    /// <param name="packageId"></param>
    /// <returns></returns>
    public Task<SessionResult> GetHostedCombinedSession(int packageId) => GetResources<SessionResult>("/hosted/combined_sessions", true, new Dictionary<string, string> { { "package_Id", packageId.ToString() } });

    /// <summary>
    /// Get hosted sessions
    /// </summary>
    /// <returns></returns>
    public Task<SessionResult> GetHostedSessions() => GetResources<SessionResult>("/hosted/sessions", true);

    /// <summary>
    /// Get Cust League Session Results
    /// </summary>
    /// <param name="mine">If true, return only sessions created by this user.</param>
    /// <param name="packageId">If set, return only sessions using this car or track package ID.</param>
    /// <returns></returns>
    public Task<SessionResult> GetCustLeagueSessionResults(bool mine = false, int? packageId = null) => GetResources<SessionResult>("/league/cust_league_sessions", true, BuildParameters(["mine", "package_id"], [mine, packageId]));

    /// <summary>
    /// Search for leagues based on various criteria.
    /// </summary>
    /// <param name="search">Will search against league name, description, owner, and league ID.</param>
    /// <param name="tag">One or more tags, comma-separated.</param>
    /// <param name="restrictToMember">If true include only leagues for which customer is a member.</param>
    /// <param name="restrictToRecruiting">If true include only leagues which are recruiting.</param>
    /// <param name="restrictToFriends">If true include only leagues owned by a friend.</param>
    /// <param name="restrictToWatched">If true include only leagues owned by a watched member.</param>
    /// <param name="minimumRosterCount">If set include leagues with at least this number of members.</param>
    /// <param name="maximumRosterCount">If set include leagues with no more than this number of members.</param>
    /// <param name="lowerBound">First row of results to return.  Defaults to 1.</param>
    /// <param name="upperBound">Last row of results to return. Defaults to lowerbound + 39.</param>
    /// <param name="sort">One of relevance, leaguename, displayname, rostercount. displayname is owners's name. Defaults to relevance.</param>
    /// <param name="order">One of asc or desc.  Defaults to asc.</param>
    /// <returns></returns>
    public Task<LeagueResult> SearchLeagues(string? search = null, string? tag = null, bool? restrictToMember = null, bool? restrictToRecruiting = null, bool? restrictToFriends = null, bool? restrictToWatched = null,
        bool? minimumRosterCount = null, bool? maximumRosterCount = null, int? lowerBound = null, int? upperBound = null, LeagueSortValue? sort = null, SortOrder? order = null) =>
        GetResources<LeagueResult>("/league/directory", true, BuildParameters(["search", "tag", "restrict_to_member", "restrict_to_recruiting", "restrict_to_friends", "restrict_to_watched", "minimum_roster_count", "maximum_roster_count", "lowerbound", "upperbound", "sort", "order"],
            [search, tag, restrictToMember, restrictToRecruiting, restrictToFriends, restrictToWatched, minimumRosterCount, maximumRosterCount, lowerBound, upperBound, sort?.GetEnumMemberValue(), order?.GetEnumMemberValue()]));

    /// <summary>
    /// Get League by ID
    /// </summary>
    /// <param name="leagueId">League Id (required).</param>
    /// <param name="includeLicenses">For faster responses, only request when necessary.</param>
    /// <returns></returns>
    public Task<LeagueDetailed> GetLeagueById(int leagueId, bool? includeLicenses = null) => GetResources<LeagueDetailed>($"/league/get", true, BuildParameters(["league_id", "include_licenses"], [leagueId, includeLicenses]));

    /// <summary>
    /// Get Points System By League Id and (optionally) Season Id
    /// </summary>
    /// <param name="leagueId"></param>
    /// <param name="seasonId">If included and the season is using custom points (points_system_id:2) then the custom points option is included in the returned list. Otherwise the custom points option is not returned.</param>
    /// <returns></returns>
    public Task<PointsSystemResponse> GetPointsSystems(int leagueId, int? seasonId = null) => GetResources<PointsSystemResponse>($"/league/get_points_systems", true, BuildParameters(["league_id", "season_id"], [leagueId, seasonId]));

    /// <summary>
    /// Get LeagueMembership by Customer Id
    /// </summary>
    /// <param name="customerId">If different from the authenticated member, the following resrictions apply: <para />
    /// - Caller cannot be on requested customer's block list or an empty list will result;<para />
    /// - Requested customer cannot have their online activity prefrence set to hidden or an empty list will result;<para />
    /// - Only leagues for which the requested customer is an admin and the league roster is not private are returned.</param>
    /// <param name="includeLeague"></param>
    /// <returns></returns>
    public Task<List<LeagueMembership>> GetLeagueMembership(int customerId, bool? includeLeague = null) => GetResources<List<LeagueMembership>>($"/league/membership", true, BuildParameters(["cust_id", "include_league"], [customerId, includeLeague]));

    /// <summary>
    /// Returns a League's Seasons
    /// </summary>
    /// <param name="leagueId">League Id</param>
    /// <param name="retired">If true include seasons which are no longer active.</param>
    /// <returns></returns>
    public Task<LeagueSeasonResult> GetLeagueSeasons(int leagueId, bool? retired = null) => GetResources<LeagueSeasonResult>($"/league/seasons", true, BuildParameters(["league_id", "return"], [leagueId, retired]));

    /// <summary>
    /// Get League Season Standings
    /// </summary>
    /// <param name="leagueId">League Id</param>
    /// <param name="seasonId">Season Id</param>
    /// <param name="carClassId"></param>
    /// <param name="carId">If car_class_id is included then the standings are for the car in that car class, otherwise they are for the car across car classes.</param>
    /// <returns></returns>
    public Task<LeagueSeasonStandingsResult> GetLeagueSeasonStandings(int leagueId, int seasonId, int? carClassId = null, int? carId = null) => GetResources<LeagueSeasonStandingsResult>($"/league/season_standings", true, BuildParameters(["league_id", "season_id", "car_class_id", "car_id"], [leagueId, seasonId, carClassId, carId]));

    /// <summary>
    /// Get league season sessions
    /// </summary>
    /// <param name="leagueId">League Id</param>
    /// <param name="seasonId">Season Id</param>
    /// <param name="resultsOnly">If true include only sessions for which results are available.</param>
    /// <returns></returns>
    public Task<LeagueSeasonSessionsResult> GetLeagueSeasonsSessions(int leagueId, int seasonId, bool? resultsOnly = null) => GetResources<LeagueSeasonSessionsResult>($"/league/season_sessions", true, BuildParameters(["league_id", "season_id", "results_only"], [leagueId, seasonId, resultsOnly]));

    /// <summary>
    /// Lookup Countries
    /// </summary>
    /// <returns></returns>
    public Task<List<Country>> LookupCountries() => GetResources<List<Country>>("/lookup/countries", true);

    /// <summary>
    /// Lookup Drivers
    /// </summary>
    /// <param name="searchTerm">Search Term (required)</param>
    /// <param name="leagueId">League Id</param>
    /// <returns></returns>
    public Task<List<Driver>> LookupDrivers(string searchTerm, int? leagueId = null) => GetResources<List<Driver>>("/lookup/drivers", true, BuildParameters(["search_term", "league_id"], [searchTerm, leagueId]));

    /// <summary>
    /// Lookup values of settings using a dictionary where key is the tag name and the value is an array of lookup values to be tagged.
    /// </summary>
    /// <param name="lookups"></param>
    /// <example> 
    /// <code>
    /// var lookups = new Dictionary%lt;string, string[]%gt;
    /// {
    ///     { "weather", new string[] { "weather_wind_speed_units", "weather_wind_speed_max", "weather_wind_speed_min" } },
    ///     { "licenselevels", new string[] { "licenselevels" } }
    /// };
    /// var result = await api.Lookup(lookups);
    /// </code>
    /// </example>
    /// <returns></returns>
    public Task<List<LookupResult>> Lookup(Dictionary<string, string[]> lookups) => GetResources<List<LookupResult>>("/lookup/get", true, lookups.SelectMany(kvp => kvp.Value.Select(v => new KeyValuePair<string, string>(kvp.Key, v))));

    /// <summary>
    /// Lookup License Levels
    /// </summary>
    /// <returns></returns>
    public Task<List<LookupLicenseResult>> LookupLicenses() => GetResources<List<LookupLicenseResult>>("/lookup/licenses", true);

    /// <summary>
    /// Lookup a member's awards.
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<List<MemberAward>> GetMemberAwards(int? customerId) => GetResources<List<MemberAward>>($"/member/awards", true, BuildParameters(["cust_id"], [customerId]));

    /// <summary>
    /// Get a member's chart data.
    /// </summary>
    /// <param name="categoryId">1 - Oval; 2 - Road; 3 - Dirt oval; 4 - Dirt road</param>
    /// <param name="chartType">"1 - iRating; 2 - TT Rating; 3 - License/SR</param>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<MemberChartData> GetMemberChartData(int categoryId, int chartType, int? customerId) => GetResources<MemberChartData>($"/member/chart_data", true, BuildParameters(["category_id", "chart_type", "cust_id"], [categoryId, chartType, customerId]));

    /// <summary>
    /// Get a member's data.
    /// </summary>
    /// <param name="customerIds"></param>
    /// <param name="includeLicenses"></param>
    /// <returns></returns>
    public Task<MembersResult> GetMember(IEnumerable<int> customerIds, bool includeLicenses) => GetResources<MembersResult>($"/member/get", true, BuildParameters(["cust_ids", "include_licenses"], [CreateCsv(customerIds), includeLicenses]));

    /// <summary>
    /// Get Member Info (Always the authenticated member.)
    /// </summary>
    /// <returns></returns>
    public Task<MemberInfo> GetMemberInfo() => GetResources<MemberInfo>("/member/info", true);

    /// <summary>
    /// Get Member Participation Credits (Always the authenticated member.)
    /// </summary>
    /// <returns></returns>
    public Task<List<MemberParticipationCredits>> GetMemberParticipationCredits() => GetResources<List<MemberParticipationCredits>>("member/participation_credits", true);

    /// <summary>
    /// Get Member Profile
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<MemberProfile> GetMemberProfile(int? customerId) => GetResources<MemberProfile>("/member/profile", true, BuildParameters(["cust_id"], [customerId]));

    /// <summary>
    /// Get Member Recent Results <para />
    /// Get the results of a subsession, if authorized to view them. series_logo image paths are relative to https://images-static.iracing.com/img/logos/series/
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="includeLicenses"></param>
    /// <returns></returns>
    public Task<SubSessionResults> GetResults(int subSessionId, bool? includeLicenses) => GetResources<SubSessionResults>($"/results/get", true, BuildParameters(["subsession_id", "include_licenses"], [subSessionId, includeLicenses]));

    /// <summary>
    /// Get Result Event Logs
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="simSessionNumber">The main event is 0; the preceding event is -1, and so on.</param>
    /// <returns></returns>
    public Task<ResultEventLogs> GetResultsEventLogs(int subSessionId, int simSessionNumber) => GetResources<ResultEventLogs>($"/results/event_log", true, BuildParameters(["subsession_id", "simsession_number"], [subSessionId, simSessionNumber]));

    /// <summary>
    /// Get Result LapChartData
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="simSessionNumber">The main event is 0; the preceding event is -1, and so on.</param>
    /// <returns></returns>
    public Task<ResultsLapChartData> GetResultsLapChartData(int subSessionId, int simSessionNumber) => GetResources<ResultsLapChartData>($"/results/lap_chart_data", true, BuildParameters(["subsession_id", "simsession_number"], [subSessionId, simSessionNumber]));

    /// <summary>
    /// Get lap data for a subsession
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="simSessionNumber">The main event is 0; the preceding event is -1, and so on.</param>
    /// <param name="customerId">Required if the subsession was a single-driver event. Optional for team events. If omitted for a team event then the laps driven by all the team's drivers will be included.</param>
    /// <param name="teamId">Required if the subsession was a team event.</param>
    /// <returns></returns>
    public Task<ResultLapData> GetResultsLapData(int subSessionId, int simSessionNumber, int? customerId, int? teamId) => GetResources<ResultLapData>($"/results/lap_data", true, BuildParameters(["subsession_id", "simsession_number", "cust_id", "team_id"], [subSessionId, simSessionNumber, customerId, teamId]));

    /// <summary>
    /// Hosted and league sessions.  Maximum time frame of 90 days. Results split into one or more files with chunks of results. For scraping results the most effective approach is to keep track of the maximum end_time found during a search then make the subsequent call using that date/time as the finish_range_begin and skip any subsessions that are duplicated.  Results are ordered by subsessionid which is a proxy for start time. Requires one of: start_range_begin, finish_range_begin. Requires one of: cust_id, team_id, host_cust_id, session_name.
    /// </summary>
    /// <param name="startRangeBegin">Session start times. ISO-8601 UTC time zero offset: "2022-04-01T15:45Z".</param>
    /// <param name="startRangeEnd">ISO-8601 UTC time zero offset: "2022-04-01T15:45Z". Exclusive. May be omitted if start_range_begin is less than 90 days in the past.</param>
    /// <param name="finishRangeBegin">Session finish times. ISO-8601 UTC time zero offset: "2022-04-01T15:45Z".</param>
    /// <param name="finishRangeEnd">ISO-8601 UTC time zero offset: "2022-04-01T15:45Z". Exclusive. May be omitted if finish_range_begin is less than 90 days in the past.</param>
    /// <param name="custId">The participant's customer ID. Ignored if team_id is supplied.</param>
    /// <param name="teamId">The team ID to search for. Takes priority over cust_id if both are supplied.</param>
    /// <param name="hostCustId">The host's customer ID.</param>
    /// <param name="sessionName">Part or all of the session's name.</param>
    /// <param name="leagueId">Include only results for the league with this ID.</param>
    /// <param name="leagueSeasonId">Include only results for the league season with this ID.</param>
    /// <param name="carId">One of the cars used by the session.</param>
    /// <param name="trackId">The ID of the track used by the session.</param>
    /// <param name="categoryIds">Track categories to include in the search.  Defaults to all</param>
    /// <returns></returns>
    public Task<ResultSearchHosted> GetResultsSearchHosted(DateTimeOffset? startRangeBegin = null, DateTimeOffset? startRangeEnd = null, DateTimeOffset? finishRangeBegin = null, DateTimeOffset? finishRangeEnd = null, int? custId = null, int? teamId = null, int? hostCustId = null, string? sessionName = null, int? leagueId = null, int? leagueSeasonId = null, int? carId = null, int? trackId = null, IEnumerable<int>? categoryIds = null) =>
        GetResources<ResultSearchHosted>("/results/search_hosted", false, BuildParameters(["start_range_begin", "start_range_end", "finish_range_begin", "finish_range_end", "cust_id", "team_id", "host_cust_id", "session_name", "league_id", "league_season_id", "car_id", "track_id", "category_ids"],
                       [startRangeBegin?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), startRangeEnd?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), finishRangeBegin?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), finishRangeEnd?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), custId, teamId, hostCustId, sessionName, leagueId, leagueSeasonId, carId, trackId, CreateCsv(categoryIds)]));

    /// <summary>
    /// Official series.  Maximum time frame of 90 days. Results split into one or more files with chunks of results. For scraping results the most effective approach is to keep track of the maximum end_time found during a search then make the subsequent call using that date/time as the finish_range_begin and skip any subsessions that are duplicated.  Results are ordered by subsessionid which is a proxy for start time but groups together multiple splits of a series when multiple series launch sessions at the same time. Requires at least one of: season_year and season_quarter, start_range_begin, finish_range_begin.
    /// </summary>
    /// <param name="seasonYear">Required when using season_quarter.</param>
    /// <param name="seasonQuarter">Required when using season_year.</param>
    /// <param name="startRangeBegin">Session start times. ISO-8601 UTC time zero offset: "2022-04-01T15:45Z".</param>
    /// <param name="startRangeEnd">ISO-8601 UTC time zero offset: "2022-04-01T15:45Z". Exclusive. May be omitted if start_range_begin is less than 90 days in the past.</param>
    /// <param name="finishRangeBegin">Session finish times. ISO-8601 UTC time zero offset: "2022-04-01T15:45Z".</param>
    /// <param name="finishRangeEnd">ISO-8601 UTC time zero offset: "2022-04-01T15:45Z". Exclusive. May be omitted if finish_range_begin is less than 90 days in the past.</param>
    /// <param name="customerId">Include only sessions in which this customer participated. Ignored if team_id is supplied.</param>
    /// <param name="teamId">Include only sessions in which this team participated. Takes priority over cust_id if both are supplied.</param>
    /// <param name="seriesId">Include only sessions for series with this ID.</param>
    /// <param name="raceWeekNum">Include only sessions with this race week number.</param>
    /// <param name="officialOnly">If true, include only sessions earning championship points. Defaults to all.</param>
    /// <param name="eventTypes">Types of events to include in the search. Defaults to all.</param>
    /// <param name="categoryIds">License categories to include in the search.  Defaults to all.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Get Season Results
    /// </summary>
    /// <param name="seasonId">Season Id (required)</param>
    /// <param name="eventType">Retrict to one event type: 2 - Practice; 3 - Qualify; 4 - Time Trial; 5 - Race</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    public Task<ResultsSeasonResults> GetResultsSeasonResults(int seasonId, int? eventType = null, int? raceWeekNum = null) =>
        GetResources<ResultsSeasonResults>("/results/season_results", true, BuildParameters(["season_id", "event_type", "race_week_num"], [seasonId, eventType, raceWeekNum]));


    /// <summary>
    /// Get Season List
    /// </summary>
    /// <param name="seasonYear">Required</param>
    /// <param name="seasonQuarter">Required</param>
    /// <returns></returns>
    public Task<SeasonListResult> GetSeasonList(int seasonYear, int seasonQuarter) =>
        GetResources<SeasonListResult>("/season/list", true, BuildParameters(["season_year", "season_quarter"], [seasonYear, seasonQuarter]));

    /// <summary>
    /// Get Season Race Guide
    /// </summary>
    /// <param name="from">ISO-8601 offset format. Defaults to the current time. Include sessions with start times up to 3 hours after this time. Times in the past will be rewritten to the current time.</param>
    /// <param name="includeEndAfterFrom">Include sessions which start before 'from' but end after.</param>
    /// <returns></returns>
    public Task<SeasonRaceGuideResults> GetSeasonRaceGuide(DateTime? from = null, bool? includeEndAfterFrom = null) =>
        GetResources<SeasonRaceGuideResults>("season/race_guide", true, BuildParameters(["from", "include_end_after_from"], [from?.ToString(Iso8601DateFormat, CultureInfo.InvariantCulture), includeEndAfterFrom]));

    /// <summary>
    /// Get Season Spectator SubSessionIds
    /// </summary>
    /// <param name="eventTypes">Types of events to include in the search. Defaults to all.</param>
    /// <returns></returns>
    public Task<SeasonSpectatorSubSessionIdsResult> GetSeasonSpectatorSubSessionIds(IEnumerable<int>? eventTypes) =>
        GetResources<SeasonSpectatorSubSessionIdsResult>("/season/spectator_subsessionids", true, BuildParameters(["event_types"], [CreateCsv(eventTypes)]));

    /// <summary>
    /// Get Series Assetts (image paths are relative to https://images-static.iracing.com/)
    /// </summary>
    /// <returns>Dictionary where key is series id and value is series asset</returns>
    public Task<Dictionary<string, SeriesAsset>> GetSeriesAssets() => GetResources<Dictionary<string, SeriesAsset>>("/series/assets", true);

    /// <summary>
    /// Get Series
    /// </summary>
    /// <returns></returns>
    public Task<List<SeriesResult>> GetSeries() => GetResources<List<SeriesResult>>("/series/get", true);

    /// <summary>
    /// Get all seasons for a series. Filter list by official:true for seasons with standings.
    /// </summary>
    /// <param name="seriesId">Series Id (required)</param>
    /// <returns></returns>
    public Task<SeriesPastSeasonResult> GetSeriesPastSeasons(int seriesId) => GetResources<SeriesPastSeasonResult>($"/series/past_seasons", true, BuildParameters(["series_id"], [seriesId]));

    /// <summary>
    /// Get Series
    /// </summary>
    /// <param name="includeSeries"></param>
    /// <returns></returns>
    public Task<List<SeriesSeasonsResult>> GetSeriesSeasons(bool? includeSeries = null) => GetResources<List<SeriesSeasonsResult>>("/series/seasons", true, BuildParameters(["include_series"], [includeSeries]));

    /// <summary>
    /// Get Series Stats
    /// </summary>
    /// <returns></returns>
    public Task<List<SeriesStats>> GetSeriesStats() => GetResources<List<SeriesStats>>("/series/stats_series", true);

    /// <summary>
    /// Get Stats Member Bests
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <param name="carId">First call should exclude car_id; use cars_driven list in return for subsequent calls.</param>
    /// <returns></returns>
    public Task<StatsMemberBests> GetStatsMemberBests(int? customerId = null, int? carId = null) => GetResources<StatsMemberBests>("/stats/member_bests", true, BuildParameters(["cust_id", "car_id"], [customerId, carId]));

    /// <summary>
    /// Get Status Member Career
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<StatsMemberCareer> GetStatsMemberCareer(int? customerId = null) => GetResources<StatsMemberCareer>("/stats/member_career", true, BuildParameters(["cust_id"], [customerId]));

    /// <summary>
    /// Get Stats Member Division (Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Always for the authenticated member.)
    /// </summary>
    /// <param name="seasonId">(Required)</param>
    /// <param name="eventType">The event type code for the division type: 4 - Time Trial; 5 - Race (Required)</param>
    /// <returns></returns>
    public Task<StatsMemberDivision> GetStatsMemberDivision(int seasonId, int eventType) => GetResources<StatsMemberDivision>("/stats/member_division", true, BuildParameters(["season_id", "event_type"], [seasonId, eventType]));

    /// <summary>
    /// Get Stats Member Event Results
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <param name="year">Season year; if not supplied the current calendar year (UTC) is used.</param>
    /// <param name="seasonId">Season (quarter) within the year; if not supplied the recap will be fore the entire year.</param>
    /// <returns></returns>
    public Task<StatsMemberRecapResult> GetStatsMemberRecap(int? customerId = null, int? year = null, int? seasonId = null) => GetResources<StatsMemberRecapResult>("/stats/member_recap", true, BuildParameters(["cust_id", "year", "season_id"], [customerId, year, seasonId]));

    /// <summary>
    /// Get Stats Member Recent Races
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<StatsMemberRecentRacesResult> GetStatsMemberRecentRaces(int? customerId = null) => GetResources<StatsMemberRecentRacesResult>("/stats/member_recent_races", true, BuildParameters(["cust_id"], [customerId]));

    /// <summary>
    /// Get Stats Member Results
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<StatsMemberSummaryResult> GetStatsMemberSummary(int? customerId = null) => GetResources<StatsMemberSummaryResult>("/stats/member_summary", true, BuildParameters(["cust_id"], [customerId]));

    /// <summary>
    /// Get Stats Member Yearly
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    public Task<StatsMemberYearlyResult> GetStatsMemberYearly(int? customerId = null) => GetResources<StatsMemberYearlyResult>("/stats/member_yearly", true, BuildParameters(["cust_id"], [customerId]));

    /// <summary>
    /// Get Stats Season Driver Standings
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    public Task<StatsSeasonDriverStandingsResult> GetStatsSeasonDriverStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null) =>
        GetResources<StatsSeasonDriverStandingsResult>("/stats/season_driver_standings", true, BuildParameters(["season_id", "car_class_id", "division", "race_week_num"], [seasonId, carClassId, division, raceWeekNum]));

    /// <summary>
    /// Get Stats Season Supersession Results
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    public Task<StatsSeasonSuperSessionStandingsResult> GetStatsSeasonSuperSessionStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null) =>
        GetResources<StatsSeasonSuperSessionStandingsResult>("/stats/season_supersession_standings", true, BuildParameters(["season_id", "car_class_id", "division", "race_week_num"], [seasonId, carClassId, division, raceWeekNum]));

    /// <summary>
    /// Get Stats Season Team Standings
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    public Task<StatsSeasonTeamStandingsResult> GetStatsSeasonTeamStandings(int seasonId, int carClassId, int? raceWeekNum = null) =>
        GetResources<StatsSeasonTeamStandingsResult>("/stats/season_team_standings", true, BuildParameters(["season_id", "car_class_id", "race_week_num"], [seasonId, carClassId, raceWeekNum]));

    /// <summary>
    /// Get Stats Season TT Standings
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    public Task<StatsSeasonTtStandingsResult> GetStatsSeasonTtStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null) =>
        GetResources<StatsSeasonTtStandingsResult>("/stats/season_tt_standings", true, BuildParameters(["season_id", "car_class_id", "division", "race_week_num"], [seasonId, carClassId, division, raceWeekNum]));

    /// <summary>
    /// Get Stats Season TT Results
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0. (Required)</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <returns></returns>
    public Task<StatsSeasonTtResults> GetStatsSeasonTtResults(int seasonId, int carClassId, int raceWeekNum, int? division = null) =>
        GetResources<StatsSeasonTtResults>("/stats/season_tt_results", true, BuildParameters(["season_id", "car_class_id", "race_week_num", "division"], [seasonId, carClassId, raceWeekNum, division]));

    /// <summary>
    /// Get Stats World Record Results
    /// </summary>
    /// <param name="carId">Required.</param>
    /// <param name="trackId">Required.</param>
    /// <param name="seasonYear">Limit best times to a given year.</param>
    /// <param name="seasonQuarter">Limit best times to a given quarter; only applicable when year is used.</param>
    /// <returns></returns>
    public Task<StatsWorldRecordResults> GetStatsWorldRecordResults(int carId, int trackId, int? seasonYear = null, int? seasonQuarter = null) =>
        GetResources<StatsWorldRecordResults>("/stats/world_records", true, BuildParameters(["car_id", "track_id", "season_year", "season_quarter"], [carId, trackId, seasonYear, seasonQuarter]));

    /// <summary>
    /// Get Stats Season Qualify Results
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0. (Required)</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <returns></returns>
    public Task<StatsSeasonQualifyResults> GetStatsSeasonQualifyResults(int seasonId, int carClassId, int raceWeekNum, int? division = null) =>
        GetResources<StatsSeasonQualifyResults>("/stats/season_qualify_results", true, BuildParameters(["season_id", "car_class_id", "race_week_num", "division"], [seasonId, carClassId, raceWeekNum, division]));

    /// <summary>
    /// Get Team by Id
    /// </summary>
    /// <param name="teamId">Required.</param>
    /// <param name="includeLicenses">For faster responses, only request when necessary.</param>
    /// <returns></returns>
    public Task<TeamResult> GetTeam(int teamId, bool? includeLicenses = null) => GetResources<TeamResult>($"/team/get", true, BuildParameters(["team_id", "include_licenses"], [teamId, includeLicenses]));

    //TODO: Complete /data/time_attack/member_season_results

    /// <summary>
    /// Get Time Attack Season Results
    /// </summary>
    /// <remarks>image paths are relative to https://images-static.iracing.com/</remarks>
    /// <returns></returns>
    public Task<Dictionary<string, TrackDetailsResult>> GetTrackAssets() => GetResources<Dictionary<string, TrackDetailsResult>>("/track/assets", true);

    /// <summary>
    /// Get Tracks
    /// </summary>
    /// <remarks>image paths are relative to https://images-static.iracing.com/</remarks>
    /// <returns></returns>
    public Task<List<TrackResult>> GetTracks() => GetResources<List<TrackResult>>("/track/get", true);

    /// <summary>
    /// Some responses have a chunk_info property which contains a base_download_url and a list of chunk_file_names.  This method will retrieve the chunked data and return it as a list of lists.
    /// </summary>
    /// <typeparam name="T">Chunk Info's response data type</typeparam>
    /// <param name="chunkedObject"></param>
    /// <returns></returns>
    public async Task<List<T>> GetChunkInfoData<T>(IChunkInfo<T> chunkedObject) where T : class => CompressLists(await GetAssets<List<T>>(chunkedObject.ChunkInfo.BaseDownloadUrl, chunkedObject.ChunkInfo.ChunkFileNames));

    /// <summary>
    /// Some responses have a chunk_info property which contains a base_download_url and a list of chunk_file_names.  
    /// This method will retrieve the chunked data and return it as an async enumerable of lists.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="chunkedObject"></param>
    /// <returns></returns>
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
        var httpClient = _httpClientFactory.CreateClient(HttpClientName);

        using var response = await _retryPolicy.ExecuteAsync(async () =>
        {
            var resp = await httpClient.GetAsync(url);
            // Buffer the content so it can be read multiple times synchronously in retry predicates
            await resp.Content.LoadIntoBufferAsync();
            return resp;
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
