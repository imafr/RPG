using Microsoft.AspNetCore.Mvc;
using RPG.Dtos.Character;
using RPG.Services;

namespace RPG.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService=characterService;
        }

        [HttpGet("GetAllCharacterWithoutSchema")]
        public async Task<IActionResult> GetAllCharacterWithOutSchema(){

            return Ok(await _characterService.GetAllCharacterWithOutSchema());
        }

     // ActionResult used for holding schema
     // IAction result can't hold schema
     // See the difference at the bottom after executing in Swagger

        [HttpGet("GetAllCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacter(){
            return Ok(await _characterService.GetAllCharacter());
        }
        
        // if submit blank take '0'(int) as input
        [HttpGet("GetCharacterbyId")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id){
            return Ok(await _characterService.GetCharacter(id));
        }

    // Difference First vs FirstOrdefault- (i) put non existting id and execute -> 1. 500 error(Throw Exception) , 2. 204 error (throw default value ,like -> null,0). 

        [HttpGet("GetCharacterBy{Id}*")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("PostCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        
        [HttpPut("PutCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var response  = await _characterService.UpdateCharacter(updateCharacter);

            if(response.Data is null)
                return NotFound(response);
              
            
            return Ok(response);
        }

        [HttpDelete("DeleteCharacterById")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacterById(int id){

            var response =  await _characterService.DeleteCharacterById(id);
            
            if(response.Data is null) return NotFound(response);
            
            return Ok(response);
        }
}