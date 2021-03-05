using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimerParcial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Opcion1 : ContentPage
    {
        public Opcion1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)

        {
            var a = double.Parse(ingresado.Text);
            var b = a - 365;
            int c = 2;
            var numeros = Convert.ToInt32(b.ToString().Substring(0, c));

            rest.Text = numeros.ToString();

            var ressu = a - 365;
            int d = 2;
            var numeros1 = Convert.ToInt32(ressu.ToString().Substring(2, d));

            rest.Text = numeros1.ToString();
            ingresado.Text = "";
        }

    }
}