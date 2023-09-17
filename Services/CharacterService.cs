using AutoMapper;
using RPG.Dtos.Character;
using  RPG.Data;
using Microsoft.EntityFrameworkCore;

namespace RPG.Services;

public class CharacterService : ICharacterService 
    { 
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

    public CharacterService(IMapper mapper, DataContext dataContext)
        {
        _mapper = mapper;
        _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacterWithOutSchema()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse=new ServiceResponse<List<GetCharacterDto>>();

            List<Character> dbCharacters = await _dataContext.Characters.ToListAsync();

            serviceResponse.Data = dbCharacters.Select(c =>_mapper.Map<GetCharacterDto>(c)).ToList();  // Internely a for loop is run 

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();

            serviceResponse.Data=dbCharacters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDto>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();

            try
        {
            var character = _dataContext.Characters.First(c => c.Id == id);

            if (character is null) throw new Exception($"Character with {id} not found.");

             serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);

        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

        }

        // Difference First vs FirstOrdefault- (i) put non existting id and execute -> 1. 500 error(Throw Exception) , 2. 204 error (throw default value ,like -> null,0) or 400 error. 

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDto>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();


        // '!' null-forgiving operator
        try
        {
            var character = _dataContext.Characters.First(c => c.Id == id);

            if (character is null) throw new Exception($"Character with {id} not found.");

             serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);

        }

        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
        
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);

           _dataContext.Characters.Add(character);
           await _dataContext.SaveChangesAsync();

            serviceResponse.Data= await _dataContext.Characters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();

            return serviceResponse;
        }



    public async Task<ServiceResponse<List<GetCharacterDto>>> UpdateCharacter(int id,UpdateCharacterDto updateCharacter){

        var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
        var character=_dataContext.Characters.FirstOrDefault(c => c.Id == id );

        try 
        {
            if(character is null) throw new Exception($"Character with Id '{id}' not found.");

            /*  character.Name=updateCharacter.Name;
                character.HitPoints=updateCharacter.HitPoints;
                character.Strength=updateCharacter.Strength;
                character.Defense=updateCharacter.Defense;
                character.Intelligence=updateCharacter.Intelligence;
                character.Class=updateCharacter.Class; */

         _mapper.Map(updateCharacter,character);   // AutoMapperProfile : Profile work with referenace variable (source,destination)           
                            /*// V/S //*/
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data= await _dataContext.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();  // Only Work with Types(Class) (Destination , Source)

        }

        catch(Exception ex){ 
            serviceResponse.Success=false;
            serviceResponse.Message=ex.Message;
        }

        return serviceResponse;
    }
    
    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id)
    {   
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        

        try{

            var character=_dataContext.Characters.First(c => c.Id == id);

            if(character is null) throw new Exception($"Character with {id} not found.");

            _dataContext.Characters.Remove(character);
            await _dataContext.SaveChangesAsync();
        
            serviceResponse.Data=await _dataContext.Characters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();

        }

        catch(Exception ex) {
            serviceResponse.Success=false;
            serviceResponse.Message=ex.Message;
        }
        
        return serviceResponse;
    }
}
