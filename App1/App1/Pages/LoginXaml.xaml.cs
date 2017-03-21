using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using System.Diagnostics;

namespace App1.Pages
{
    public partial class LoginXaml : ContentPage
    {
        RestService obj = new RestService();
        UserResponse userResponse;
        public LoginXaml()
        {
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpXaml());
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            User user = new User(usernameEntry.Text, passwordEntry.Text);
            userResponse = await AreCredentialsCorrect(user);
                        if (userResponse != null)
            {
                Debug.WriteLine("User is logged in");
                Navigation.InsertPageBefore(new NavigationXaml(userResponse), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed! ";
                passwordEntry.Text = string.Empty;
            }
        }

        async Task<UserResponse> AreCredentialsCorrect(User user)
        {
            userResponse = await obj.AuthenticateuserAsync(user);
            return userResponse;
        }
    }
}
