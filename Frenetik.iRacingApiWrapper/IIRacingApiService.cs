using Frenetik.iRacingApiWrapper.Enums;
using Frenetik.iRacingApiWrapper.Models;
using Frenetik.iRacingApiWrapper.Models.MemberAwards;

namespace Frenetik.iRacingApiWrapper;

/// <summary>
/// Interface for IRacing API Service
/// </summary>
public interface IIRacingApiService
{
    /// <summary>
    /// Get car assets
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CarAsset>> GetCarAssets();

    /// <summary>
    /// Get car classes
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CarClass>> GetCarClasses();

    /// <summary>
    /// Get cars
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Car>> GetCars();

    /// <summary>
    /// Some responses have a chunk_info property which contains a base_download_url and a list of chunk_file_names.  This method will retrieve the chunked data and return it as a list of lists.
    /// </summary>
    /// <typeparam name="T">Chunk Info's response data type</typeparam>
    /// <param name="chunkedObject"></param>
    /// <returns></returns>
    Task<List<T>> GetChunkInfoData<T>(IChunkInfo<T> chunkedObject) where T : class;

    /// <summary>
    /// Some responses have a chunk_info property which contains a base_download_url and a list of chunk_file_names.
    /// This method will retrieve the chunked data and return it as an async enumerable of lists.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="chunkedObject"></param>
    /// <returns></returns>
    IAsyncEnumerable<List<T>> GetChunkInfoDataPageAsyncEnumerable<T>(IChunkInfo<T> chunkedObject) where T : class;

    /// <summary>
    /// Get Category constants
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Constant>> GetConstantsCategories();

    /// <summary>
    /// Get Division constants
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Constant>> GetConstantsDivisions();

    /// <summary>
    /// Get EventType constants
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Constant>> GetConstantsEventTypes();

    /// <summary>
    /// Returns a Stream of a CSV file containing driver stats by Oval.
    /// </summary>
    /// <returns></returns>
    Task<Stream> GetDriverStatsByCategoryOval();

    /// <summary>
    /// Returns a Stream of a CSV file containing driver stats by Sports Car.
    /// </summary>
    /// <returns></returns>
    Task<Stream> GetDriverStatsByCategorySportsCar();

    /// <summary>
    /// Returns a Stream of a CSV file containing driver stats by Formula Car.
    /// </summary>
    /// <returns></returns>
    Task<Stream> GetDriverStatsByCategoryFormulaCar();

    /// <summary>
    /// Returns a Stream of a CSV file containing driver stats by Road.
    /// </summary>
    /// <returns></returns>
    Task<Stream> GetDriverStatsByCategoryRoad();

    /// <summary>
    /// Returns a Stream of a CSV file containing driver stats by Dirt Oval.
    /// </summary>
    /// <returns></returns>
    Task<Stream> GetDriverStatsByCategoryDirtOval();

    /// <summary>
    /// Returns a Stream of a CSV file containing driver stats by Dirt Road.
    /// </summary>
    /// <returns></returns>
    Task<Stream> GetDriverStatsByCategoryDirtRoad();

    /// <summary>
    /// Get Cust League Session Results
    /// </summary>
    /// <param name="mine">If true, return only sessions created by this user.</param>
    /// <param name="packageId">If set, return only sessions using this car or track package ID.</param>
    /// <returns></returns>
    Task<SessionResult> GetCustLeagueSessionResults(bool mine = false, int? packageId = null);

    /// <summary>
    /// Gets documentation for all available endpoints, including required and optional parameters.
    /// Each endpoint is a dictionary with the key being the endpoint name and the value being a dictionary of the endpoint details.
    /// </summary>
    /// <returns></returns>
    Task<Dictionary<string, Dictionary<string, EndpointDetails>>> GetDoc();


    /// <summary>
    /// Get hosted combined session by package id
    /// </summary>
    /// <param name="packageId"></param>
    /// <returns></returns>
    Task<SessionResult> GetHostedCombinedSession(int packageId);

    /// <summary>
    /// Get hosted combined sessions
    /// </summary>
    /// <returns></returns>
    Task<SessionResult> GetHostedCombinedSessions();

    /// <summary>
    /// Get hosted sessions
    /// </summary>
    /// <returns></returns>
    Task<SessionResult> GetHostedSessions();

