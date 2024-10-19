public class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }
}
