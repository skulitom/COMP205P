using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string lang, sec;
        RestService obj = new RestService();
        public SignUpXaml()
        {
            InitializeComponent();
        }

        private void LangPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
             lang = pickerLanguage.Items[pickerLanguage.SelectedIndex];
        }

        private void SecPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            sec = pickerChangeSecurityQuestion.Items[pickerChangeSecurityQuestion.SelectedIndex];
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("                    USER CREATION HAS BEGUN");
            var user = new User(usernameEntry.Text, passwordEntry.Text, emailEntry.Text, firstnameEntry.Text, lastnameEntry.Text, lang, sec, answerEntry.Text);
            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                Debug.WriteLine("               USER DETAILS ARE VALID");
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

        private void pickerLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
