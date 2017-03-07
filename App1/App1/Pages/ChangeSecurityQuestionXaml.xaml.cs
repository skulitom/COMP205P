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
        string ques;
        public ChangeSecurityQuestionXaml()
        {
            InitializeComponent();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ques = pickerChangeSecurityQuestion.Items[pickerChangeSecurityQuestion.SelectedIndex];
        }

        private void OnChangeQuestionButtonClicked(object sender, EventArgs e)
        {
            // store the ans and question in the database
        }
    }
}
