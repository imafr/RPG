using AutoMapper;
using RPG.Shared.Dtos.Character;
using RPG.WebAPI.Models;

namespace RPG.WebAPI;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, CharacterResponseDto>();
        CreateMap<CharacterCreateRequestDto, Character>();
        CreateMap<CharacterUpdateRequestDto, Character>();
    }
}