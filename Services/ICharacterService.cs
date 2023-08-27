using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Dtos.Character;
namespace RPG.Services
{
    public interface ICharacterService
    {
    // The 'async' modifier can only be used in methods that have a body.--CS1994
        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacterWithOutSchema();
        public Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        public Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id);
        public Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        public Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        
    }
}