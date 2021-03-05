using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimerParcial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Opcion1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Opcion1());
        }


        private async void Opcion2_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new opcion2());
        }
    }
}
