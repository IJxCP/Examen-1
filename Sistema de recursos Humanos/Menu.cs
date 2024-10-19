using System;
using System.Collections.Generic;
using System.Linq;

public class Menu
{
    //  Variable global.
    private List<Empleado> empleados = new List<Empleado>();

    
    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("Bienvenido al menú principal de recursos Humanos");
            Console.WriteLine("1. Agregar Empleado");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleado");
            Console.WriteLine("4. Borrar Empleado");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleados();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    BorrarEmpleado();
                    break;
                case 5:
                    InicializarArreglos();
                    break;
                case 6:
                    MostrarReportes();
                    break;
                case 7:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 7);
    }

    
    public void AgregarEmpleado()
    {
        Console.Write("Ingrese la cédula: ");
        string cedula = Console.ReadLine();

        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la dirección: ");
        string direccion = Console.ReadLine();

        Console.Write("Ingrese el teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Ingrese el salario: ");
        decimal salario = decimal.Parse(Console.ReadLine());

        Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
        empleados.Add(nuevoEmpleado);
        Console.WriteLine("Empleado agregado correctamente.");
    }

    
    public void ConsultarEmpleados()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
        }
        else
        {
            foreach (var emp in empleados)
            {
                Console.WriteLine($"Cédula: {emp.Cedula}, Nombre: {emp.Nombre}, Dirección: {emp.Direccion}, Teléfono: {emp.Telefono}, Salario: {emp.Salario}");
            }
        }
    }

    // Modificar los datos  por su cédula
    public void ModificarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();

        Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

        if (empleado != null)
        {
            Console.Write("Ingrese el nuevo nombre: ");
            empleado.Nombre = Console.ReadLine();

            Console.Write("Ingrese la nueva dirección: ");
            empleado.Direccion = Console.ReadLine();

            Console.Write("Ingrese el nuevo teléfono: ");
            empleado.Telefono = Console.ReadLine();

            Console.Write("Ingrese el nuevo salario: ");
            empleado.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Empleado modificado correctamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    // Borrar un empleado de nuevo por su cédula
    public void BorrarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();

        Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

        if (empleado != null)
        {
            empleados.Remove(empleado);
            Console.WriteLine("Empleado borrado correctamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    // Inicializar arreglos (Limpiar la lista de los empleados )
    public void InicializarArreglos()
    {
        empleados.Clear();
        Console.WriteLine("Arreglos inicializados (lista de empleados vaciada).");
    }

    
    public void MostrarReportes()
    {
        int opcion;

        Console.WriteLine("Menú de Reportes");
        Console.WriteLine("1. Listar empleados por nombre");
        Console.WriteLine("2. Promedio de salarios");
        Console.Write("Seleccione una opción: ");
        opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                ListarEmpleadosPorNombre();
                break;
            case 2:
                MostrarPromedioSalarios();
                break;
            default:
                Console.WriteLine("Opción inválida.");
                break;
        }
    }

    
    public void ListarEmpleadosPorNombre()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
        }
        else
        {
            var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
            foreach (var emp in empleadosOrdenados)
            {
                Console.WriteLine($"Cédula: {emp.Cedula}, Nombre: {emp.Nombre}, Dirección: {emp.Direccion}, Teléfono: {emp.Telefono}, Salario: {emp.Salario}");
            }
        }
    }

    
    public void MostrarPromedioSalarios()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
        }
        else
        {
            decimal promedio = empleados.Average(e => e.Salario);
            Console.WriteLine($"El promedio de los salarios es: {promedio}");
        }
    }
}
