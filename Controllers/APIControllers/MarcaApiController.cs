using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AARCO_Examn.Controllers.APIControllers
{
    [Route("Marcas")]
    [ApiController]
    public class MarcaApiController : ControllerBase
    {
        MarcaController tabla = new MarcaController();
        [HttpGet]
        public async Task<ActionResult<Marca>> GetListMarcas()
        {
            try
            {
                var result = tabla.Marcas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetListMarcas(int id)
        {
            try
            {
                var result = tabla.GetMarca(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
