using AARCO_Examn.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AARCO_Examn.Controllers
{
    public class ModeloController :Controller
    {
        public IActionResult Index()
        {
            List<Modelo> lst = new List<Modelo>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Modelos.Select(x => new Modelo
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    IdSubmarca = x.IdSubmarca
                }).ToList();
            }
            return View(lst);
        }
        public List<Modelo> Modelos()
        {
            List<Modelo> lst = new List<Modelo>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Modelos.Select(x => new Modelo
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    IdSubmarca = x.IdSubmarca
                }).ToList();
            }
            return lst;
        }

        public List<Modelo> GetModelos(int id)
        {
            List<Modelo> lst = new List<Modelo>();
            using (var db = new Models.DB.DbAarcoExamContext())
            {
                lst = db.Modelos.Where(x => x.IdSubmarca == id).Select(x => new Modelo
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    IdSubmarca = x.IdSubmarca
                }).ToList();
            }
            return lst;
        }
    }
}
