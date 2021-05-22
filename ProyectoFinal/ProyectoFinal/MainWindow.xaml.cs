using clase11.Clases.archivo;
using clase11.Clases.BAseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cargarArchivoExternoMysql()
        {
            string fuente = @"D:\Zero\Escritorio\UMG\Programacion 1\Clase 11\WPF.csv";
            ClsArchivos ar = new ClsArchivos();
            //obtner todo el archivo, linea por linea dentro de un arreglo
            string[] ArregloNotas = ar.LeerArchivo(fuente);
            string sentencia_mysql = "";
            int Numerolineas = 0;

            ClsConexionMySQL cnn = new ClsConexionMySQL();

            foreach (string linea in ArregloNotas)
            {
                //obtener datos
                String[] datos = linea.Split(';');
                if (Numerolineas > 0)
                {
                    sentencia_mysql = sentencia_mysql + $"INSERT INTO `tienda`.`productos` (`Codigo`, `Nombre`, `Precio_Publico`, `Existencias`) VALUES  ('{datos[0]}','{datos[1]}','{datos[2]}','{datos[3]}','{datos[4]}');\n ";
                }
                Numerolineas++;
            }
            cnn.EjecutaMySQLDirecto(sentencia_mysql);
        }

        private void ButtonConectarMYSQL_Click(object sender, RoutedEventArgs e)
        {
            cargarArchivoExternoMysql();
        }

        private void ButtonCrearMYSQL_Click(object sender, RoutedEventArgs e)
        {
            string codigo = TextBoxCodigo.Text;
            string nombre = TextBoxNombre.Text;
            string Descripcion = TextBoxDescripcion.Text;
            string preciop = TextBoxPrecioPublico.Text;
            string Existencias = TextBoxExistencias.Text;
            string fecha = TextBoxID.Text;
            string centencia = $"INSERT INTO `tienda`.`productos` (`Codigo`, `Nombre`, `Descripcion`, `Precio_Publico`, `Existencias`, `Fecha`) VALUES " +$" ('{codigo}','{nombre}','{Descripcion}','{preciop}','{Existencias}','{fecha}');\n ";
            ClsConexionMySQL cn = new ClsConexionMySQL();
            cn.EjecutaMySQLDirecto(centencia);
        }

        private void ButtonBuscarMYSQL_Click(object sender, RoutedEventArgs e)
        {
            string id = TextBoxCodigo.Text;

            ClsConexionMySQL cn = new ClsConexionMySQL();
            string query = $"select* from tienda.productos where Codigo ={id}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<string>("Nombre");
                int precio = dt.Rows[0].Field<Int32>("Precio_Publico");
                int existencias = dt.Rows[0].Field<Int32>("Existencias");

                TextBoxNombre.Text = nombre;
                TextBoxPrecioPublico.Text = precio + "";
                TextBoxExistencias.Text = existencias + "";

            }
            else
            {
                TextBoxNombre.Text = "No se encontraron registros";
                TextBoxPrecioPublico.Text = "No se encontraron registros";
                TextBoxExistencias.Text = "No se encontraron registros";

            }
        }

        private void ButtonActualizarMYSQL_Click(object sender, RoutedEventArgs e)
        {
            string ID = TextBoxID.Text;
            string codigo = TextBoxCodigo.Text;
            String centencia = $"Update  tienda.productos set Codigo ='{ID}' where Codigo ='{codigo}'";
            ClsConexionMySQL cn = new ClsConexionMySQL();
            cn.EjecutaMySQLDirecto(centencia);
        }

        private void ButtonEliminarMYSQL_Click(object sender, RoutedEventArgs e)
        {
            string codigo = TextBoxCodigo.Text;
            string centencia = $" delete from `tienda`.`productos` where Codigo ={codigo}";
            ClsConexionMySQL cn = new ClsConexionMySQL();
            cn.EjecutaMySQLDirecto(centencia);
        }

        private void cargarArchivoExterno()
        {
            string fuente = @"C:\Users\alumno\Desktop\WPF.csv";
            ClsArchivos ar = new ClsArchivos();
            //obtner todo el archivo, linea por linea dentro de un arreglo
            string[] ArregloNotas = ar.LeerArchivo(fuente);
            string sentencia_sql = "";
            int Numerolinea = 0;

            ClsConexion cn = new ClsConexion();

            foreach (string linea in ArregloNotas)
            {
                //obtener datos
                String[] datos = linea.Split(';');
                if (Numerolinea > 0)
                {
                    sentencia_sql = sentencia_sql + $"insert into tb_alumnos values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]});\n ";
                }
                Numerolinea++;

            }
        }

        private void ButtonCrearSQL_Click(object sender, RoutedEventArgs e)
        {
            string codigo = TextBoxCodigo.Text;
            string nombre = TextBoxNombre.Text;
            string precio = TextBoxPrecioPublico.Text;
            string existencias = TextBoxExistencias.Text;
           
            string centencia = $"insert into tienda.productos values({codigo},'{nombre}',{precio},{existencias});\n ";
            ClsConexionMySQL cn = new ClsConexionMySQL();
            cn.EjecutaMySQLDirecto(centencia);
        }

        private void ButtonBuscarSQL_Click(object sender, RoutedEventArgs e)
        {
            string id = TextBoxCodigo.Text;

            ClsConexion cn = new ClsConexion();
            string query = $"select* from tienda.productos where Codigo ={id}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<string>("Nombre");
                int precio = dt.Rows[0].Field<Int32>("Precio_Publico");
                int existencias = dt.Rows[0].Field<Int32>("Existencias");
               
                TextBoxNombre.Text = nombre;
                TextBoxPrecioPublico.Text = precio + "";
                TextBoxExistencias.Text = existencias + "";
            }
            else
            {
                TextBoxNombre.Text = "No se encontraron registros";
                TextBoxPrecioPublico.Text = "No se encontraron registros";
                TextBoxExistencias.Text = "No se encontraron registros";
                
            }
        }

        private void ButtonActualizarSQL_Click(object sender, RoutedEventArgs e)
        {
            string ID = TextBoxID.Text;
            string codigo = TextBoxCodigo.Text;
            String centencia = $"Update  tienda.productos set Codigo ='{ID}' where Codigo ='{codigo}'";
            ClsConexionMySQL cn = new ClsConexionMySQL();
            cn.EjecutaMySQLDirecto(centencia);
        }

        private void ButtonConectarSQL_Click(object sender, RoutedEventArgs e)
        {
            cargarArchivoExterno();
        }

        private void ButtonEliminarSQL_Click(object sender, RoutedEventArgs e)
        {
            string codigo = TextBoxCodigo.Text;
            string centencia = $" delete from tienda.productos where Codigo ={codigo}";
            ClsConexionMySQL cn = new ClsConexionMySQL();
            cn.EjecutaMySQLDirecto(centencia);
        }

        public void LimpiarDatos()
        {
            TextBoxCodigo.Clear();
            TextBoxNombre.Clear();
            TextBoxPrecioPublico.Clear();
            TextBoxExistencias.Clear();
            TextBoxID.Clear();
            TextBoxPrecioPublico.Clear();
        }

        private void ButtonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarDatos();
        }
    }

}
