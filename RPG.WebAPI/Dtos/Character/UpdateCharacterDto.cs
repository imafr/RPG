using RPG.WebAPI.Models;

namespace RPG.WebAPI.Dtos.Character
{
    public class CharacterUpdateRequestDto
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }
    }
}