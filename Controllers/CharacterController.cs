using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters=new List<Character>{
            new Character(),
            new Character{
                Name="Salman",
                Class=RpgClass.Clerica,
            }
        };

        [HttpGet(Name ="GetCharacter")]
        public ActionResult<Character> Get(){
            return Ok(characters);
        }
    }
}