namespace Frenetik.iRacingApiWrapper.Models;

public class League
{
    [JsonPropertyName("league_id")]
    public int LeagueId { get; set; }

    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    [JsonPropertyName("league_name")]
    public string LeagueName { get; set; } = string.Empty;

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("roster_count")]
    public int RosterCount { get; set; }

    [JsonPropertyName("recruiting")]
    public bool Recruiting { get; set; }

    [JsonPropertyName("is_admin")]
    public bool IsAdmin { get; set; }

    [JsonPropertyName("is_member")]
    public bool IsMember { get; set; }

    [JsonPropertyName("pending_application")]
    public bool PendingApplication { get; set; }

    [JsonPropertyName("pending_invitation")]
    public bool PendingInvitation { get; set; }

    [JsonPropertyName("owner")]
    public OwnerResult Owner { get; set; } = new OwnerResult();

    public class OwnerResult
    {
        [JsonPropertyName("cust_id")]
        public int CustId { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("helmet")]
        public HelmetResult Helmet { get; set; } = new HelmetResult();

        [JsonPropertyName("car_number")]
        public string CarNumber { get; set; } = string.Empty;

        [JsonPropertyName("nick_name")]
        public string NickName { get; set; } = string.Empty;
    }

    public class HelmetResult
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
}


