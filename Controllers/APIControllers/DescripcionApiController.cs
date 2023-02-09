using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AARCO_Examn.Controllers.APIControllers
{
    [Route("Descripcions")]
    [ApiController]
    public class DescripcionApiController :ControllerBase
    {
        DescripcionController tabla = new DescripcionController();

        [HttpGet]
        public async Task<ActionResult<Descripcion>> GetListMarcas()
        {
            try
            {
                var result = tabla.Descripcions();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetDescripcionsOfModels(int id)
        {
            try
            {
                var result = tabla.GetDescripcions(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
