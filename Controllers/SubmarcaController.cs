using AARCO_Examn.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace AARCO_Examn.Controllers
{
    public class SubmarcaController : Controller
    {
        public IActionResult Index()
        {
            List<Submarca> lst = new List<Submarca>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Submarcas.Select(x => new Submarca
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    IdMarca = x.IdMarca
                }).ToList();
            }
            return View(lst);
        }

        public List<Submarca> Submarcas()
        {
            List<Submarca> lst = new List<Submarca>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Submarcas.Select(x => new Submarca
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    IdMarca = x.IdMarca
                }).ToList();
            }
            return lst;
        }

        public List<Submarca> GetSubmarcas(int id)
        {
            List<Submarca> lst = new List<Submarca>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Submarcas.Where(x => x.IdMarca == id).Select(x => new Submarca
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    IdMarca = x.IdMarca
                }).ToList();
            }
            return lst;
        }
    }
}
