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
    public partial class ChangeNameXaml : ContentPage
    {
        public ChangeNameXaml()
        {
            InitializeComponent();
        }

        async void OnChangeNameButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsUsernameEntry.Text, repeatUsernameEntry.Text) && !string.Equals(settingsUsernameEntry.Text, string.Empty))
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
    }
}
