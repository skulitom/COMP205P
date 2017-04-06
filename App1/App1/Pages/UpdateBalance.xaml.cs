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
    public partial class UpdateBalance : ContentPage
    {
        UserResponse user;
        User temp;
        RestService obj;
        public UpdateBalance(UserResponse user,User temp)
        {
            InitializeComponent();
            obj = new RestService();
            this.user = user;
            this.temp = temp;
        }

        async private void OnDepositButtonClicked(object sender, EventArgs e)
        {
            if (amountEntry.Text != string.Empty)
            {
                temp.balance += Int32.Parse(amountEntry.Text);
                await obj.updateUserDetailsAsync(user, temp);
                amountMessageLabel.Text = "Balance has been updated to " + temp.balance;
            }
            else
            {
                amountMessageLabel.Text = "Please fill in appropriate amounts";
            }
        }

        async private void OnWithdrawButtonClicked(object sender, EventArgs e)
        {
            if (amountEntry.Text != string.Empty)
            {
                temp.balance -= Int32.Parse(amountEntry.Text);
                await obj.updateUserDetailsAsync(user, temp);
                amountMessageLabel.Text = "Balance has been updated to " + temp.balance;
            }
            else
            {
                amountMessageLabel.Text = "Please fill in appropriate amounts";
            }
        }
    }
}
