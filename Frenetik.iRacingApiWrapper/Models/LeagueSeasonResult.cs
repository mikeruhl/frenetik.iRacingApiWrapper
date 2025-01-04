namespace Frenetik.iRacingApiWrapper.Models;
public class LeagueSeasonResult
{
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    [JsonPropertyName("seasons")]
    public List<LeagueSeason> Seasons { get; set; } = new List<LeagueSeason>();

    public class LeagueSeason
    {
        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        [JsonPropertyName("points_system_id")]
        public int PointsSystemId { get; set; }

        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; } = string.Empty;

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("num_drops")]
        public int NumDrops { get; set; }

        [JsonPropertyName("no_drops_on_or_after_race_num")]
        public int NoDropsOnOrAfterRaceNum { get; set; }

        [JsonPropertyName("points_cars")]
        public List<PointsCar> PointsCars { get; set; } = new List<PointsCar>();

        [JsonPropertyName("driver_points_car_classes")]
        public List<DriverPointsCarClass> DriverPointsCarClasses { get; set; } = new List<DriverPointsCarClass>();

        [JsonPropertyName("team_points_car_classes")]
        public List<TeamPointsCarClass> TeamPointsCarClasses { get; set; } = new List<TeamPointsCarClass>();

        [JsonPropertyName("points_system_name")]
        public string PointsSystemName { get; set; } = string.Empty;

        [JsonPropertyName("points_system_desc")]
        public string PointsSystemDesc { get; set; } = string.Empty;

        public class PointsCar
        {
            [JsonPropertyName("car_id")]
            public int CarId { get; set; }

            [JsonPropertyName("car_name")]
            public string CarName { get; set; } = string.Empty;
        }

        public class DriverPointsCarClass
        {
            [JsonPropertyName("car_class_id")]
            public int CarClassId { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("cars_in_class")]
            public List<CarInClass> CarsInClass { get; set; } = new List<CarInClass>();

            public class CarInClass
            {
                [JsonPropertyName("car_id")]
                public int CarId { get; set; }

                [JsonPropertyName("car_name")]
                public string CarName { get; set; } = string.Empty;
            }
        }

        public class TeamPointsCarClass
        {
            [JsonPropertyName("car_class_id")]
            public int CarClassId { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            [JsonPropertyName("cars_in_class")]
            public List<CarInClass> CarsInClass { get; set; } = new List<CarInClass>();

            public class CarInClass
            {
                [JsonPropertyName("car_id")]
                public int CarId { get; set; }

                [JsonPropertyName("car_name")]
                public string CarName { get; set; } = string.Empty;
            }
        }
    }
}
