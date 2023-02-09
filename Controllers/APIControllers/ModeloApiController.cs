using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AARCO_Examn.Controllers.APIControllers
{
    [Route("Modelos")]
    [ApiController]
    public class ModeloApiController : ControllerBase
    {
        ModeloController tabla = new ModeloController();

        [HttpGet]
        public async Task<ActionResult<Modelo>> GetListMarcas()
        {
            try
            {
                var result = tabla.Modelos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modelo>> GetListModelo(int id)
        {
            try
            {
                var result = tabla.GetModelos(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
