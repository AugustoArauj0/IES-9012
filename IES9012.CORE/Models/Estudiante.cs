using System.ComponentModel.DataAnnotations;

namespace IES9012.CORE.Models

{
    public class Estudiante
    {
        //La propiedad ID se convierte en la columna de clave principal de la base de datos
        public int EstudianteId { get; set; }
        [Required]  //En la base de datos no se aceptaran valores nulos con [Required]
        [StringLength(50)]  //Esto en la base de datos sera varchar(45) con 45 caracteres como maximo
        public string? Nombre { get; set; }
        [Required]
        [StringLength(35)]
        public string? Apellido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        //La propiedad Inscripcion es una propiedad de navegacion (para visualizar las materias en las que el alumno se haya inscripto
        public DateTime FechaInscripcion { get; set; } = DateTime.Now;  //"DateTime.Now" usa la fecha actual x defecto
        public ICollection <Inscripcion>? Inscripciones { get; set; }  //"ICollection" es una interfaz que arma una conexion de objeto (un tipo de dato que contiene otros tipos de datos)
    }
}
