using RPG.Shared.Enums;

namespace RPG.Shared.Dtos.Character
{
    public class CharacterUpdateRequestDto
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public CharacterType CharacterType { get; set; }
    }
}