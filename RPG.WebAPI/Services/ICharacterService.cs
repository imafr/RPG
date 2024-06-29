using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.WebAPI.Dtos.Character;
using RPG.WebAPI.Models;
namespace RPG.WebAPI.Services
{
    public interface ICharacterService
    {
        // The 'async' modifier can only be used in methods that have a body.--CS1994
        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacterWithOutSchema();
        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();

        public Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id);

        public Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

        public Task<ServiceResponse<List<GetCharacterDto>>> UpdateCharacter(int id, CharacterUpdateRequestDto updateCharacter);

        public Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id);

    }
}