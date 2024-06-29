using RPG.Shared.Enums;

namespace RPG.Shared.Dtos.Character;

// Request DTO
public class CharacterCreateRequestDto
{     
    public string Name { get; set; } 
    public int HitPoints { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public CharacterType CharacterType { get; set; }
}