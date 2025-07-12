using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengPro3.Models
{
    public class EstudiantesViewModel
    {
        [Required(ErrorMessage ="El nombre del estudiante es obligatorio.")]
        [StringLength(100)]
        [Display(Name ="Nombre Completo")]

        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La matricula del estudiante es obligatoria.")]
        [StringLength(15, MinimumLength = 6)]
        [Display(Name = "Matricula")]
        [Key]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "La carrera del estudiante es obligatoria.")]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Carreras { get; set; } = [];

        [Required(ErrorMessage = "El correo del estudiante es obligatorio.")]
        [EmailAddress]
        [Display(Name = "Correo Institucional")]
        public string CorreoInstitucional { get; set; }

        [Phone(ErrorMessage = "El telefono del estudiante es obligatorio.")]
        [MinLength(10)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "la fecha del estudiante es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El genero del estudiante es obligatorio.")]
        [Display(Name = "Genero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El turno del estudiante es obligatorio.")]
        [Display(Name = "Turno")]
        public string Turno { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Turnos { get; internal set; } = [];

        [Required(ErrorMessage = "El tipo de ingreso del estudiante es obligatorio.")]
        [Display(Name = "Tipo de Ingreso")]
        public string TipoIngreso { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> TiposIngresos { get; internal set; } = [];

        [Display(Name = "¿Está becado?")]
        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "Debe estar entre 0 y 100")]
        [Display(Name = "Porcentaje de Beca")]
        public int? PorcentajeBeca { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos.")]
        [Display(Name = "Terminos & Condiciones")]
        public bool TerminosYCondiciones { get; set; }
     
    }
}
