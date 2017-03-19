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
    public partial class SharedPremiumBonds : ContentPage
    {
        public SharedPremiumBonds()
        {
            InitializeComponent();
            var settings = new List<Settings> {
                new Settings ("Transactions"),
                new Settings ("Deposit"),
                new Settings ("Withdraw"),
                new Settings ("Transfer"),
                new Settings ("Have I Won?"),
                new Settings ("Account Details"),
            };
            listView.ItemsSource = settings;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var settings = e.SelectedItem as Settings;

            if (settings == null)
            {
                return;
            }

            ContentPage page = null;

            switch (settings.Name)
            {
                case "Transactions":
                    page = new ChangeNameXaml();
                    break;
                case "Deposit":
                    page = new ChangeEmailXaml();
                    break;
                case "Withdraw":
                    page = new ChangePasswordXaml();
                    break;
                case "Transfer":
                    page = new ChangeProfilePictureXaml();
                    break;
                case "Have I Won?":
                    page = new ChangeSecurityQuestionXaml();
                    break;
                case "Account Details":
                    page = new ChangeLanguageXaml();
                    break;
                default:
                    page = new SettingsXaml();
                    break;
            }

            page.BindingContext = settings;
            Navigation.PushAsync(page);
        }
    }
}
