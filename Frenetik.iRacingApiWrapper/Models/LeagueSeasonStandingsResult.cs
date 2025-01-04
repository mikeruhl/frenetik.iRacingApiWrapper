namespace Frenetik.iRacingApiWrapper.Models;

public class LeagueSeasonStandingsResult
{
    [JsonPropertyName("car_class_id")]
    public int CarClassId { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("season_id")]
    public int SeasonId { get; set; }

    [JsonPropertyName("car_id")]
    public int CarId { get; set; }

    [JsonPropertyName("standings")]
    public StandingsResult Standings { get; set; } = new StandingsResult();

    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    public class StandingsResult
    {
        [JsonPropertyName("driver_standings")]
        public List<DriverStanding> DriverStandings { get; set; } = new List<DriverStanding>();

        [JsonPropertyName("team_standings")]
        public List<TeamStanding> TeamStandings { get; set; } = new List<TeamStanding>();
    }

    public class DriverStanding
    {
        [JsonPropertyName("rownum")]
        public int RowNumber { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("driver")]
        public Driver Driver { get; set; } = new Driver();

        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        [JsonPropertyName("driver_nickname")]
        public string DriverNickname { get; set; } = string.Empty;

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("average_start")]
        public int AverageStart { get; set; }

        [JsonPropertyName("average_finish")]
        public int AverageFinish { get; set; }

        [JsonPropertyName("base_points")]
        public int BasePoints { get; set; }

        [JsonPropertyName("negative_adjustments")]
        public int NegativeAdjustments { get; set; }

        [JsonPropertyName("positive_adjustments")]
        public int PositiveAdjustments { get; set; }

        [JsonPropertyName("total_adjustments")]
        public int TotalAdjustments { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }
    }

    public class Driver
    {
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();
    }

    public class Helmet
    {
        [JsonPropertyName("pattern")]
        public int Pattern { get; set; }

        [JsonPropertyName("color1")]
        public string Color1 { get; set; } = string.Empty;

        [JsonPropertyName("color2")]
        public string Color2 { get; set; } = string.Empty;

        [JsonPropertyName("color3")]
        public string Color3 { get; set; } = string.Empty;

        [JsonPropertyName("face_type")]
        public int FaceType { get; set; }

        [JsonPropertyName("helmet_type")]
        public int HelmetType { get; set; }
    }

    public class TeamStanding
    {
        [JsonPropertyName("rownum")]
        public int RowNumber { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("team")]
        public Team Team { get; set; } = new Team();

        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        [JsonPropertyName("driver_nickname")]
        public string DriverNickname { get; set; } = string.Empty;

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("average_start")]
        public int AverageStart { get; set; }

        [JsonPropertyName("average_finish")]
        public int AverageFinish { get; set; }

        [JsonPropertyName("base_points")]
        public int BasePoints { get; set; }

        [JsonPropertyName("negative_adjustments")]
        public int NegativeAdjustments { get; set; }

        [JsonPropertyName("positive_adjustments")]
        public int PositiveAdjustments { get; set; }

        [JsonPropertyName("total_adjustments")]
        public int TotalAdjustments { get; set; }

        [JsonPropertyName("total_points")]
        public int TotalPoints { get; set; }
    }

    public class Team
    {
        [JsonPropertyName("team_id")]
        public int TeamId { get; set; }

        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; } = string.Empty;

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; } = new Owner();
    }

    public class Owner
    {
        [JsonPropertyName("cust_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("helmet")]
        public Helmet Helmet { get; set; } = new Helmet();
    }
}


