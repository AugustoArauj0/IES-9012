using System.ComponentModel.DataAnnotations;
using IES9012.CORE.Enumeraciones;

namespace IES9012.CORE.Models
{
    public class Inscripcion
    {
        public int InscripcionId { get; set; }
        public int MateriaId { get; set; }  //"MateriaId" es una Clave foranea que apunta a la tabla materia
        public int EstudianteId { get; set; } //"EstudianteId" es una Clave foranea que apunta a la tabla Estudiante

        [DisplayFormat(NullDisplayText = "Sin Calificacion")]  //Esto le da un valor default a la propiedad Calificacion
        public Nota? Nota { get; set; }
        public Materia? Materias { get; set; }
        public Estudiante? Estudiante { get; set; }
    }
}