using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.WebAPI.Models
{
    public class Character
    {
        // default vallue at context of any int input is 0 ,if we not intialize
        public int Id { get; set; }// but here 1 is not default value it is intial value
        public string Name { get; set; } = "Afridi";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}