    /// <summary>
    /// Get League by ID
    /// </summary>
    /// <param name="leagueId">League Id (required).</param>
    /// <param name="includeLicenses">For faster responses, only request when necessary.</param>
    /// <returns></returns>
    Task<LeagueDetailed> GetLeagueById(int leagueId, bool? includeLicenses = null);

    /// <summary>
    /// Get LeagueMembership by Customer Id
    /// </summary>
    /// <param name="customerId">If different from the authenticated member, the following restrictions apply: <para />
    /// - Caller cannot be on requested customer's block list or an empty list will result;<para />
    /// - Requested customer cannot have their online activity preference set to hidden or an empty list will result;<para />
    /// - Only leagues for which the requested customer is an admin and the league roster is not private are returned.</param>
    /// <param name="includeLeague"></param>
    /// <returns></returns>
    Task<List<LeagueMembership>> GetLeagueMembership(int customerId, bool? includeLeague = null);

    /// <summary>
    /// Returns a League's Seasons
    /// </summary>
    /// <param name="leagueId">League Id</param>
    /// <param name="retired">If true include seasons which are no longer active.</param>
    /// <returns></returns>
    Task<LeagueSeasonResult> GetLeagueSeasons(int leagueId, bool? retired = null);

    /// <summary>
    /// Get league season sessions
    /// </summary>
    /// <param name="leagueId">League Id</param>
    /// <param name="seasonId">Season Id</param>
    /// <param name="resultsOnly">If true include only sessions for which results are available.</param>
    /// <returns></returns>
    Task<LeagueSeasonSessionsResult> GetLeagueSeasonsSessions(int leagueId, int seasonId, bool? resultsOnly = null);

    /// <summary>
    /// Get League Season Standings
    /// </summary>
    /// <param name="leagueId">League Id</param>
    /// <param name="seasonId">Season Id</param>
    /// <param name="carClassId"></param>
    /// <param name="carId">If car_class_id is included then the standings are for the car in that car class, otherwise they are for the car across car classes.</param>
    /// <returns></returns>
    Task<LeagueSeasonStandingsResult> GetLeagueSeasonStandings(int leagueId, int seasonId, int? carClassId = null, int? carId = null);

    /// <summary>
    /// Get a member's data.
    /// </summary>
    /// <param name="customerIds"></param>
    /// <param name="includeLicenses"></param>
    /// <returns></returns>
    Task<MembersResult> GetMember(IEnumerable<int> customerIds, bool includeLicenses);

    /// <summary>
    /// Get Member Awards
    /// </summary>
    /// <param name="customerId">Customer Id, defaults to authenticated member.</param>
    /// <returns></returns>
    Task<MemberAwardsResponse<List<MemberAward>>> GetMemberAwards(int? customerId = null);

    /// <summary>
    /// Get instances of a specific award for a member
    /// </summary>
    /// <param name="awardId">The award ID to get instances for</param>
    /// <param name="customerId">Customer Id, defaults to the authenticated member.</param>
    /// <returns>Enhanced response containing both summary data and detailed award instances</returns>
    Task<MemberAwardsResponse<MemberAwardInstance>> GetMemberAwardInstances(int awardId, int? customerId = null);

    /// <summary>
    /// Get a member's chart data.
    /// </summary>
    /// <param name="categoryId">1 - Oval; 2 - Road; 3 - Dirt oval; 4 - Dirt road</param>
    /// <param name="chartType">"1 - iRating; 2 - TT Rating; 3 - License/SR</param>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    Task<MemberChartData> GetMemberChartData(int categoryId, int chartType, int? customerId = null);

    /// <summary>
    /// Get Member Info (Always the authenticated member.)
    /// </summary>
    /// <returns></returns>
    Task<MemberInfo> GetMemberInfo();

    /// <summary>
    /// Get Member Participation Credits (Always the authenticated member.)
    /// </summary>
    /// <returns></returns>
    Task<List<MemberParticipationCredits>> GetMemberParticipationCredits();

    /// <summary>
    /// Get Member Profile
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    Task<MemberProfile> GetMemberProfile(int? customerId = null);

    /// <summary>
    /// Get Points System By League Id and (optionally) Season Id
    /// </summary>
    /// <param name="leagueId"></param>
    /// <param name="seasonId">If included and the season is using custom points (points_system_id:2) then the custom points option is included in the returned list. Otherwise the custom points option is not returned.</param>
    /// <returns></returns>
    Task<PointsSystemResponse> GetPointsSystems(int leagueId, int? seasonId = null);

