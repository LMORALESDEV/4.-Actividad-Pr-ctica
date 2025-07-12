using Actividad4LengPro3.Models;
using Actividad4LengPro3.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengPro3.Controllers
{
    public class EstudiantesController : Controller
    {
        public EstudiantesController(Actividad4DbContext context)
        {
            this.context = context;
        }

        private readonly Actividad4DbContext context;

        public ActionResult Lista()
        {
            var estudiantes = context.Estudiantes.ToList();
            return View(estudiantes);
        }

        public IActionResult Registrar()
        {
            var modelo = new EstudiantesViewModel();
            modelo.Carreras = ObtenerCarreras();
            modelo.Turnos = ObtenerTurnos();
            modelo.TiposIngresos = ObtenerTiposIngresos();
            return View(modelo);
        }

        private IEnumerable<SelectListItem> ObtenerCarreras()
        {
            var carreras = new List<string> { "Contabilidad", "Ing. de Software", "Medicina" };
            return carreras.Select(carrera => new SelectListItem(carrera, carrera)).ToList();
        }

        private IEnumerable<SelectListItem> ObtenerTurnos()
        {
            var turnos = new List<string> { "Mañana", "Tarde", "Noche" };
            return turnos.Select(turno => new SelectListItem(turno, turno)).ToList();
        }

        private IEnumerable<SelectListItem> ObtenerTiposIngresos()
        {
            var tiposIngresos = new List<string> { "0 a 20 mil", "20,001 a 40,000", "40,001+" };
            return tiposIngresos.Select(tipoIngreso => new SelectListItem(tipoIngreso, tipoIngreso)).ToList();
        }

        [HttpPost]
        public IActionResult Registrar(EstudiantesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Carreras = ObtenerCarreras();
                model.Turnos = ObtenerTurnos();
                model.TiposIngresos = ObtenerTiposIngresos();
                return View(model);
            }

            var existeMatricula = context.Estudiantes.Any(est => est.Matricula == model.Matricula);

            if (existeMatricula)
            {
                model.Carreras = ObtenerCarreras();
                model.Turnos = ObtenerTurnos();
                model.TiposIngresos = ObtenerTiposIngresos();
                ModelState.AddModelError(nameof(model.Matricula), "Ya existe un estudiante con esta matrícula");
                return View(model);
            }

            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(string matricula)
        {
            var model = context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (model == null)
                return RedirectToAction("Lista");

            model.Carreras = ObtenerCarreras();
            model.Turnos = ObtenerTurnos();
            model.TiposIngresos = ObtenerTiposIngresos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EstudiantesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Carreras = ObtenerCarreras();
                model.Turnos = ObtenerTurnos();
                model.TiposIngresos = ObtenerTiposIngresos();
                return View(model);
            }

            context.Update(model);
            context.SaveChanges();

            return RedirectToAction("Lista");
        }

        public ActionResult Eliminar(string matricula)
        {
            var estudiante = context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                context.Remove(estudiante);
                context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
    }


}

