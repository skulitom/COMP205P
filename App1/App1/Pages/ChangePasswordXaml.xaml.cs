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
        UserResponse user;
        RestService obj;
        public ChangePasswordXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            obj = new RestService();
        }

        async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsPasswordEntry.Text, repeatPasswordEntry.Text) && !string.Equals(settingsPasswordEntry.Text, string.Empty))
            {
                User temp = new Pages.User();
                temp.key = user.key;
                temp.password = settingsPasswordEntry.Text;
                await obj.editUserAsync(temp);
                await Navigation.PushAsync(new NavigationXaml(user));
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
