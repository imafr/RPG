using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG.Dtos.Character;

// Response DTO
public class CharacterResponseDto
{
    // default vallue at context of any int input is 0 ,if we not intialize
    public int Id { get; set;}
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public RpgClass Class { get; set; }
}