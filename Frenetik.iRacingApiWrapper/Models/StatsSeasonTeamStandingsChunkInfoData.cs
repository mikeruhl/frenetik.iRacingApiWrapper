﻿namespace Frenetik.iRacingApiWrapper.Models;

public class StatsSeasonTeamStandingsChunkInfoData
{
    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("cust_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("license")]
    public StatsSeasonTeamStandingsLicense License { get; set; } = new StatsSeasonTeamStandingsLicense();

    [JsonPropertyName("helmet")]
    public Helmet Helmet { get; set; } = new Helmet();

    [JsonPropertyName("weeks_counted")]
    public int WeeksCounted { get; set; }

    [JsonPropertyName("starts")]
    public int Starts { get; set; }

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("top5")]
    public int Top5 { get; set; }

    [JsonPropertyName("top25_percent")]
    public int Top25Percent { get; set; }

    [JsonPropertyName("poles")]
    public int Poles { get; set; }

    [JsonPropertyName("avg_start_position")]
    public int AverageStartPosition { get; set; }

    [JsonPropertyName("avg_finish_position")]
    public int AverageFinishPosition { get; set; }

    [JsonPropertyName("avg_field_size")]
    public int AverageFieldSize { get; set; }

    [JsonPropertyName("laps")]
    public int Laps { get; set; }

    [JsonPropertyName("laps_led")]
    public int LapsLed { get; set; }

    [JsonPropertyName("incidents")]
    public int Incidents { get; set; }

    [JsonPropertyName("points")]
    public int Points { get; set; }

    [JsonPropertyName("raw_points")]
    public double RawPoints { get; set; }

    [JsonPropertyName("week_dropped")]
    public bool WeekDropped { get; set; }
}

public class StatsSeasonTeamStandingsLicense
{
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    [JsonPropertyName("license_level")]
    public int LicenseLevel { get; set; }

    [JsonPropertyName("safety_rating")]
    public double SafetyRating { get; set; }

    [JsonPropertyName("irating")]
    public int IRating { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;

    [JsonPropertyName("group_id")]
    public int GroupId { get; set; }
}
