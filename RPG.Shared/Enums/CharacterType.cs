using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RPG.Shared.Enums;


[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CharacterType
{
    [EnumMember(Value = "Knight")]
    Knight,

    [EnumMember(Value = "Mage")]
    Mage,

    [EnumMember(Value = "Clerica")]
    Clerica,
}