using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LengPro3.Models
{
    public class MateriaViewModel
    {
        [Key]
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Range(1, 10)]
        public int Creditos { get; set; }
        [Required]
        public string Carrera { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Carreras { get; internal set; } = [];
    }
}
