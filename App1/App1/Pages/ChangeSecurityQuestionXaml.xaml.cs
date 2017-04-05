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
    public partial class ChangeSecurityQuestionXaml : ContentPage
    {
       User temp;
        UserResponse user;
       RestService obj;
       public ChangeSecurityQuestionXaml(UserResponse user, User temp)
        {
            InitializeComponent();
            obj = new RestService();
            this.user = user;
            this.temp = temp;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerChangeSecurityQuestion.SelectedIndex == -1)
            {
                questionMessageLabel.Text = "Please fill in the appropriate fields";
            }
            else
            {
                temp.security_question = pickerChangeSecurityQuestion.Items[pickerChangeSecurityQuestion.SelectedIndex];
                questionMessageLabel.Text = string.Empty;
            }
        }

        async private void OnChangeQuestionButtonClicked(object sender, EventArgs e)
        {
            if (secretanswer.Text != string.Empty)
            {
                temp.answer = secretanswer.Text;
                await obj.updateUserDetailsAsync(user, temp);
                questionMessageLabel.Text = "Security details have been updated";
            }
            else
            {
                questionMessageLabel.Text = "Please fill in the appropriate fields";
            }
        }
    }
}
