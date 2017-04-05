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
        User temp;
        UserResponse user;
        RestService obj;
        public ChangeEmailXaml(UserResponse user, User temp)
        {
            InitializeComponent();
            this.user = user;
            this.temp = temp;
            obj = new RestService();
        }

        async void OnChangeEmailButtonClicked(object sender, EventArgs e) //need to add check for valid email
        {
            if (string.Equals(settingsEmailEntry.Text, repeatEmailEntry.Text) && !string.Equals(settingsEmailEntry.Text, string.Empty))
            {
                temp.email = settingsEmailEntry.Text;
                await obj.updateUserDetailsAsync(user, temp);
                emailMessageLabel.Text = "Email has successfully been changed";
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
