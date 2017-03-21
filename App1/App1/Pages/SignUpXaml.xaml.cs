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
    public partial class SignUpXaml : ContentPage
    {
        RestService obj = new RestService();
        public SignUpXaml()
        {
            InitializeComponent();
        }
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            var user = new User(usernameEntry.Text, passwordEntry.Text, emailEntry.Text);

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                UserResponse authUser = await obj.addUserAsync(user);
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null && authUser != null)
                {
                    Navigation.InsertPageBefore(new NavigationXaml(authUser), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                messageLabel.Text = "Sign up failed";
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.username) && !string.IsNullOrWhiteSpace(user.password) && !string.IsNullOrWhiteSpace(user.email) && user.email.Contains("@"));
        }
    }
}
