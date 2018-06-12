using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Registro_Estudiante;
using Registro_Estudiantes;
using RegistroMateria;

namespace RegistroData
{
    class Data
    {
        private String ruta;

        public Data(String ruta)
        {
            this.ruta = ruta;
        }

        public void serializar(List<Estudiante> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }

       

        public List<Estudiante> deserializar()
        { 
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Estudiante> lista = (List<Estudiante>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }

      
    }

    class Data2
    {
        private String ruta2;

        public Data2(String ruta2)
        {
            this.ruta2 = ruta2;
        }
        public void serializar(List<Materia> lista)
        {
            Stream flujo = File.Open(ruta2, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }

        public List<Materia> deserializarMateria()
        {
            Stream flujo = File.Open(ruta2, FileMode.Open);
            BinaryFormatter bin1 = new BinaryFormatter();
            List<Materia> list1 = (List<Materia>)bin1.Deserialize(flujo);
            flujo.Close();
            return list1;
        }
    }
}