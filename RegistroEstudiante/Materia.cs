using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMateria
{
    [Serializable()]
    public class Materia
    {

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public string Codigo { get; set; }


        public Materia(int id)
        {
            ID = id;
        }
        public void CrearMateria()
        {

            Console.Write("\nIngrese el nombre de la materia: ");
            Nombre = Console.ReadLine().ToUpper();
            Console.Write("\nIngrese el area al que pertenece la materia: ");
            Area = Console.ReadLine().ToUpper();
            Codigo = "CB" + Area.Substring(0, 1) + ID.ToString();
            Console.WriteLine("\nSe genero una materia satisfactoriamente \n Nombre: {0} \n Area: {1} \n Codigo: {2}\n", Nombre, Area, Codigo);

        }

        public void ListarMaterias(int line)
        {
            int posX = 3;
            Console.SetCursorPosition(posX, line);
             posX += 4;
            Console.SetCursorPosition(posX, line);
            Console.Write(Codigo);
            posX += (Codigo.Length + 3);
            Console.SetCursorPosition(posX, line);
            Console.Write("|");
            posX += 8;
            Console.SetCursorPosition(posX, line);
            Console.Write(Nombre);
            posX += 22 ;
            Console.SetCursorPosition(posX, line);
            Console.Write("|");
            posX += 5;
            Console.SetCursorPosition(posX, line);
            Console.Write(Area);
        }
    }
}
