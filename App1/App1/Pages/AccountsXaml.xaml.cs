using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.Pages
{
    public partial class AccountsXaml : ContentPage
    {
        UserResponse user;
        MasterDetailPage master;
        RestService obj = new RestService();
        public AccountsXaml(MasterDetailPage master,  UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            this.master = master;
        }
    protected async override void OnAppearing()
        {
            base.OnAppearing();
            var accounts = obj.RefreshAccountsAsync(user);
            listView.ItemsSource = await accounts;
        }
    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var acc = e.SelectedItem as Accounts;

            if (acc == null)
            {
                return;
            }

            ContentPage page = null;
            string newTitle = "";

            switch (acc.info.name)
            {
                case "Shared Premium Bonds":
                    page = new GeneralBondsXaml(user,acc);
                    newTitle = "Shared Premium Bonds";
                    break;
                case "Premium Bonds":
                    page = new PremiumBondsXaml(user, acc.id);
                    newTitle = "Premium Bonds";
                    break;
                case "Direct Saver":
                    page = new GeneralBondsXaml(user, acc);
                    newTitle = "Direct Saver";
                    break;
                case "Direct ISA":
                    page = new GeneralBondsXaml(user, acc);
                    newTitle = "Direct ISA";
                    break;
                case "Income Bonds":
                    page = new GeneralBondsXaml(user, acc);
                    newTitle = "Income Bonds";
                    break;
                case "Children's Bonds":
                    page = new GeneralBondsXaml(user, acc);
                    newTitle = "Children's Bonds";
                    break;
                case "Investment Account":
                    page = new GeneralBondsXaml(user, acc);
                    newTitle = "Investment Account";
                    break;
                default:
                    page = new AccountsXaml(master,user);
                    newTitle = "Shared Premium Bonds";
                    break;
            }

            page.BindingContext = acc;
            page.Title = newTitle;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = page.Title;
        }
    }
}
