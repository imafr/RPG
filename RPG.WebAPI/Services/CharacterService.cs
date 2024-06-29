using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.WebAPI.Models;
using RPG.WebAPI.Data;
using RPG.Shared.Dtos.Character;

namespace RPG.WebAPI.Services;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public CharacterService(IMapper mapper, DataContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacterWithOutSchema()
    {
        ServiceResponse<List<CharacterResponseDto>> serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();

        List<Character> dbCharacters = await _dataContext.Characters.ToListAsync();

        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();  // Internely a for loop is run 

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<CharacterResponseDto>>> GetAllCharacter()
    {
        var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
        var dbCharacters = await _dataContext.Characters.ToListAsync();

        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<CharacterResponseDto>> GetCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<CharacterResponseDto>();
        var dbCharacters = await _dataContext.Characters.ToListAsync();

        try
        {
            var character = _dataContext.Characters.First(c => c.Id == id);

            if (character is null) throw new Exception($"Character with {id} not found.");

            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);

        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }

    // Difference First vs FirstOrdefault- (i) put non existting id and execute -> 1. 500 error(Throw Exception) , 2. 204 error (throw default value ,like -> null,0) or 400 error. 

    public async Task<ServiceResponse<CharacterResponseDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<CharacterResponseDto>();
        var dbCharacters = await _dataContext.Characters.ToListAsync();


        // '!' null-forgiving operator
        try
        {
            var character = _dataContext.Characters.First(c => c.Id == id);

            if (character is null) throw new Exception($"Character with {id} not found.");

            serviceResponse.Data = _mapper.Map<CharacterResponseDto>(character);

        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }

    public async Task<ServiceResponse<List<CharacterResponseDto>>> AddCharacter(CharacterCreateRequestDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
        var character = _mapper.Map<Character>(newCharacter);

        _dataContext.Characters.Add(character);
        await _dataContext.SaveChangesAsync();

        serviceResponse.Data = await _dataContext.Characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();

        return serviceResponse;
    }



    public async Task<ServiceResponse<List<CharacterResponseDto>>> UpdateCharacter(int id, CharacterUpdateRequestDto updateCharacter)
    {

        var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();
        var character = _dataContext.Characters.FirstOrDefault(c => c.Id == id);

        try
        {
            if (character is null) throw new Exception($"Character with Id '{id}' not found.");

            /*  character.Name=updateCharacter.Name;
                character.HitPoints=updateCharacter.HitPoints;
                character.Strength=updateCharacter.Strength;
                character.Defense=updateCharacter.Defense;
                character.Intelligence=updateCharacter.Intelligence;
                character.Class=updateCharacter.Class; */

            _mapper.Map(updateCharacter, character);   // AutoMapperProfile : Profile work with referenace variable (source,destination)           
            /*// V/S //*/
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();  // Only Work with Types(Class) (Destination , Source)

        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<CharacterResponseDto>>> DeleteCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<List<CharacterResponseDto>>();


        try
        {

            var character = _dataContext.Characters.First(c => c.Id == id);

            if (character is null) throw new Exception($"Character with {id} not found.");

            _dataContext.Characters.Remove(character);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.Characters.Select(c => _mapper.Map<CharacterResponseDto>(c)).ToListAsync();

        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}
