using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AARCO_Examn.Controllers.APIControllers
{
    [Route("Submarcas")]
    [ApiController]
    public class SubmarcaApiController : ControllerBase
    {
        SubmarcaController tabla = new SubmarcaController();

        [HttpGet]
        public async Task<ActionResult<SubMarca>> GetListMarcas()
        {
            try
            {
                var result = tabla.Submarcas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetSubmarcasOfMarca(int id)
        {
            try
            {
                var result = tabla.GetSubmarcas(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
