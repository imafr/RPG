using RPG.Shared.Dtos.Character;
using RPG.WebAPI.Models;
namespace RPG.WebAPI.Services;

public interface ICharacterService
{
    // The 'async' modifier can only be used in methods that have a body.--CS1994
    public Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacterWithOutSchema();
    public Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacter();

    public Task<ServiceResponse<CharacterResponseDto>> GetCharacter(int id);

    public Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id);

    public Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterCreateRequestDto newCharacter);

    public Task<ServiceResponse<List<CharacterResponseDto>>> UpdateCharacter(int id, CharacterUpdateRequestDto updateCharacter);

    public Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacterById(int id);

}