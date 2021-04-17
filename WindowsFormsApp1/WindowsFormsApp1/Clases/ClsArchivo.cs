using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases
{
    class ClsArchivo
    {


        public string[] LeerArchivo(string archivo)
        {
            string[] Lineas = File.ReadAllLines(archivo, Encoding.Default); // Controla errores de caracteres desconocidos
            return Lineas;
        }


        public string LeerTodoArchivo(string archivo)
        {
            string ContenidoArchivo;

            using (StreamReader reader = new StreamReader(archivo, Encoding.UTF7)) // Garantiza los conjuntos de caracteres UTF-7 se leeran correctamente 
            {
                ContenidoArchivo = reader.ReadToEnd();
            }
            return ContenidoArchivo;
        }
    }
}
