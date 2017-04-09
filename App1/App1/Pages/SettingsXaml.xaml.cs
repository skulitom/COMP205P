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
        User temp;
        UserResponse user;
        RestService obj;
        MasterDetailPage master;
        public SettingsXaml(MasterDetailPage master,UserResponse user)
        {
            InitializeComponent();
            obj = new RestService();
            var settings = new List<Titles> {
                new Titles ("Create new Syndicate"),
                new Titles ("Leave Syndicate"),
                new Titles ("Check total Winnings"),
                new Titles ("Update my Balance"),
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
            this.master = master;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            temp = await obj.getUserDetailsAsync(user);
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
                case "Create new Syndicate":
                    page = new SyndicateCreation(user);
                    break;
                case "Leave Syndicate":
                    page = new LeaveSyndicate(user);
                    break;
                case "Check total Winnings":
                    page = new TotalWinnings();
                    break;
                case "Update my Balance":
                    page = new UpdateBalance(user, temp);
                    break;
                case "Change My Username":
                    page = new ChangeNameXaml(user,temp);
                    break;
                case "Change My Email":
                    page = new ChangeEmailXaml(user,temp);
                    break;
                case "Change My Password":
                    page = new ChangePasswordXaml(user,temp);
                    break;
                case "Change My Profile Picture":
                    page = new ChangeProfilePictureXaml(user,temp);
                    break;
                case "Security Question":
                    page = new ChangeSecurityQuestionXaml(user,temp);
                    break;
                case "Language":
                    page = new ChangeLanguageXaml(user,temp);
                    break;
                case "Notifications":
                    page = new NotificationsXaml(user,temp);
                    break;
                case "Sign Out":
                    page = new LoginXaml();
                    break;
                default:
                    page = new SettingsXaml(master,user);
                    break;
            }

            page.BindingContext = temp;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = page.Title;
        }

    }
}