    /// <summary>
    /// Get Member Recent Results <para />
    /// Get the results of a subsession, if authorized to view them. series_logo image paths are relative to https://images-static.iracing.com/img/logos/series/
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="includeLicenses"></param>
    /// <returns></returns>
    Task<SubSessionResults> GetResults(int subSessionId, bool? includeLicenses = null);

    /// <summary>
    /// Get Result Event Logs
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="simSessionNumber">The main event is 0; the preceding event is -1, and so on.</param>
    /// <returns></returns>
    Task<ResultEventLogs> GetResultsEventLogs(int subSessionId, int simSessionNumber);

    /// <summary>
    /// Get Result LapChartData
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="simSessionNumber">The main event is 0; the preceding event is -1, and so on.</param>
    /// <returns></returns>
    Task<ResultsLapChartData> GetResultsLapChartData(int subSessionId, int simSessionNumber);

    /// <summary>
    /// Get lap data for a subsession
    /// </summary>
    /// <param name="subSessionId"></param>
    /// <param name="simSessionNumber">The main event is 0; the preceding event is -1, and so on.</param>
    /// <param name="customerId">Required if the subsession was a single-driver event. Optional for team events. If omitted for a team event then the laps driven by all the team's drivers will be included.</param>
    /// <param name="teamId">Required if the subsession was a team event.</param>
    /// <returns></returns>
    Task<ResultLapData> GetResultsLapData(int subSessionId, int simSessionNumber, int? customerId = null, int? teamId = null);

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
    Task<ResultSearchHosted> GetResultsSearchHosted(DateTimeOffset? startRangeBegin = null, DateTimeOffset? startRangeEnd = null, DateTimeOffset? finishRangeBegin = null, DateTimeOffset? finishRangeEnd = null, int? custId = null, int? teamId = null, int? hostCustId = null, string? sessionName = null, int? leagueId = null, int? leagueSeasonId = null, int? carId = null, int? trackId = null, IEnumerable<int>? categoryIds = null);

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
    Task<ResultsSearchSeries> GetResultsSearchSeries(int? seasonYear = null, int? seasonQuarter = null, DateTimeOffset? startRangeBegin = null, DateTimeOffset? startRangeEnd = null, DateTimeOffset? finishRangeBegin = null, DateTimeOffset? finishRangeEnd = null, int? customerId = null, int? teamId = null, int? seriesId = null, int? raceWeekNum = null, bool? officialOnly = null, IEnumerable<int>? eventTypes = null, IEnumerable<int>? categoryIds = null);

    /// <summary>
    /// Get Season Results
    /// </summary>
    /// <param name="seasonId">Season Id (required)</param>
    /// <param name="eventType">Restrict to one event type: 2 - Practice; 3 - Qualify; 4 - Time Trial; 5 - Race</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    Task<ResultsSeasonResults> GetResultsSeasonResults(int seasonId, int? eventType = null, int? raceWeekNum = null);

    /// <summary>
    /// Get Season List
    /// </summary>
    /// <param name="seasonYear">Required</param>
    /// <param name="seasonQuarter">Required</param>
    /// <returns></returns>
    Task<SeasonListResult> GetSeasonList(int seasonYear, int seasonQuarter);

    /// <summary>
    /// Get Season Race Guide
    /// </summary>
    /// <param name="from">ISO-8601 offset format. Defaults to the current time. Include sessions with start times up to 3 hours after this time. Times in the past will be rewritten to the current time.</param>
    /// <param name="includeEndAfterFrom">Include sessions which start before 'from' but end after.</param>
    /// <returns></returns>
    Task<SeasonRaceGuideResults> GetSeasonRaceGuide(DateTime? from = null, bool? includeEndAfterFrom = null);

    /// <summary>
    /// Get Season Spectator SubSessionIds
    /// </summary>
    /// <param name="eventTypes">Types of events to include in the search. Defaults to all.</param>
    /// <returns></returns>
    Task<SeasonSpectatorSubSessionIdsResult> GetSeasonSpectatorSubSessionIds(IEnumerable<int>? eventTypes = null);

