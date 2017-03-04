using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using App1.ViewModels;

namespace App1.Pages
{
    public partial class HomeXaml : ContentPage
    {
        public HomeXaml()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();
        }

        public void PremiumButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PremiumBondsXaml());

        }
    }
}
