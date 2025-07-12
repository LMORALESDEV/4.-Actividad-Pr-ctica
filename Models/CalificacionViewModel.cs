using Actividad4LengPro3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengPro3.Models
{
    [PrimaryKey("MatriculaEstudiante", "CodigoMateria", "Periodo")]
    public class CalificacionViewModel
    {
        [Required]
        [Display(Name = "Matricula")]
        public string MatriculaEstudiante { get; set; }
        [ForeignKey("MatriculaEstudiante")]
        public EstudiantesViewModel? Estudiante { get; set; }
        [Required]
        [Display(Name = "Codigo materia")]
        public string CodigoMateria { get; set; }
        [ForeignKey("CodigoMateria")]
        public MateriaViewModel? Materia { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CodigosMaterias { get; set; } = [];
        [Required]
        [Range(0, 100)]
        public int Nota { get; set; }
        [Required]
        public string Periodo { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Periodos { get; set; } = [];
    }
}