    /// <summary>
    /// Get Season Spectator SubSessionIds Detail
    /// </summary>
    /// <param name="eventTypes">Types of events to include in the search. Defaults to all.</param>
    /// <param name="seasonIds">Season Ids.  Defaults to all.</param>
    /// <returns></returns>
    Task<SeasonSpectatorSubSessionIdsDetailResult> GetSeasonSpectatorSubSessionIdsDetail(IEnumerable<int>? eventTypes = null, IEnumerable<int>? seasonIds = null);

    /// <summary>
    /// Get Series
    /// </summary>
    /// <returns></returns>
    Task<List<SeriesResult>> GetSeries();

    /// <summary>
    /// Get Series Assets (image paths are relative to https://images-static.iracing.com/)
    /// </summary>
    /// <returns>Dictionary where key is series id and value is series asset</returns>
    Task<Dictionary<string, SeriesAsset>> GetSeriesAssets();

    /// <summary>
    /// Get all seasons for a series. Filter list by official:true for seasons with standings.
    /// </summary>
    /// <param name="seriesId">Series Id (required)</param>
    /// <returns></returns>
    Task<SeriesPastSeasonResult> GetSeriesPastSeasons(int seriesId);

    /// <summary>
    /// Get Series Seasons
    /// </summary>
    /// <param name="includeSeries"></param>
    /// <param name="seasonYear"></param>
    /// <param name="seasonQuarter"></param>
    /// <returns></returns>
    Task<List<SeriesSeasonsResult>> GetSeriesSeasons(bool? includeSeries = null, int? seasonYear = null, int? seasonQuarter = null);

    /// <summary>
    /// Get Series Season List
    /// </summary>
    /// <param name="includeSeries"></param>
    /// <param name="seasonYear"></param>
    /// <param name="seasonQuarter"></param>
    /// <returns></returns>
    Task<SeriesSeasonListResult> GetSeriesSeasonList(bool? includeSeries = null, int? seasonYear = null, int? seasonQuarter = null);

    /// <summary>
    /// Get Series Season Schedule
    /// </summary>
    /// <param name="seasonId">Required Season Id</param>
    /// <returns></returns>
    Task<SeriesSeasonScheduleResult> GetSeriesSeasonSchedule(int seasonId);

    /// <summary>
    /// Get Series Stats
    /// </summary>
    /// <returns></returns>
    Task<List<SeriesStats>> GetSeriesStats();

    /// <summary>
    /// Get Stats Member Bests
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <param name="carId">First call should exclude car_id; use cars_driven list in return for subsequent calls.</param>
    /// <returns></returns>
    Task<StatsMemberBests> GetStatsMemberBests(int? customerId = null, int? carId = null);

    /// <summary>
    /// Get Status Member Career
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    Task<StatsMemberCareer> GetStatsMemberCareer(int? customerId = null);

    /// <summary>
    /// Get Stats Member Division (Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Always for the authenticated member.)
    /// </summary>
    /// <param name="seasonId">(Required)</param>
    /// <param name="eventType">The event type code for the division type: 4 - Time Trial; 5 - Race (Required)</param>
    /// <returns></returns>
    Task<StatsMemberDivision> GetStatsMemberDivision(int seasonId, int eventType);

    /// <summary>
    /// Get Stats Member Event Results
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <param name="year">Season year; if not supplied the current calendar year (UTC) is used.</param>
    /// <param name="seasonId">Season (quarter) within the year; if not supplied the recap will be fore the entire year.</param>
    /// <returns></returns>
    Task<StatsMemberRecapResult> GetStatsMemberRecap(int? customerId = null, int? year = null, int? seasonId = null);

    /// <summary>
    /// Get Stats Member Recent Races
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    Task<StatsMemberRecentRacesResult> GetStatsMemberRecentRaces(int? customerId = null);

    /// <summary>
    /// Get Stats Member Results
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    Task<StatsMemberSummaryResult> GetStatsMemberSummary(int? customerId = null);

    /// <summary>
    /// Get Stats Member Yearly
    /// </summary>
    /// <param name="customerId">Defaults to the authenticated member.</param>
    /// <returns></returns>
    Task<StatsMemberYearlyResult> GetStatsMemberYearly(int? customerId = null);

