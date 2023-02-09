using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AARCO_Examn.Controllers
{
    public class MarcaController : Controller
    {
        public IActionResult Index()
        {
            List<Marca> lst = new List<Marca>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Marcas.Select(x => new Marca
                {
                    Id= x.Id,
                    Nombre =x.Nombre
                }).ToList();
            }
            return View(lst);
        }

        public List<Marca> Marcas()
        {
            List<Marca> lst = new List<Marca>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Marcas.Select(x => new Marca
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).ToList();
            }
            return lst;
        }

        public Marca GetMarca(int id)
        {
            Marca lst = new Marca();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Marcas.Where(x => x.Id == id).Select(x => new Marca
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).FirstOrDefault();
            }
            return lst;
        }
    }
}
