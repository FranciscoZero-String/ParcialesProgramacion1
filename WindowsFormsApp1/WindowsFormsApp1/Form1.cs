using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Clases;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string[] ArregloNotas;
      
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonArreglo_Click(object sender, EventArgs e)
        {
            int ArreglarNombres = 0; // Variable declarada con valor de 0 
            string[] nombres = new string[ArregloNotas.Length - 1]; // Creara un String nuevo donde leera los datos 

            foreach (string linea in ArregloNotas) // Lo leera en Arreglo notas 
            {
                if (ArreglarNombres != 0) // Si ArregloNombres sigue siendo diferente a 0 entonces seguira ordenandolos 
                { 
                    string[] datos = linea.Split(';');
                    nombres[ArreglarNombres - 1] = datos[1]; // Si sigue siendo menor a la primera variable, Seguira ordenando para pasar al siguiente dato
                }
                ArreglarNombres++;
               
            }

            ClsArreglos arrreglo = new ClsArreglos(nombres); // Nuevo metodo para ordenar nombres 
            string[] resultado = arrreglo.Burbujita();

            for (int indice = 0; indice < resultado.Length; indice++) // Verifica todas las lineas para ordenar 
            {
                listBox1.Items.Add($"{resultado[indice]}"); // Devuelve El valor Arreglado 
            }

        }
        private void buttonCargarArchivo_Click(object sender, EventArgs e)
        {
            ClsArchivo ar = new ClsArchivo();
            OpenFileDialog ofd = new OpenFileDialog(); // Abre el archivo Plano 

            ofd.Title = "Selecciona el archivo plano";
            ofd.InitialDirectory = @"D:\Zero\Escritorio\UMG\Programacion 1\Clase 8"; // Direccion del archivo 
            ofd.Filter = "Archivo Plano (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var archivo = ofd.FileName;
                string resultado = ar.LeerTodoArchivo(archivo);
                ArregloNotas = ar.LeerArchivo(archivo);
                textBoxResultado.Text = resultado;

            }
        }

        public int promedio2D(string[,] matriz, int columna)
        {
            int acumulador = 0; 
            int promedio2D = 0;
            int totalfilas = matriz.GetLength(0);

            for (int fila = 1; fila < matriz.GetLength(0); fila++)
            {
                acumulador = acumulador + Convert.ToInt32(matriz[fila, columna]); 
            }

            promedio2D = (acumulador / (matriz.GetLength(0) - 1)) - 1;
            return promedio2D; 

        }
        private void buttonNombres_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int promedio, promedio1, promedio2;
            int acumulador, acumulador1, acumulador2;
            acumulador = 0;
            acumulador1 = 0;
            acumulador2 = 0;

            string[,] ArregloDosDimensiones = new string[ArregloNotas.Length, 6];

            int[] ordenParcialNota3 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota2 = new int[ArregloNotas.Length - 1];
            int[] Parcialn1 = new int[ArregloNotas.Length - 1];

            foreach (string Linea in ArregloNotas)
            {
                if (contador != 0)
                {
                    string[] datosUnitarios = Linea.Split(';');
                    listBoxResultado.Items.Add($" {datosUnitarios[1]}");
                    acumulador = acumulador + Convert.ToInt32(datosUnitarios[2]);
                    acumulador1 = acumulador1 + Convert.ToInt32(datosUnitarios[3]);
                    acumulador2 = acumulador2 + Convert.ToInt32(datosUnitarios[4]);

                    Parcialn1[contador - 1] = Convert.ToInt32(datosUnitarios[2]);

                    ordenParcialNota2[contador - 1] = Convert.ToInt32(datosUnitarios[3]);

                    ordenParcialNota3[contador - 1] = Convert.ToInt32(datosUnitarios[4]);


                    ArregloDosDimensiones[contador, 0] = datosUnitarios[0];
                    ArregloDosDimensiones[contador, 1] = datosUnitarios[1];
                    ArregloDosDimensiones[contador, 2] = datosUnitarios[2];
                    ArregloDosDimensiones[contador, 3] = datosUnitarios[3];
                    ArregloDosDimensiones[contador, 4] = datosUnitarios[4];
                    ArregloDosDimensiones[contador, 5] = datosUnitarios[5];
                }

                contador++;
            }

            // Promedio archivo plano 
            ClsArreglos FncArreglosN1 = new ClsArreglos(Parcialn1);
            Parcialn1 = FncArreglosN1.MetodoBurbuja();
            int MinN1 = Parcialn1[0];
            int MaxN1 = Parcialn1[Parcialn1.Length - 1];
            
            ClsArreglos FncArreglosN2 = new ClsArreglos(ordenParcialNota2);
            ordenParcialNota2 = FncArreglosN2.MetodoBurbuja();
            int MinN2 = ordenParcialNota2[0];
            int MaxN2 = ordenParcialNota2[ordenParcialNota2.Length - 1];

            ClsArreglos FncArreglosN3 = new ClsArreglos(ordenParcialNota3);
            ordenParcialNota3 = FncArreglosN3.MetodoBurbuja();
            int MinN3 = ordenParcialNota3[0];
            int MaxN3 = ordenParcialNota3[ordenParcialNota3.Length - 1];


            // Funcion, promedio archivo plano de dos diemensiones 
            ClsArreglos fncN2D = new ClsArreglos(Parcialn1);
            Parcialn1 = fncN2D.MetodoBurbuja();
            promedio = acumulador / ArregloDosDimensiones.Length - 1;
            int promedioMatriz = promedio2D(ArregloDosDimensiones, 2);
            int MinN1ed = Parcialn1[0];
            int MaxN12d = Parcialn1[Parcialn1.Length - 1];

            ClsArreglos fncN12D = new ClsArreglos(ordenParcialNota2);
            ordenParcialNota2 = fncN12D.MetodoBurbuja();
            promedio = acumulador / ArregloDosDimensiones.Length - 1;
            int promedioMatriz2 = promedio2D(ArregloDosDimensiones, 2);
            int MinN2ed = Parcialn1[0];
            int MaxN22d = Parcialn1[Parcialn1.Length - 1];

            ClsArreglos fncN13D = new ClsArreglos(ordenParcialNota3);
            ordenParcialNota3 = fncN12D.MetodoBurbuja();
            promedio = acumulador / ArregloDosDimensiones.Length - 1;
            int promedioMatriz3 = promedio2D(ArregloDosDimensiones, 2);
            int MinN3ed = Parcialn1[0];
            int MaxN32d = Parcialn1[Parcialn1.Length - 1];


            promedio = acumulador / ArregloNotas.Length - 1;
            promedio1 = acumulador1 / ArregloNotas.Length - 1;
            promedio2 = acumulador2 / ArregloNotas.Length - 1;

            int PromedioTresParciales = ((acumulador + acumulador1 + acumulador2) / (ArregloNotas.Length - 1));

            MessageBox.Show($"Promedio de los 3 parciales: {PromedioTresParciales}");

            // Mostrar promedio archivo plano 
            MessageBox.Show($"Promedio Parcial1: {promedio}.\nMaximoNota1: {MaxN1}.\nMinimaNota1: {MinN1}.\nPromedio Parcial2: {promedio1}.\nMaximoNota1: {MaxN2}.\nMinimaNota1: {MinN2}.\nPromedio Parcial3: {promedio2}.\nMaximoNota3: {MaxN3}.\nMinimaNota3: {MinN3}");

            // Mostrar promedio dos dimensiones 
            MessageBox.Show($"promedio de 2D P1: {promedioMatriz}.\nMaximaNota: {MaxN12d}.\nMinimaNota: {MinN1ed}.\npromedio de 2D P2: {promedioMatriz2}.\nMaximaNota: {MaxN22d}.\nMinimaNota: {MinN2ed}.\npromedio de 2D P3: {promedioMatriz3}.\nMaximaNota: {MaxN32d}.\nMinimaNota: {MinN3ed}.");

        }

        private void textBoxResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxResultado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ArreglarNombres = 0; 
            string[] nombres = new string[ArregloNotas.Length - 1]; 
            string[] Secciones = new string[ArregloNotas.Length - 1]; // creara un nuevo string para leer las secciones 

            foreach (string linea in ArregloNotas) 
            {
                if (ArreglarNombres != 0) 
                {
                    string[] datos = linea.Split(';');
                    nombres[ArreglarNombres - 1] = datos[1];
                    Secciones[ArreglarNombres - 1] = datos[5]; // Buscara los datos del archivo plano con paremetro con el parametro de 5 
                }
                ArreglarNombres++;

            }

            ClsArreglos arrreglo = new ClsArreglos(nombres); 
            string[] resultado = arrreglo.Burbujita();

            ClsArreglos ArregloSeccion = new ClsArreglos(Secciones); 
            string[] ResultadoSeccion = ArregloSeccion.Burbujita();

            for (int indice = 0; indice < resultado.Length; indice++) 
            {
                listBox2.Items.Add($"{resultado[indice]} Seeciones: {ResultadoSeccion[indice]}"); 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int promedio, promedio1, promedio2;
            int acumulador, acumulador1, acumulador2;
            acumulador = 0;
            acumulador1 = 0;
            acumulador2 = 0;

            int[] ordenParcialNota3 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota2 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota1 = new int[ArregloNotas.Length - 1];

            foreach (string Linea in ArregloNotas)
            {
                if (contador != 0)
                {
                    string[] datosUnitarios = Linea.Split(';');

                    listBoxResultado.Items.Add($" {datosUnitarios[1]}");

                    // Primer arreglo, promedio A
                    if (datosUnitarios[5] == "A")
                    {
                        acumulador = acumulador + Convert.ToInt32(datosUnitarios[2]);
                        acumulador1 = acumulador1 + Convert.ToInt32(datosUnitarios[3]);
                        acumulador2 = acumulador2 + Convert.ToInt32(datosUnitarios[4]);

                        ordenParcialNota1[contador - 1] = Convert.ToInt32(datosUnitarios[2]);

                        ordenParcialNota2[contador - 1] = Convert.ToInt32(datosUnitarios[3]);

                        ordenParcialNota3[contador - 1] = Convert.ToInt32(datosUnitarios[4]);

                    }    
                }
                contador++;
            }

            // Promedio archivo plano 
            ClsArreglos FncArreglosN1 = new ClsArreglos(ordenParcialNota1);
            ordenParcialNota1 = FncArreglosN1.MetodoBurbuja();
       
            ClsArreglos FncArreglosN2 = new ClsArreglos(ordenParcialNota2);
            ordenParcialNota2 = FncArreglosN2.MetodoBurbuja();
           
            ClsArreglos FncArreglosN3 = new ClsArreglos(ordenParcialNota3);
            ordenParcialNota3 = FncArreglosN3.MetodoBurbuja();
            

            // Funcion, promedio archivo plano de dos diemensiones 
            promedio = acumulador / ArregloNotas.Length - 1;
            promedio1 = acumulador1 / ArregloNotas.Length - 1;
            promedio2 = acumulador2 / ArregloNotas.Length - 1;

            int valorPromedio = promedio + promedio1 + promedio2 ;
            MessageBox.Show($"Promedio Parciales A: {valorPromedio}.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int promedio, promedio1, promedio2;
            int acumulador, acumulador1, acumulador2;
            acumulador = 0;
            acumulador1 = 0;
            acumulador2 = 0;

            int[] ordenParcialNota3 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota2 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota1 = new int[ArregloNotas.Length - 1];

            foreach (string Linea in ArregloNotas)
            {
                if (contador != 0)
                {
                    string[] datosUnitarios = Linea.Split(';');

                    listBoxResultado.Items.Add($" {datosUnitarios[1]}");

                    // Primer arreglo, promedio B
                    if (datosUnitarios[5] == "B")
                    {
                        acumulador = acumulador + Convert.ToInt32(datosUnitarios[2]);
                        acumulador1 = acumulador1 + Convert.ToInt32(datosUnitarios[3]);
                        acumulador2 = acumulador2 + Convert.ToInt32(datosUnitarios[4]);

                        ordenParcialNota1[contador - 1] = Convert.ToInt32(datosUnitarios[2]);

                        ordenParcialNota2[contador - 1] = Convert.ToInt32(datosUnitarios[3]);

                        ordenParcialNota3[contador - 1] = Convert.ToInt32(datosUnitarios[4]);

                    }
                }
                contador++;
            }

            // Promedio archivo plano 
            ClsArreglos FncArreglosN1 = new ClsArreglos(ordenParcialNota1);
            ordenParcialNota1 = FncArreglosN1.MetodoBurbuja();

            ClsArreglos FncArreglosN2 = new ClsArreglos(ordenParcialNota2);
            ordenParcialNota2 = FncArreglosN2.MetodoBurbuja();

            ClsArreglos FncArreglosN3 = new ClsArreglos(ordenParcialNota3);
            ordenParcialNota3 = FncArreglosN3.MetodoBurbuja();


            // Funcion, promedio archivo plano de dos diemensiones 

            promedio = acumulador / ArregloNotas.Length - 1;
            promedio1 = acumulador1 / ArregloNotas.Length - 1;
            promedio2 = acumulador2 / ArregloNotas.Length - 1;

            int valorPromedio = promedio + promedio1 + promedio2;
            MessageBox.Show($"Promedio Parciales B: {valorPromedio}.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int promedio, promedio1, promedio2;
            int acumulador, acumulador1, acumulador2;
            acumulador = 0;
            acumulador1 = 0;
            acumulador2 = 0;

            int[] ordenParcialNota3 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota2 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota1 = new int[ArregloNotas.Length - 1];

            foreach (string Linea in ArregloNotas)
            {
                if (contador != 0)
                {
                    string[] datosUnitarios = Linea.Split(';');

                    listBoxResultado.Items.Add($" {datosUnitarios[1]}");

                    // Primer arreglo, promedio C
                    if (datosUnitarios[5] == "C")
                    {
                        acumulador = acumulador + Convert.ToInt32(datosUnitarios[2]);
                        acumulador1 = acumulador1 + Convert.ToInt32(datosUnitarios[3]);
                        acumulador2 = acumulador2 + Convert.ToInt32(datosUnitarios[4]);

                        ordenParcialNota1[contador - 1] = Convert.ToInt32(datosUnitarios[2]);

                        ordenParcialNota2[contador - 1] = Convert.ToInt32(datosUnitarios[3]);

                        ordenParcialNota3[contador - 1] = Convert.ToInt32(datosUnitarios[4]);

                    }
                }
                contador++;
            }

            // Promedio archivo plano 
            ClsArreglos FncArreglosN1 = new ClsArreglos(ordenParcialNota1);
            ordenParcialNota1 = FncArreglosN1.MetodoBurbuja();

            ClsArreglos FncArreglosN2 = new ClsArreglos(ordenParcialNota2);
            ordenParcialNota2 = FncArreglosN2.MetodoBurbuja();

            ClsArreglos FncArreglosN3 = new ClsArreglos(ordenParcialNota3);
            ordenParcialNota3 = FncArreglosN3.MetodoBurbuja();


            // Funcion, promedio archivo plano de dos diemensiones 
            promedio = acumulador / ArregloNotas.Length - 1;
            promedio1 = acumulador1 / ArregloNotas.Length - 1;
            promedio2 = acumulador2 / ArregloNotas.Length - 1;

            int valorPromedio = promedio + promedio1 + promedio2;
            MessageBox.Show($"Promedio Parciales C: {valorPromedio}.");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int promedio, promedio1, promedio2;
            int acumulador, acumulador1, acumulador2;
            acumulador = 0;
            acumulador1 = 0;
            acumulador2 = 0;

            int[] ordenParcialNota3 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota2 = new int[ArregloNotas.Length - 1];
            int[] ordenParcialNota1 = new int[ArregloNotas.Length - 1];

            foreach (string Linea in ArregloNotas)
            {
                if (contador != 0)
                {
                    string[] datosUnitarios = Linea.Split(';');

                    listBoxResultado.Items.Add($" {datosUnitarios[1]}");

                    // Primer arreglo, promedio D
                    if (datosUnitarios[5] == "D")
                    {
                        acumulador = acumulador + Convert.ToInt32(datosUnitarios[2]);
                        acumulador1 = acumulador1 + Convert.ToInt32(datosUnitarios[3]);
                        acumulador2 = acumulador2 + Convert.ToInt32(datosUnitarios[4]);

                        ordenParcialNota1[contador - 1] = Convert.ToInt32(datosUnitarios[2]);

                        ordenParcialNota2[contador - 1] = Convert.ToInt32(datosUnitarios[3]);

                        ordenParcialNota3[contador - 1] = Convert.ToInt32(datosUnitarios[4]);

                    }
                }
                contador++;
            }

            // Promedio archivo plano 
            ClsArreglos FncArreglosN1 = new ClsArreglos(ordenParcialNota1);
            ordenParcialNota1 = FncArreglosN1.MetodoBurbuja();

            ClsArreglos FncArreglosN2 = new ClsArreglos(ordenParcialNota2);
            ordenParcialNota2 = FncArreglosN2.MetodoBurbuja();

            ClsArreglos FncArreglosN3 = new ClsArreglos(ordenParcialNota3);
            ordenParcialNota3 = FncArreglosN3.MetodoBurbuja();


            // Funcion, promedio archivo plano de dos diemensiones 
            promedio = acumulador / ArregloNotas.Length - 1;
            promedio1 = acumulador1 / ArregloNotas.Length - 1;
            promedio2 = acumulador2 / ArregloNotas.Length - 1;

            int valorPromedio = promedio + promedio1 + promedio2;
            MessageBox.Show($"Promedio Parciales D: {valorPromedio}.");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

