namespace Frenetik.iRacingApiWrapper.Models;
/// <summary>
/// LeagueSeasonResult
/// </summary>
public class LeagueSeasonResult
{
    /// <summary>
    /// Subscribed
    /// </summary>
    [JsonPropertyName("subscribed")]
    public bool Subscribed { get; set; }

    /// <summary>
    /// Success
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// League Id
    /// </summary>
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    /// <summary>
    /// Seasons
    /// </summary>
    [JsonPropertyName("seasons")]
    public List<LeagueSeason> Seasons { get; set; } = new List<LeagueSeason>();

    /// <summary>
    /// LeagueSeason
    /// </summary>
    public class LeagueSeason
    {
        /// <summary>
        /// League Id
        /// </summary>
        [JsonPropertyName("league_id")]
        public int LeagueId { get; set; }

        /// <summary>
        /// Season Id
        /// </summary>
        [JsonPropertyName("season_id")]
        public int SeasonId { get; set; }

        /// <summary>
        /// Points System Id
        /// </summary>
        [JsonPropertyName("points_system_id")]
        public int PointsSystemId { get; set; }

        /// <summary>
        /// Season Name
        /// </summary>
        [JsonPropertyName("season_name")]
        public string SeasonName { get; set; } = string.Empty;

        /// <summary>
        /// Active
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Hidden
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// Num Drops
        /// </summary>
        [JsonPropertyName("num_drops")]
        public int NumDrops { get; set; }

        /// <summary>
        /// No Drops On Or After Race Num
        /// </summary>
        [JsonPropertyName("no_drops_on_or_after_race_num")]
        public int NoDropsOnOrAfterRaceNum { get; set; }

        /// <summary>
        /// Points Cars
        /// </summary>
        [JsonPropertyName("points_cars")]
        public List<PointsCar> PointsCars { get; set; } = new List<PointsCar>();

        /// <summary>
        /// Driver Points Car Classes
        /// </summary>
        [JsonPropertyName("driver_points_car_classes")]
        public List<DriverPointsCarClass> DriverPointsCarClasses { get; set; } = new List<DriverPointsCarClass>();

        /// <summary>
        /// Team Points Car Classes
        /// </summary>
        [JsonPropertyName("team_points_car_classes")]
        public List<TeamPointsCarClass> TeamPointsCarClasses { get; set; } = new List<TeamPointsCarClass>();

        /// <summary>
        /// Points System Name
        /// </summary>
        [JsonPropertyName("points_system_name")]
        public string PointsSystemName { get; set; } = string.Empty;

        /// <summary>
        /// Points System Desc
        /// </summary>
        [JsonPropertyName("points_system_desc")]
        public string PointsSystemDesc { get; set; } = string.Empty;

        /// <summary>
        /// PointsCar
        /// </summary>
        public class PointsCar
        {
            /// <summary>
            /// Car Id
            /// </summary>
            [JsonPropertyName("car_id")]
            public int CarId { get; set; }

            /// <summary>
            /// Car Name
            /// </summary>
            [JsonPropertyName("car_name")]
            public string CarName { get; set; } = string.Empty;
        }

        /// <summary>
        /// DriverPointsCarClass
        /// </summary>
        public class DriverPointsCarClass
        {
            /// <summary>
            /// Car Class Id
            /// </summary>
            [JsonPropertyName("car_class_id")]
            public int CarClassId { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Cars In Class
            /// </summary>
            [JsonPropertyName("cars_in_class")]
            public List<CarInClass> CarsInClass { get; set; } = new List<CarInClass>();

            /// <summary>
            /// CarInClass
            /// </summary>
            public class CarInClass
            {
                /// <summary>
                /// Car Id
                /// </summary>
                [JsonPropertyName("car_id")]
                public int CarId { get; set; }

                /// <summary>
                /// Car Name
                /// </summary>
                [JsonPropertyName("car_name")]
                public string CarName { get; set; } = string.Empty;
            }
        }

        /// <summary>
        /// TeamPointsCarClass
        /// </summary>
        public class TeamPointsCarClass
        {
            /// <summary>
            /// Car Class Id
            /// </summary>
            [JsonPropertyName("car_class_id")]
            public int CarClassId { get; set; }

            /// <summary>
            /// Name
            /// </summary>
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Cars In Class
            /// </summary>
            [JsonPropertyName("cars_in_class")]
            public List<CarInClass> CarsInClass { get; set; } = new List<CarInClass>();

            /// <summary>
            /// CarInClass
            /// </summary>
            public class CarInClass
            {
                /// <summary>
                /// Car Id
                /// </summary>
                [JsonPropertyName("car_id")]
                public int CarId { get; set; }

                /// <summary>
                /// Car Name
                /// </summary>
                [JsonPropertyName("car_name")]
                public string CarName { get; set; } = string.Empty;
            }
        }
    }
}

