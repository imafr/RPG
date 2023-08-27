using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos.Character;
using RPG.Services;

namespace RPG.Controllers
{
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

        [HttpGet("GetCharacterBy{id}*")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacterById(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("PostCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        
    }
}