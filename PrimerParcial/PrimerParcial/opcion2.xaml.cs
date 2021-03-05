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
    public partial class opcion2 : ContentPage
    {
        public opcion2()
        {
            InitializeComponent();
        }

        private void Unir_Clicked_1(object sender, EventArgs e)
        {
            var a1 = double.Parse(ingresado1.Text);
            var result = a1 + 0;
            var R2 = 2;

            var Rp1 = Convert.ToInt32(result.ToString().Substring(0, R2));
            int declarar = Rp1 - 4;
            Respuesta.Text = declarar.ToString();
            ingresado1.Text = "";
        }

    }
}