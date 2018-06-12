using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Registro_Estudiante
{
    [Serializable()]
    public class Estudiante
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Estatus { get; set; }
        public int ID { get; set; }
        public string Carrera { get; set; }
        public string Cedula { get; set; }
        public string Nacionalidad { get; set; }


        public Estudiante(int id)
        {
            ID = id;
        }

        public void CrearEstudiante()
        {
            Console.Write("\nIngrese el nombre del estudiante: ");
            Nombre = (Console.ReadLine().ToUpper());

            Console.Write("\nIngrese el apellido del estudiante: ");
            Apellido = Console.ReadLine().ToUpper();

            Fecha:
            try
            {
                Console.Write("\nIngrese la fecha de nacimiento dd/mm/yyyy: ");
                Nacimiento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            }

            catch (FormatException)
            {
                Console.WriteLine("\nEso no es un formato valido! \n");
                goto Fecha;
            }

            Estatus:

            Console.Write("\nEscoja el estatus del estudiante \n 1) En proceso \n 2) Activo \n 3) Prueba academica \n 4) Inactivo \n >");
            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion >= 1 || opcion <= 4)
                {
                    switch (opcion)
                    {
                        case 1:
                            Estatus = "En proceso";
                            break;
                        case 2:
                            Estatus = "Activo";
                            break;
                        case 3:
                            Estatus = "Prueba academica";
                            break;
                        case 4:
                            Estatus = "Inactivo";
                            break;
                        default:
                            Console.WriteLine("No ha ingresado una opcion valida \n");
                            goto Estatus;
                    }
                }
               
            }
            catch (FormatException)
            {
                Console.WriteLine("\nEso no es un formato valido! \n");
                goto Estatus ;
            }
            

            Console.Write("\nIngrese la carrera del estudiante: ");
            Carrera = Console.ReadLine().ToUpper();

          Nacionalidad:

            Console.WriteLine("\nEl estudiante es : \n 1) Dominicano \n 2) Extranjero");

            try
            {
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt >= 1 || opt <= 2)
                {
                    switch (opt)
                    {
                        case 1:
                            Nacionalidad = "Dominicano";
                            break;

                        case 2:
                            Nacionalidad = "Extranjero";
                            break;
                        default:
                            Console.WriteLine("No ha ingresado una opcion valida \n");
                            goto Nacionalidad;
                            
                    }
                }

               
            }
            catch (FormatException)
            {

                Console.WriteLine("\nEso no es un formato valido! \n");
                goto Nacionalidad;
            }
            


            Identidad:

            if (Nacionalidad == "Dominicano")
            {
                Console.Write("\nDigite el numero de cedula sin espacios o guiones: ");
                string intento = Console.ReadLine();

                if (intento.Length != 11)
                {
                    Console.WriteLine("\nLa cedula tiene 11 digitos porfavor intente otra vez! ");
                    goto Identidad;
                }
                else
                    Cedula = intento;

            }

            else
            {
                Console.Write("\nDigite el numero de pasaporte del estudiante: ");
                Cedula = Console.ReadLine();

            }
            Console.WriteLine("\n\nEl ID del estudiante es:" + ID);
            Console.WriteLine("\nSe ha registrado un nuevo estudiante satisfactoriamente!\n");

           



        }

        internal static void Add(Estudiante marcanueva)
        {
            throw new NotImplementedException();
        }

        public void ListarEstudiantes(int line)
        {
            int posX=0;
            Console.SetCursorPosition(posX, line);
            Console.Write(ID);
            int idL= (12 - ID.ToString().Length);
            posX +=(idL+ID.ToString().Length);
            Console.SetCursorPosition(posX, line);
            Console.Write("|"+Nombre+" "+Apellido);
            int nL = (35 - (Nombre.ToString().Length + Apellido.ToString().Length));
            posX +=(nL+Nombre.Length +Apellido.Length);
            Console.SetCursorPosition(posX, line);
            Console.Write("|" + Estatus);
            int esL = (22 - Estatus.Length);
            posX +=esL+Estatus.Length;
            Console.SetCursorPosition(posX, line);
            Console.Write("|" + Carrera);
            int cLL = 30 - Carrera.Length;
            posX += cLL+Carrera.Length;
            Console.SetCursorPosition(posX, line);
            Console.Write("|"+Cedula);
            int cL = 36 - Cedula.Length;
            posX += cL + Cedula.Length;
            Console.SetCursorPosition(posX, line);
            Console.Write("|" + Nacionalidad);
            int naL = 25 - Nacionalidad.Length;
            posX += naL + Nacionalidad.Length -1;

            Console.SetCursorPosition(posX, line);
            Console.Write("|{0}/{1}/{2}",Nacimiento.Day,Nacimiento.Month,Nacimiento.Year);


        }

        internal static void RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
    }
    

