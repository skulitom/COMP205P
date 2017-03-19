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
        UserResponse user;
        RestService obj;
        public ChangeNameXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            obj = new RestService();
        }

        async void OnChangeNameButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsUsernameEntry.Text, repeatUsernameEntry.Text) && !string.Equals(settingsUsernameEntry.Text, string.Empty))
            {
                User temp = new Pages.User();
                temp.key = user.key;
                temp.username = settingsUsernameEntry.Text;
                await obj.editUserAsync(temp);
                await Navigation.PushAsync(new NavigationXaml(user));
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
