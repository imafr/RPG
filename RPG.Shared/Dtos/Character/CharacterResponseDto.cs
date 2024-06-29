using System;
namespace RPG.Shared.Dtos.Character;

public class CharacterResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public string CharacterType { get; set; }
}