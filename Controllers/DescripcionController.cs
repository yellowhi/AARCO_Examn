using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;

namespace AARCO_Examn.Controllers
{
    public class DescripcionController : Controller
    {
        public IActionResult Index()
        {
            List<Descripcion> lst = new List<Descripcion>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Descripcions.Select(x => new Descripcion
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    DescriptionId = x.DescripcionId,
                    IdModelo = x.IdModelo
                }).ToList();
            }
            return View(lst);
        }
        public List<Descripcion> Descripcions()
        {
            List<Descripcion> lst = new List<Descripcion>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Descripcions.Select(x => new Descripcion
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    DescriptionId = x.DescripcionId,
                    IdModelo = x.IdModelo
                }).ToList();
            }
            return lst;
        }
        public List<Descripcion> GetDescripcions(int id)
        {
            List<Descripcion> lst = new List<Descripcion>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Descripcions.Where(x => x.IdModelo == id).Select(x => new Descripcion
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    DescriptionId = x.DescripcionId,
                    IdModelo = x.IdModelo
                }).ToList();
            }
            return lst;
        }
    }
}
