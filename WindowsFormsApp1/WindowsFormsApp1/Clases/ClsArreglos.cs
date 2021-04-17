using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Clases
{
    class ClsArreglos
    {
        private int[] Arreglotemporal;
        private int[] Datos;
        private int a, b, Datotemporal;
        private int TamanoArreglo = 0;

        public int GetTamanoArreglo()
        {
            return Datos.Length;
        }

        public ClsArreglos(int[] ArregloParametro)
        {
            Datos = ArregloParametro;
            TamanoArreglo = Datos.Length;
        }

        public int[] MetodoBurbuja()
        {
            Arreglotemporal = Datos;
            for (a = 0; a < TamanoArreglo - 1; a++)
            {
                for (b = a + 1; b < TamanoArreglo; b++)
                {
                    if (Arreglotemporal[a] > Arreglotemporal[b])
                    {
                        Datotemporal = Arreglotemporal[a];
                        Arreglotemporal[a] = Arreglotemporal[b];
                        Arreglotemporal[b] = Datotemporal;
                    }
                }
            }
            return Arreglotemporal;
        }

        private string[] DatosNombres;
        private string[] DatosResultados;
        private string DatosFinales;

        public ClsArreglos(string[] arreglos)
        {
            DatosResultados = arreglos;
            TamanoArreglo = DatosResultados.Length;
        }

        public string[] Burbujita()  // Nuevo metodo Burbujita para, nos ayudara a ordenar los nombres de la A a la Z 
        {
            DatosNombres = DatosResultados;

            for (a = 0; a < TamanoArreglo - 1; a++)
            {
                for (b = a + 1; b < TamanoArreglo; b++)
                {
                    if (DatosNombres[a].CompareTo(DatosNombres[b]) > 0) // Compara el primer objeto que implementa con el otro objeto
                    {

                        DatosFinales = DatosNombres[a];
                        DatosNombres[a] = DatosNombres[b];
                        DatosNombres[b] = DatosFinales;

                    }
                }
            }

            return DatosNombres;
        }
    }
}
