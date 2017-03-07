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
    public partial class ChangeEmailXaml : ContentPage
    {
        public ChangeEmailXaml()
        {
            InitializeComponent();
        }

        async void OnChangeEmailButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsEmailEntry.Text, repeatEmailEntry.Text) && !string.Equals(settingsEmailEntry.Text, string.Empty))
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
