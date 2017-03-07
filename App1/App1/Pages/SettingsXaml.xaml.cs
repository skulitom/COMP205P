using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.Pages
{
    public partial class SettingsXaml : ContentPage
    {
        public SettingsXaml()
        {
            InitializeComponent();
        }

        async void OnChangeNameButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals( settingsUsernameEntry.Text, repeatUsernameEntry.Text) && !string.Equals(settingsUsernameEntry.Text ,string.Empty))
            {
                await Navigation.PushAsync(new NavigationXaml());
            }
            else
            {
                nameMessageLabel.Text = "Username does not match";
                settingsUsernameEntry.Text = string.Empty;
                repeatUsernameEntry.Text = string.Empty;
            }
        }

        async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsPasswordEntry.Text , repeatPasswordEntry.Text) && !string.Equals(settingsPasswordEntry.Text,string.Empty))
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

        async void OnChangeEmailButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsEmailEntry.Text, repeatEmailEntry.Text) && !string.Equals(settingsEmailEntry.Text ,string.Empty))
            {
                await Navigation.PushAsync(new NavigationXaml());
            }
            else
            {
                emailMessageLabel.Text = "Email does not match";
                settingsEmailEntry.Text = string.Empty;
                repeatEmailEntry.Text = string.Empty;
            }
        }

    }
}
