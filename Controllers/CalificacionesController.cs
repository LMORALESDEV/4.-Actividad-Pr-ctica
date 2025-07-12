using Actividad4LengPro3.Models;
using Actividad4LengPro3.Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LengPro3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly Actividad4DbContext context;

        public CalificacionesController(Actividad4DbContext context)
        {
            this.context = context;
        }

        public ActionResult Lista()
        {
            var calificaciones = context.Calificaciones.ToList();
            return View(calificaciones);
        }

        public IActionResult Crear()
        {
            var model = new CalificacionViewModel();
            model.Periodos = ObtenerPeriodos();
            model.CodigosMaterias = ObtenerCodigosMaterias();
            return View(model);
        }

        private IEnumerable<SelectListItem> ObtenerPeriodos()
        {
            var periodos = new List<string> { "2025-1", "2025-2", "2025-3", "2026-1" };
            return periodos.Select(periodo => new SelectListItem(periodo, periodo)).ToList();
        }

        private IEnumerable<SelectListItem> ObtenerCodigosMaterias()
        {
            var materias = context.Materias.OrderBy(x => x.Codigo).ToList();
            return materias.Select(materia => new SelectListItem(materia.Codigo, materia.Codigo)).ToList();
        }

        [HttpPost]
        public IActionResult Crear(CalificacionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Periodos = ObtenerPeriodos();
                model.CodigosMaterias = ObtenerCodigosMaterias();
                return View(model);
            }

            var existeEstudiante = context.Estudiantes.Any(est => est.Matricula == model.MatriculaEstudiante);

            if (!existeEstudiante)
            {
                model.Periodos = ObtenerPeriodos();
                model.CodigosMaterias = ObtenerCodigosMaterias();
                ModelState.AddModelError(nameof(model.MatriculaEstudiante), "No existe un estudiante con esta matrícula");
                return View(model);
            }

            var existeCalificacion = context.Calificaciones.Any(cal => cal.MatriculaEstudiante == model.MatriculaEstudiante
            && cal.CodigoMateria == model.CodigoMateria && cal.Periodo == model.Periodo);

            if (existeCalificacion)
            {
                model.Periodos = ObtenerPeriodos();
                model.CodigosMaterias = ObtenerCodigosMaterias();
                ModelState.AddModelError(nameof(model.MatriculaEstudiante), "El estudiante ya tiene una calificación para esta asignatura y período");
                return View(model);
            }

            context.Add(model);
            context.SaveChanges();
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(string codigoMateria, string matriculaEstudiante, string periodo)
        {
            var model = context.Calificaciones.FirstOrDefault(cal => cal.MatriculaEstudiante == matriculaEstudiante
           && cal.CodigoMateria == codigoMateria && cal.Periodo == periodo);

            if (model == null)
                return RedirectToAction("Lista");

            model.Periodos = ObtenerPeriodos();
            model.CodigosMaterias = ObtenerCodigosMaterias();

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(CalificacionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Periodos = ObtenerPeriodos();
                model.CodigosMaterias = ObtenerCodigosMaterias();
                return View(model);
            }

            context.Update(model);
            context.SaveChanges();

            return RedirectToAction("Lista");
        }

        public ActionResult Eliminar(string codigoMateria, string matriculaEstudiante, string periodo)
        {
            var calificacion = context.Calificaciones.FirstOrDefault(cal => cal.MatriculaEstudiante == matriculaEstudiante
           && cal.CodigoMateria == codigoMateria && cal.Periodo == periodo);

            if (calificacion != null)
            {
                context.Remove(calificacion);
                context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
    }
}
