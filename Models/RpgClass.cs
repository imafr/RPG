using System.Text.Json.Serialization;

namespace RPG.Models
{
    /// <summary>
    /// Show enum variable Name instead of value in SWagger
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight=1,
        Mage=2,
        Cleric=3
    }
}