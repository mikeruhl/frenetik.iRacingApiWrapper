namespace Frenetik.iRacingApiWrapper.Models;

/// <summary>
/// LeagueSeasonStandingsResult
/// </summary>
public class LeagueSeasonStandingsResult
{
    /// <summary>
    /// Car Class Id
    /// </summary>
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Season Id
    /// </summary>
    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    /// <summary>
    /// Car Id
    /// </summary>
    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    /// <summary>
    /// Standings
    /// </summary>
    [JsonPropertyName("standings")]
    public StandingsResult Standings { get; set; } = new StandingsResult();

    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// StandingsResult
    /// </summary>
    public class StandingsResult
    {
        /// <summary>
        /// Driver Standings
        /// </summary>
        [JsonPropertyName("driver_standings")]
        public List<DriverStanding> DriverStandings { get; set; } = new List<DriverStanding>();

        /// <summary>
        /// Team Standings
        /// </summary>
        [JsonPropertyName("team_standings")]
        public List<TeamStanding> TeamStandings { get; set; } = new List<TeamStanding>();
    }

    /// <summary>
    /// DriverStanding
    /// </summary>
    public class DriverStanding
    {
        /// <summary>
        /// Rownum
        /// </summary>
        [JsonPropertyName("rownum")]
        public int RowNumber { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// Driver
        /// </summary>
        [JsonPropertyName("driver")]
        public Driver Driver { get; set; } = new Driver();

        /// <summary>
        /// Car Number
        /// </summary>
        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        /// <summary>
        /// Driver Nickname
        /// </summary>
        [JsonPropertyName("driver_nickname")]
        public string DriverNickname { get; set; } = string.Empty;

        /// <summary>
        /// Wins
        /// </summary>
        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// Average Start
        /// </summary>
        [JsonPropertyName("average_start")]
        public int AverageStart { get; set; }

        /// <summary>
        /// Average Finish
        /// </summary>
        [JsonPropertyName("average_finish")]
        public int AverageFinish { get; set; }

        /// <summary>
        /// Base Points
        /// </summary>
        [JsonPropertyName("base_points")]
        public int BasePoints { get; set; }

        /// <summary>
        /// Negative Adjustments
        /// </summary>
        [JsonPropertyName("negative_adjustments")]
        public int NegativeAdjustments { get; set; }

        /// <summary>
        /// Positive Adjustments
        /// </summary>
        [JsonPropertyName("positive_adjustments")]
        public int PositiveAdjustments { get; set; }

        /// <summary>
        /// Total Adjustments
        /// </summary>
        [JsonPropertyName("total_adjustments")]
        public int TotalAdjustments { get; set; }

        /// <summary>
        /// Total Points
        /// </summary>
        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }
    }

    /// <summary>
    /// Driver
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Helmet
        /// </summary>
        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();
    }

    /// <summary>
    /// Helmet
    /// </summary>
    public class Helmet
    {
        /// <summary>
        /// Pattern
        /// </summary>
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        /// <summary>
        /// Color1
        /// </summary>
        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        /// <summary>
        /// Color2
        /// </summary>
        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        /// <summary>
        /// Color3
        /// </summary>
        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        /// <summary>
        /// Face Type
        /// </summary>
        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        /// <summary>
        /// Helmet Type
        /// </summary>
        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }

    /// <summary>
    /// TeamStanding
    /// </summary>
    public class TeamStanding
    {
        /// <summary>
        /// Rownum
        /// </summary>
        [JsonPropertyName("rownum")]
        public int RowNumber { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [JsonPropertyName("position")]
        public int Position { get; set; }

        /// <summary>
        /// Team
        /// </summary>
        [JsonPropertyName("team")]
        public Team Team { get; set; } = new Team();

        /// <summary>
        /// Car Number
        /// </summary>
        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        /// <summary>
        /// Driver Nickname
        /// </summary>
        [JsonPropertyName("driver_nickname")]
        public string DriverNickname { get; set; } = string.Empty;

        /// <summary>
        /// Wins
        /// </summary>
        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// Average Start
        /// </summary>
        [JsonPropertyName("average_start")]
        public int AverageStart { get; set; }

        /// <summary>
        /// Average Finish
        /// </summary>
        [JsonPropertyName("average_finish")]
        public int AverageFinish { get; set; }

        /// <summary>
        /// Base Points
        /// </summary>
        [JsonPropertyName("base_points")]
        public int BasePoints { get; set; }

        /// <summary>
        /// Negative Adjustments
        /// </summary>
        [JsonPropertyName("negative_adjustments")]
        public int NegativeAdjustments { get; set; }

        /// <summary>
        /// Positive Adjustments
        /// </summary>
        [JsonPropertyName("positive_adjustments")]
        public int PositiveAdjustments { get; set; }

        /// <summary>
        /// Total Adjustments
        /// </summary>
        [JsonPropertyName("total_adjustments")]
        public int TotalAdjustments { get; set; }

        /// <summary>
        /// Total Points
        /// </summary>
        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }
    }

    /// <summary>
    /// Team
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Team Id
        /// </summary>
        [JsonPropertyName("team_id")]
        public int TeamId { get; set; }

        /// <summary>
        /// Owner Id
        /// </summary>
        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        /// Team Name
        /// </summary>
        [JsonPropertyName("team_name")]
        public string TeamName { get; set; } = string.Empty;

        /// <summary>
        /// Owner
        /// </summary>
        [JsonPropertyName("owner")]
        public Owner Owner { get; set; } = new Owner();
    }

    /// <summary>
    /// Owner
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Display Name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Helmet
        /// </summary>
        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();
    }
}



