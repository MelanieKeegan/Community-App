using System.Text.Json.Serialization;

namespace CommunityAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        Member
    }
}
