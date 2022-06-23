namespace IES9012.CORE.Enumeraciones;

//Un "enum" es algo que asocia un texto a un valor numerico, para una comprension facilitada
//En la base de datos se guardan los valores numericos asociados al texto, que se mostrara en la UI
public enum Nota
{
    Mal = 0,
    Deficiente = 20,
    Regular = 40,
    Bien = 60,
    MuyBien = 80,
    Sobresaliente = 100
}
