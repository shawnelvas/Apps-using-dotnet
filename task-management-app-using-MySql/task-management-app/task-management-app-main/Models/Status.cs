using System.Text.Json.Serialization;

namespace TaskManagementApp.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        New,
        InProgress,
        Done
    }
}