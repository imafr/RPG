using AutoMapper;
using RPG.Dtos.Character;
namespace RPG.Services;

public class CharacterService : ICharacterService 
    { 
        private static List<Character> characters=new List<Character>{
            new Character{Id=0,},
            new Character{
            Name="Ashish",
            Class=RpgClass.Mage,
            },
            new Character{
                Id=2,
                Name="Salman",
                Class=RpgClass.Clerica,
            }};

    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
        {
        _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacterWithOutSchema()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data=characters.Select(c =>_mapper.Map<GetCharacterDto>(c)).ToList();  // Internely a for loop is run 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data=characters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacter(int id)
        {
            var serviceResponse=new ServiceResponse<GetCharacterDto>();
            Character character=characters.First( c => c.Id == id);
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        // Difference First vs FirstOrdefault- (i) put non existting id and execute -> 1. 500 error(Throw Exception) , 2. 204 error (throw default value ,like -> null,0). 

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse=  new ServiceResponse<GetCharacterDto>();
            var character=characters.FirstOrDefault(c => c.Id==id)!;// '!' null-forgiving operator
            serviceResponse.Data=_mapper.Map<GetCharacterDto>(character); 
            return  serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(_mapper.Map<Character>(newCharacter));

            serviceResponse.Data=characters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceResponse;
        }



    public async Task<ServiceResponse<List<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharacter){

        var serviceResponse=new ServiceResponse<List<GetCharacterDto>>();
        var character=characters.FirstOrDefault(c => c.Id == updateCharacter.Id );

        try 
        {
            if(character is null) throw new Exception($"Character with Id '{updateCharacter.Id}' not found.");

            /*character.Name=updateCharacter.Name;
                character.HitPoints=updateCharacter.HitPoints;
                character.Strength=updateCharacter.Strength;
                character.Defense=updateCharacter.Defense;
                character.Intelligence=updateCharacter.Intelligence;
                character.Class=updateCharacter.Class; */

         _mapper.Map(updateCharacter,character);   // AutoMapperProfile : Profile work with referenace variable (source,destination)           
                            /*// V/S //*/
        serviceResponse.Data=characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();  // Only Work with Types(Class) (Destination , Source)

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

            var character=characters.First(c => c.Id == id)!;

            characters.Remove(character);
        
            serviceResponse.Data=characters.Select( c => _mapper.Map<GetCharacterDto>(c)).ToList();

        }

        catch(Exception ex) {
            serviceResponse.Success=false;
            serviceResponse.Message=ex.Message;
        }
        
        return serviceResponse;
    }
}
