using System.ComponentModel.DataAnnotations;

namespace IES9012.CORE.Models
{
    public class Materia
    {
        public int MateriaId { get; set; }
        [Required]
        [StringLength(30)]
        public string? NombreMateria { get; set; }
        public int Creditos { get; set; }  //Propiedad que contiene el porcentaje de acreditacion en las materias
        public ICollection <Inscripcion>? Inscripciones { get; set; }
    }
}