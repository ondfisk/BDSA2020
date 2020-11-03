using System.Text.Json.Serialization;

namespace Lecture09.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Female,
        Male,
        Other
    }
}
