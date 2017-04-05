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
        User temp;
        UserResponse user;
        RestService obj;
        public ChangePasswordXaml(UserResponse user, User temp)
        {
            InitializeComponent();
            this.user = user;
            this.temp = temp;
            obj = new RestService();
        }

        async void OnChangePasswordButtonClicked(object sender, EventArgs e)
        {
            if (string.Equals(settingsPasswordEntry.Text, repeatPasswordEntry.Text) && !string.Equals(settingsPasswordEntry.Text, string.Empty))
            {
                temp.password = settingsPasswordEntry.Text;
                await obj.updateUserDetailsAsync(user, temp);
                passwordMessageLabel.Text = "Password has succesffully been changed";
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
