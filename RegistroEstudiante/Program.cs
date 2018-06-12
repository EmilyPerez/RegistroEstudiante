using Registro_Estudiante;
using RegistroMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using RegistroData;

namespace Registro_Estudiantes
{
    class Program
    {
       

        static void Main(string[] args)
        {

            List<Registro_Estudiante.Estudiante> Estudiantes =  new List<Registro_Estudiante.Estudiante>();
            List<RegistroMateria.Materia> Materias = new List<RegistroMateria.Materia>();

            Data data = new Data("Estudiante.bd");
            Data2 dataM = new Data2("Materia.bd");

            Boolean Open = true;
            int id_materia = 101;
            int est = 0;
            int id;
            while (Open)
            {
                if (File.Exists("Estudiante.bd"))
                {
                    Estudiantes = data.deserializar();
                }
                if (File.Exists("Materia.bd"))
                {
                    Materias = dataM.deserializarMateria();
                }

                MenuPrincipal:
                Console.Clear();
                Console.WriteLine("Seleccione un menu: \n 1) Estudiantes \n 2) Materias \n 3) Salir");
                try
                {
                    int opc = Convert.ToInt32(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:
                            {
                                Console.Clear();
                                MenuEstudiantes:

                                Console.WriteLine("Bienvenido al sistema de registro de estudiante \n\n 1) Crear nuevo estudiante \n 2) Listar todos los estudiantes \n 3) Editar \n 4) Eliminar estudiante \n 5) Buscar estudiante \n 6) Salir");
                                int opcion = Convert.ToInt32(Console.ReadLine());

                                if (opcion < 7 || opcion >= 0)
                                {
                                    switch (opcion)
                                    {
                                        case 1:
                                            {
                                                Console.Clear();
                                                if (Estudiantes.Count == 0)
                                                {
                                                    id = 1080001;
                                                }
                                                else
                                                {
                                                    id = Estudiantes[Estudiantes.Count - 1].ID + 1;
                                                    id += est;
                                                }
                                                Estudiante Prueba = new Estudiante(id);
                                                Prueba.CrearEstudiante();
                                                Estudiantes.Add(Prueba);
                                                
                                                data.serializar(Estudiantes);
                                                Console.ReadKey();
                                                Console.Clear();
                                                goto MenuEstudiantes;
                                            }
                                        case 2:
                                            {
                                                Console.Clear();
                                                if (Estudiantes.Count > 0)
                                                {
                                                    Console.WriteLine("          LISTA DE TODOS LOS ESTUDIANTES           \n");
                                                    Console.WriteLine("ID :        |  Nombres y Apellidos             | Estatus :           | Carrera :                   | Documento de Identidad :          | Nacionalidad :        | F. Nacimiento :                ");
                                                    Console.Write("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                                    for (int i = 0; i < Estudiantes.Count; i++)
                                                    {
                                                        Estudiantes[i].ListarEstudiantes((i + 6));
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No hay estudiantes registrados!");
                                                }
                                                Console.ReadKey();
                                                Console.Clear();
                                                goto MenuEstudiantes;
                                            }
                                        case 3:
                                            {
                                                Console.Clear();
                                                int idEditar = 0, campo;
                                                Console.WriteLine("Ingrese el id a modificar: ");
                                                idEditar = Convert.ToInt32(Console.ReadLine());
                                                Console.Clear();
                                                foreach (Estudiante A in Estudiantes)
                                                {

                                                    if (A.ID == idEditar)
                                                    {
                                                        Console.WriteLine("Campos a Modificar");
                                                        Console.WriteLine("1. Nombre");
                                                        Console.WriteLine("2. Apellido");
                                                        Console.WriteLine("3. Carrera");
                                                        Console.WriteLine("4. Estatus");
                                                        Console.WriteLine("5. Fecha de nacimiento");
                                                        Console.WriteLine("6. Nacionalidad");
                                                        Console.WriteLine("7. Documentos");



                                                        Console.Write("\nQue campo quiere editar?  ");
                                                        campo = Convert.ToInt32(Console.ReadLine());

                                                        Console.Clear();
                                                        switch (campo)
                                                        {
                                                            case 1:
                                                                {
                                                                    string nombrenuevo;
                                                                    Console.Write("Digite el nuevo nombre: ");
                                                                    nombrenuevo = Console.ReadLine().ToUpper();
                                                                    A.Nombre = nombrenuevo;
                                                                    data.serializar(Estudiantes);
                                                                    Console.WriteLine("\n Se modifico el campo !");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                    goto MenuEstudiantes;
                                                                }

                                                            case 2:
                                                                {
                                                                    string apellidonuevo;
                                                                    Console.Write("\nDigite el nuevo apellido: ");
                                                                    apellidonuevo = Console.ReadLine().ToUpper();
                                                                    A.Apellido = apellidonuevo;
                                                                    data.serializar(Estudiantes);
                                                                    Console.WriteLine("\n Se modifico el campo !");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                    goto MenuEstudiantes;
                                                                }

                                                            case 3:
                                                                {
                                                                    string carreranueva;
                                                                    Console.Write("\nDigite la nueva carrera: ");
                                                                    carreranueva = Console.ReadLine();
                                                                    A.Carrera = carreranueva;
                                                                    data.serializar(Estudiantes);
                                                                    Console.WriteLine("\n Se modifico el campo !");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                    goto MenuEstudiantes;
                                                                }

                                                            case 4:
                                                                {
                                                                    Console.Write("\nEscoja el estatus del estudiante \n 1) En proceso \n 2) Activo \n 3) Prueba academica \n 4) Inactivo \n >");
                                                                    Console.Write("\nDigite el nuevo estatus:");
                                                                    int opcion1 = Convert.ToInt32(Console.ReadLine());

                                                                    if (opcion1 >= 1 || opcion <= 4)
                                                                    {
                                                                        switch (opcion1)
                                                                        {
                                                                            case 1:
                                                                                A.Estatus = "En proceso";
                                                                                data.serializar(Estudiantes);
                                                                                break;
                                                                            case 2:
                                                                                A.Estatus = "Activo";
                                                                                data.serializar(Estudiantes);
                                                                                break;
                                                                            case 3:
                                                                                A.Estatus = "Prueba academica";
                                                                                data.serializar(Estudiantes);
                                                                                break;
                                                                            case 4:
                                                                                A.Estatus = "Inactivo";
                                                                                data.serializar(Estudiantes);
                                                                                break;
                                                                        }
                                                                    }


                                                                    Console.WriteLine("\n Se modifico el campo !");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                    goto MenuEstudiantes; ;
                                                                }


                                                            case 5:
                                                                {
                                                                    Fecha:

                                                                    {
                                                                        try
                                                                        {
                                                                            Console.Write("\nIngrese la fecha de nacimiento dd/mm/yyyy: ");
                                                                            A.Nacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                                                                            data.serializar(Estudiantes);
                                                                        }

                                                                        catch (FormatException)
                                                                        {
                                                                            Console.WriteLine("\nEso no es un formato valido! \n");
                                                                            goto Fecha;
                                                                        }
                                                                    }
                                                                    Console.WriteLine("\n Se modifico el campo !");
                                                                    Console.ReadKey();
                                                                    Console.Clear();
                                                                    goto MenuEstudiantes; ;
                                                                }
                                                            case 6:
                                                                {

                                                                    Console.WriteLine("\nEl estudiante es : \n 1) Dominicano \n 2) Extranjero");
                                                                    int opt = Convert.ToInt32(Console.ReadLine());

                                                                    if (opt >= 1 || opt <= 2)
                                                                    {
                                                                        switch (opt)
                                                                        {
                                                                            case 1:
                                                                                A.Nacionalidad = "Dominicano";
                                                                                data.serializar(Estudiantes);
                                                                                break;

                                                                            case 2:
                                                                                A.Nacionalidad = "Extranjero";
                                                                                data.serializar(Estudiantes);
                                                                                break;
                                                                        }
                                                                    }
                                                                }
                                                                Console.WriteLine("\n Se modifico el campo !");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                                goto MenuEstudiantes; ;

                                                            case 7:
                                                                {

                                                                    if (A.Nacionalidad == "Dominicano")
                                                                    {
                                                                        Console.Write("\nDigite el numero de cedula sin espacios o guiones: ");
                                                                        string intento = Console.ReadLine();
                                                                        data.serializar(Estudiantes);

                                                                        if (intento.Length != 11)
                                                                        {
                                                                            Console.WriteLine("\nLa cedula no tiene 11 digitos, porfavor intente otra vez! ");
                                                                            goto case 7;
                                                                        }
                                                                        else
                                                                            A.Cedula = intento;
                                                                        data.serializar(Estudiantes);


                                                                    }

                                                                    else
                                                                    {
                                                                        Console.Write("\nDigite el numero de pasaporte del estudiante: ");
                                                                        A.Cedula = Console.ReadLine();
                                                                        data.serializar(Estudiantes);

                                                                    }
                                                                }
                                                                Console.WriteLine("\n Se modifico el campo !");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                                goto MenuEstudiantes; ;
                                                        }
                                                    }
                                                }
                                                Console.WriteLine("\nNo se encontro ningun estudiante con ese ID!");
                                                Console.ReadKey();
                                                Console.Clear();
                                                goto MenuEstudiantes;
                                            }
                                        case 4:
                                            {
                                                Console.Clear();
                                                Console.Write("Ingrese el ID del estudiante : ");
                                                int ID_Borrar = Convert.ToInt32(Console.ReadLine());
                                                

                                                try
                                                {
                                                    foreach (Estudiante b in Estudiantes)
                                                    {
                                                        if (b.ID == ID_Borrar)
                                                        {
                                                            Estudiantes.Remove(b);
                                                            data.serializar(Estudiantes);
                                                            Console.WriteLine("\nSe elimino el estudiante satisfactoriamente\n");
                                                            Console.ReadKey();
                                                            Console.Clear();
                                                            goto MenuEstudiantes;
                                                        }


                                                    }
                                                    Console.WriteLine("\nNo se ha encontrado un estudiante con ese ID\n");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                                catch (System.InvalidOperationException)
                                                {
                                                    Console.WriteLine("\nNo hay estudientes con ese ID \n");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    goto MenuEstudiantes;
                                                }

                                                Console.Clear();
                                                goto MenuEstudiantes;
                                            }

                                        case 5:

                                            {
                                                Console.Clear();
                                                Console.WriteLine("Nombre o cedula a buscar: ");
                                                string idBuscar = (Console.ReadLine().ToUpper());

                                                foreach (Estudiante b in Estudiantes)
                                                {
                                                    if (b.Nombre == idBuscar || b.Cedula == idBuscar)
                                                    {
                                                        Console.WriteLine("------------------------");
                                                        Console.WriteLine("ID: " + b.ID);
                                                        Console.WriteLine("Nombre: " + b.Nombre);
                                                        Console.WriteLine("Apellido: " + b.Apellido);
                                                        Console.WriteLine("Carrera: " + b.Carrera);
                                                        Console.WriteLine("Cedula: " + b.Cedula);
                                                        Console.WriteLine("Estatus: " + b.Estatus);
                                                        Console.WriteLine("Nacimiento: {0}/{1}/{2}", b.Nacimiento.Day, b.Nacimiento.Month, b.Nacimiento.Year);
                                                        Console.WriteLine("Nacionalidad: " + b.Nacionalidad);
                                                        Console.ReadKey();
                                                        Console.Clear();
                                                        goto MenuEstudiantes;
                                                    }
                                                }
                                                Console.WriteLine("No se ha encontrado ningun estudiante");
                                                Console.ReadKey();
                                                Console.Clear();

                                                goto MenuEstudiantes;
                                            }
                                        case 6:
                                            {
                                                break;
                                            }
                                          



                                    }
                                }

                                else
                                {
                                    Console.WriteLine("\nPorfavor ingrese una de las opciones mostradas !");
                                    Console.ReadKey();
                                    Console.Clear();
                                    goto MenuEstudiantes;
                                }
                            }
                            break;

                        case 2:
                            {
                                MenuMaterias:
                                Console.Clear();
                                
                                Console.WriteLine("Seleccione una opcion: \n 1) Crear materia nueva \n 2) Listar todas las materias \n 3) Borrar Materias \n 4) Editar Materia \n 5) Buscar Materia \n 6) Salir");
                                int option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {

                                    case 1:
                                        {
                                            Console.Clear();
                                            try
                                            {
                                                if (Materias.Count == 0)
                                                {
                                                    id_materia = 101;
                                                }
                                                else
                                                {
                                                    id_materia = Materias[Materias.Count - 1].ID + 1;
                                                }

                                                Materia nuevamat = new Materia(id_materia);
                                                Materias.Insert(0, nuevamat);
                                                nuevamat.CrearMateria();

                                                dataM.serializar(Materias);
                                                Console.WriteLine(" El ID de la materia es: {0} \n", id_materia);
                                                Console.ReadKey();
                                            }
                                            catch (ArgumentOutOfRangeException)
                                            {
                                                Console.WriteLine("Usted no ha ingresado un area o materia \n");
                                                goto MenuMaterias;

                                            }

                                            goto MenuMaterias;
                                        }

                                    case 2:
                                       
                                        {

                                            Console.Clear();
                                            if (Materias.Count > 0)
                                            {
                                                Console.WriteLine("               LISTA DE MATERIAS          ");
                                                Console.WriteLine("   Codigo    |            Nombre           |   Area   |");
                                                Console.WriteLine("------------------------------------------------------");
                                                for (int i = 0; i < Materias.Count; i++)
                                                {
                                                    Materias[i].ListarMaterias( i + 3 );
                                                }
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            else
                                            {
                                                Console.WriteLine("No hay materias registradas!");
                                                Console.ReadKey();
                                                Console.Clear();
                                            }
                                            goto MenuMaterias;
                                        }
                                        
                                    case 3:
                                        
                                        {
                                            Console.Clear();
                                            Console.Write("Ingrese el ID de la materia : ");
                                            int id_Borrar = Convert.ToInt32(Console.ReadLine());


                                            try
                                            {
                                                foreach (Materia a in Materias)
                                                {
                                                    if (a.ID == id_Borrar)
                                                    {
                                                        Materias.Remove(a);
                                                        dataM.serializar(Materias);
                                                        Console.WriteLine("\nSe elimino la materia satisfactoriamente\n");
                                                        Console.ReadKey();
                                                        goto MenuMaterias;
                                                    }
                                      

                                                }
                                                Console.WriteLine("\nNo se ha encontrado resultados !!\n");
                                                Console.ReadKey();
                                                goto MenuMaterias;

                                            }
                                            catch (System.InvalidOperationException)
                                            {
                                                Console.WriteLine("\nNo hay materias con ese ID \n");
                                                goto MenuMaterias;
                                            }
                                        }
                               


                                    case 4:
                                        {
                                            Console.Clear();
                                            int idEditar = 0, campo;
                                            Console.WriteLine("Ingrese el id a modificar: \n");
                                            idEditar = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            foreach (Materia A in Materias)
                                            {

                                                if (A.ID == idEditar)
                                                {
                                                    Console.WriteLine("Campos a Modificar");
                                                    Console.WriteLine("1. Nombre");
                                                    Console.WriteLine("2. Area");


                                                    Console.Write("\nQue campo quiere editar?  ");
                                                    campo = Convert.ToInt32(Console.ReadLine());
                                                    

                                                    switch (campo)
                                                    {
                                                        case 1:
                                                            Console.Clear();
                                                            {
                                                                string nombrematerianuevo;
                                                                Console.Write("Digite el nuevo nombre: ");
                                                                nombrematerianuevo = Console.ReadLine().ToUpper();
                                                                A.Nombre = nombrematerianuevo;
                                                                dataM.serializar(Materias);
                                                                Console.WriteLine("\nSe ha editado el nombre de la materia satisfactoriamente");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                                goto MenuMaterias;

                                                            }

                                                        case 2:
                                                            Console.Clear();
                                                            {
                                                                string areanueva;
                                                                Console.Write("\nDigite la nueva area: ");
                                                                areanueva = Console.ReadLine().ToUpper();
                                                                A.Area = areanueva;
                                                                dataM.serializar(Materias);
                                                                Console.WriteLine("\nSe ha editado el area de la materia satisfactoriamente");
                                                                Console.ReadKey();
                                                                Console.Clear();
                                                                goto MenuMaterias;

                                                            }
                                                    }
                                                }

                                            }
                                            Console.WriteLine("\n No encontramos resultados!\n");
                                            Console.ReadKey();
                                            Console.Clear();

                                            goto MenuMaterias;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Nombre o area a buscar: ");
                                            string Buscarmateria = (Console.ReadLine().ToUpper());

                                            foreach (Materia b in Materias)
                                            {
                                                if (b.Nombre == Buscarmateria || b.Area == Buscarmateria)
                                                {
                                                    Console.WriteLine("------------------------");
                                                    Console.WriteLine("ID: " + b.ID);
                                                    Console.WriteLine("Nombre: " + b.Nombre);
                                                    Console.WriteLine("Area: " + b.Area);
                                                    Console.WriteLine("Codigo: " + b.Codigo);
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    goto MenuMaterias;
                                                }

                                            }
                                            Console.WriteLine("\n No se encontro ningun resultado \n");
                                            Console.ReadKey();
                                            Console.Clear();
                                            goto MenuMaterias;
                                        }

                                    case 6:
                                        {
                                            break;
                                        }
                                        
                                    default:
                                        goto MenuMaterias;

                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("\nGracias por utilizar el sistema de registro!");
                                Console.ReadKey();
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.WriteLine("\nIngrese una de las opciones validas...");
                            Console.ReadKey();
                            goto MenuPrincipal;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor, ingrese una de las opciones validas");
                    Console.ReadKey();
                    goto MenuPrincipal;
                }
                
                        

            }
                
        }

    }
}

