using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordXaml : ContentPage
    {
        public ChangePasswordXaml()
        {
            InitializeComponent();
        }

        async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsPasswordEntry.Text, repeatPasswordEntry.Text) && !string.Equals(settingsPasswordEntry.Text, string.Empty))
            {
                await Navigation.PushAsync(new NavigationXaml());
            }
            else
            {
                passwordMessageLabel.Text = "Password does not match";
                settingsPasswordEntry.Text = string.Empty;
                repeatPasswordEntry.Text = string.Empty;
            }
        }
    }

}
