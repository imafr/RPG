using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Dtos.Character
{
    // Request DTO
    public class AddCharacterDto
    { 
        
        public string Name { get; set; } ="afridi";
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }=RpgClass.Knight;
    }
}