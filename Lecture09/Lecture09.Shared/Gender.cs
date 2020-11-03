using System.Text.Json.Serialization;

namespace Lecture09.Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Female,
        Male,
        Other
    }
}
