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
    public partial class Transfer : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj;
        List<Accounts> binder = new List<Accounts>();
        int account;
        public Transfer(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
            account = 0;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var accounts = obj.RefreshAccountsAsync(user);
            binder = await accounts;
            foreach(Accounts temp in binder)
            {
                if(temp.id != acc.id)
                    transferpicker.Items.Add(temp.info.name);
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transferpicker.SelectedIndex == -1)
            {
                //should we show some kind of error message here?
            }
            else
            {
                string picktrans = transferpicker.Items[transferpicker.SelectedIndex];
                System.Diagnostics.Debug.WriteLine("                        account picked is " + picktrans);
                foreach (Accounts temp in binder)
                {
                    if (temp.info.name.Equals(picktrans))
                    {
                        System.Diagnostics.Debug.WriteLine("                        account id for transfer is set to " + temp.id);
                        account = temp.id;
                    }
                }
            }

        }

        async void OnTransferButtonClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("                     transfer button clicked");
            var check = await obj.accountActionAsync(user, acc.id.ToString(), "transfer", new AccountActions(Int32.Parse(transferEntry.Text), account));
                if (check)
                {
                    transferMessageLabel.Text = "Transfer has been made for £" + transferEntry.Text + " to " + account;
                    transferEntry.Text = string.Empty;
                }
                else
                {
                    transferMessageLabel.Text = "This is not a valid transfer";
                    transferEntry.Text = string.Empty;
                }
        }
    }
}
