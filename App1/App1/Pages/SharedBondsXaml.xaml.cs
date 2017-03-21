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
    public partial class SharedBondsXaml : ContentPage
    {
        public SharedBondsXaml()
        {
            InitializeComponent();
            var settings = new List<Titles> {
                new Titles ("Change My Username"),
                new Titles ("Change My Email"),
                new Titles ("Change My Password"),
                new Titles ("Change My Profile Picture"),
                new Titles ("Security Question"),
                new Titles ("Language"),
                new Titles ("Notifications"),
                new Titles ("Sign Out")
            };
            listView.ItemsSource = settings;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var settings = e.SelectedItem as Titles;

            if (settings == null)
            {
                return;
            }

            ContentPage page = null;

            //switch (settings.Name)
            //{
            //    case "Change My Username":
            //        page = new ChangeNameXaml();
            //        break;
            //    case "Change My Email":
            //        page = new ChangeEmailXaml();
            //        break;
            //    case "Change My Password":
            //        page = new ChangePasswordXaml();
            //        break;
            //    case "Change My Profile Picture":
            //        page = new ChangeProfilePictureXaml();
            //        break;
            //    case "Security Question":
            //        page = new ChangeSecurityQuestionXaml();
            //        break;
            //    case "Language":
            //        page = new ChangeLanguageXaml();
            //        break;
            //    case "Notifications":
            //        page = new NotificationsXaml();
            //        break;
            //    case "Sign Out":
            //        page = new LoginXaml();
            //        break;
            //    default:
            //        page = new SettingsXaml();
            //        break;
            //}

            page.BindingContext = settings;
            Navigation.PushAsync(page);
        }
    }
}
