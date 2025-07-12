using Actividad4LengPro3.Models;
using Actividad4LengPro3.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengPro3.Controllers
{
    public class MateriasController: Controller
    {
        private readonly Actividad4DbContext context;

        public MateriasController(Actividad4DbContext context)
        {
            this.context = context;
        }

        public ActionResult Lista()
        {
            var materias = context.Materias.ToList();
            return View(materias);
        }

        public IActionResult Crear()
        {
            var modelo = new MateriaViewModel();
            modelo.Carreras = ObtenerCarreras();
            return View(modelo);
        }

        private IEnumerable<SelectListItem> ObtenerCarreras()
        {
            var carreras = new List<string> { "Contabilidad", "Ing. de Software", "Medicina" };
            return carreras.Select(carrera => new SelectListItem(carrera, carrera)).ToList();
        }


        [HttpPost]
        public IActionResult Crear(MateriaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Carreras = ObtenerCarreras();
                return View(model);
            }

            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(string codigo)
        {
            var model = context.Materias.FirstOrDefault(e => e.Codigo == codigo);
            if (model == null)
                return RedirectToAction("Lista");

            model.Carreras = ObtenerCarreras();
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(MateriaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Carreras = ObtenerCarreras();
                return View(model);
            }

            context.Update(model);
            context.SaveChanges();

            return RedirectToAction("Lista");
        }


        public ActionResult Eliminar(string codigo)
        {
            var materia = context.Materias.FirstOrDefault(e => e.Codigo == codigo);
            if (materia != null)
            {
                context.Remove(materia);
                context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
    }
}
