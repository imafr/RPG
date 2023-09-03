using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Dtos.Character
{
    public class UpdateCharacterDto
    {
         public int Id { get; set;}
         public string Name { get; set; }="Afridi";
        public int HitPoints { get; set; }=100;
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }=RpgClass.Knight;
    }
}