using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    public partial class SettingsXaml : ContentPage
    {
        public SettingsXaml()
        {
            InitializeComponent();
            var settings = new List<Settings> {
                new Settings ("Change My Username"),
                new Settings ("Change My Email"),
                new Settings ("Change My Password"),
                new Settings ("Change My Profile Picture"),
                new Settings ("Security Question"),
                new Settings ("Language"),
                new Settings ("Notifications"),
                new Settings ("Sign Out")
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
                case "Change My Username":
                    page = new ChangeNameXaml();
                    break;
                case "Change My Email":
                    page = new PSXaml();
                    break;
                case "Change My Password":
                    page = new DSXaml();
                    break;
                case "Change My Profile Picture":
                    page = new DISAXaml();
                    break;
                case "Security Question":
                    page = new IBXaml();
                    break;
                case "Language":
                    page = new CBXaml();
                    break;
                case "Notifications":
                    page = new IAXaml();
                    break;
                case "Sign Out":
                    page = new IAXaml();
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
