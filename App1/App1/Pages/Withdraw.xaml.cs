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
    public partial class Withdraw : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj;
        public Withdraw(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
        }

        async void OnWithdrawButtonClicked(object sender, EventArgs e)
        {
            var check = await obj.accountActionAsync(user, acc.id.ToString(), "withdraw", new AccountActions(Int32.Parse(withdrawEntry.Text)));
            if (check)
            {
                withdrawMessageLabel.Text = "Withdraw has been made for £" + withdrawEntry.Text;
                withdrawEntry.Text = string.Empty;
            }
            else
            {
                withdrawMessageLabel.Text = "This is not a valid withdraw";
                withdrawEntry.Text = string.Empty;
            }
        }
    }
}
