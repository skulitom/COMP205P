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
        UserResponse user;
        public SettingsXaml(UserResponse user)
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
            this.user = user;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var settings = e.SelectedItem as Titles;

            if (settings == null)
            {
                return;
            }

            ContentPage page = null;

            switch (settings.Name)
            {
                case "Change My Username":
                    page = new ChangeNameXaml(user);
                    break;
                case "Change My Email":
                    page = new ChangeEmailXaml(user);
                    break;
                case "Change My Password":
                    page = new ChangePasswordXaml(user);
                    break;
                case "Change My Profile Picture":
                    page = new ChangeProfilePictureXaml(user);
                    break;
                case "Security Question":
                    page = new ChangeSecurityQuestionXaml(user);
                    break;
                case "Language":
                    page = new ChangeLanguageXaml(user);
                    break;
                case "Notifications":
                    page = new NotificationsXaml(user);
                    break;
                case "Sign Out":
                    page = new LoginXaml();
                    break;
                default:
                    page = new SettingsXaml(user);
                    break;
            }

            page.BindingContext = settings;
            Navigation.PushAsync(page);
        }

    }
}
