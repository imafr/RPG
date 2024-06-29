using System.Text.Json.Serialization;

namespace RPG.WebAPI.Models
{
    /// <summary>
    /// Show enum variable Name instead of value in SWagger
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight,
        Mage = 5,
        Clerica
    }
}