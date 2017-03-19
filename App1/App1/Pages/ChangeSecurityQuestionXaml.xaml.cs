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
        RestService obj;
        public ChangeSecurityQuestionXaml(UserResponse user)
        {
            InitializeComponent();
            temp = new Pages.User();
            temp.key = user.key;
            obj = new RestService();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            temp.SecurityQuestion = pickerChangeSecurityQuestion.Items[pickerChangeSecurityQuestion.SelectedIndex];
        }

        async private void OnChangeQuestionButtonClicked(object sender, EventArgs e)
        {
            // store the ans and question in the database
            if (secretanswer.Text != string.Empty)
                temp.Answer = secretanswer.Text;
            await obj.editUserAsync(temp);
        }
    }
}