    /// <summary>
    /// Get Stats Season Driver Standings
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    Task<StatsSeasonDriverStandingsResult> GetStatsSeasonDriverStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null);

    /// <summary>
    /// Get Stats Season Qualify Results
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0. (Required)</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <returns></returns>
    Task<StatsSeasonQualifyResults> GetStatsSeasonQualifyResults(int seasonId, int carClassId, int raceWeekNum, int? division = null);

    /// <summary>
    /// Get Stats Season Supersession Results
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    Task<StatsSeasonSuperSessionStandingsResult> GetStatsSeasonSuperSessionStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null);

    /// <summary>
    /// Get Stats Season Team Standings
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    Task<StatsSeasonTeamStandingsResult> GetStatsSeasonTeamStandings(int seasonId, int carClassId, int? raceWeekNum = null);

    /// <summary>
    /// Get Stats Season TT Results
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0. (Required)</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <returns></returns>
    Task<StatsSeasonTtResults> GetStatsSeasonTtResults(int seasonId, int carClassId, int raceWeekNum, int? division = null);

    /// <summary>
    /// Get Stats Season TT Standings
    /// </summary>
    /// <param name="seasonId">Required.</param>
    /// <param name="carClassId">Required.</param>
    /// <param name="division">Divisions are 0-based: 0 is Division 1, 10 is Rookie. See /data/constants/divisons for more information. Defaults to all.</param>
    /// <param name="raceWeekNum">The first race week of a season is 0.</param>
    /// <returns></returns>
    Task<StatsSeasonTtStandingsResult> GetStatsSeasonTtStandings(int seasonId, int carClassId, int? division = null, int? raceWeekNum = null);

    /// <summary>
    /// Get Stats World Record Results
    /// </summary>
    /// <param name="carId">Required.</param>
    /// <param name="trackId">Required.</param>
    /// <param name="seasonYear">Limit best times to a given year.</param>
    /// <param name="seasonQuarter">Limit best times to a given quarter; only applicable when year is used.</param>
    /// <returns></returns>
    Task<StatsWorldRecordResults> GetStatsWorldRecordResults(int carId, int trackId, int? seasonYear = null, int? seasonQuarter = null);

    /// <summary>
    /// Get Team by Id
    /// </summary>
    /// <param name="teamId">Required.</param>
    /// <param name="includeLicenses">For faster responses, only request when necessary.</param>
    /// <returns></returns>
    Task<TeamResult> GetTeam(int teamId, bool? includeLicenses = null);

    /// <summary>
    /// Get Team Membership (Always the authenticated member.)
    /// </summary>
    /// <returns></returns>
    Task<List<TeamMembershipResult>> GetTeamMembership();

    /// <summary>
    /// Get Time Attack Season Results
    /// </summary>
    /// <remarks>image paths are relative to https://images-static.iracing.com/</remarks>
    /// <returns></returns>
    Task<Dictionary<string, TrackDetailsResult>> GetTrackAssets();

    /// <summary>
    /// Get Tracks
    /// </summary>
    /// <remarks>image paths are relative to https://images-static.iracing.com/</remarks>
    /// <returns></returns>
    Task<List<TrackResult>> GetTracks();

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
    Task<List<LookupResult>> Lookup(Dictionary<string, string[]> lookups);

    /// <summary>
    /// Lookup Countries
    /// </summary>
    /// <returns></returns>
    Task<List<Country>> LookupCountries();

    /// <summary>
    /// Lookup Drivers
    /// </summary>
    /// <param name="searchTerm">Search Term (required)</param>
    /// <param name="leagueId">League Id</param>
    /// <returns></returns>
    Task<List<Driver>> LookupDrivers(string searchTerm, int? leagueId = null);

    /// <summary>
    /// Lookup Flairs.  Icons are from <see href="https://github.com/lipis/flag-icons/"/>
    /// </summary>
    /// <returns></returns>
    Task<LookupFlairResponse> LookupFlairs();

    /// <summary>
    /// Lookup License Levels
    /// </summary>
    /// <returns></returns>
    Task<List<LookupLicenseResult>> LookupLicenses();

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
    Task<LeagueResult> SearchLeagues(string? search = null, string? tag = null, bool? restrictToMember = null, bool? restrictToRecruiting = null, bool? restrictToFriends = null, bool? restrictToWatched = null, bool? minimumRosterCount = null, bool? maximumRosterCount = null, int? lowerBound = null, int? upperBound = null, LeagueSortValue? sort = null, SortOrder? order = null);

    /// <summary>
    /// Get Session Reg Drivers List
    /// </summary>
    /// <param name="subsessionId">Subsession Id (required)</param>
    /// <returns></returns>
    Task<SessionRegDriversListResult> GetSessionRegDriversList(int subsessionId);
}