
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")] //we can also use api/[controller]
    [ApiController]
    public class VillaAPIController: ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {

            return Ok(VillaStore.villaList) ;


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("{id:int}")]
        public ActionResult<VillaDTO> GetVillaAsync(int id)
        {         
            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
            if(id <= 0)
            {
                return BadRequest("Incorrect ID");
            }
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

 
    }
}
