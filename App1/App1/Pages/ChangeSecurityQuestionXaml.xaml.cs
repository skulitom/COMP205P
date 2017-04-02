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
            temp.security_question = pickerChangeSecurityQuestion.Items[pickerChangeSecurityQuestion.SelectedIndex];
        }

        async private void OnChangeQuestionButtonClicked(object sender, EventArgs e)
        {
            // store the ans and question in the database
            if (secretanswer.Text != string.Empty)
                temp.answer = secretanswer.Text;
            await obj.updateUserDetailsAsync(user,temp);
        }
    }
}
