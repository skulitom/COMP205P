using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;

namespace App1.Pages
{
    public partial class LoginXaml : ContentPage
    {
        public LoginXaml()
        {
            InitializeComponent();
            
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationXaml());
        }
    }
}
