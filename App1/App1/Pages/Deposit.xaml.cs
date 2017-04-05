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
    public partial class Deposit : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj;
        public Deposit(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
        }

        async void OnDepositButtonClicked(object sender, EventArgs e)
        {
            var check = await obj.accountActionAsync(user, acc.id.ToString(), "deposit", new AccountActions(Int32.Parse(depositEntry.Text)));
            if (check)
            {
                depositMessageLabel.Text = "Deposit has been made for £" + depositEntry.Text;
                depositEntry.Text = string.Empty;
            }
            else
            {
                depositMessageLabel.Text = "This is not a valid deposit";
                depositEntry.Text = string.Empty;
            }
        }
    }
}
