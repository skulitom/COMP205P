using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using App1.ViewModels;

namespace App1.Pages
{
    public partial class HomeXaml : ContentPage
    {
        UserResponse user;
        User userDetails;
        MasterDetailPage master;
        RestService obj = new RestService();
        public HomeXaml(MasterDetailPage master, UserResponse user)
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
            this.userDetails = await obj.getUserDetailsAsync(user);
            BindingContext = userDetails;
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
                case "Premium Bonds":
                    page = new PremiumBondsXaml(this.master,user, acc);
                    newTitle = "Premium Bonds";
                    break;
                case "Direct Saver":
                    page = new GeneralBondsXaml(this.master,user, acc);
                    newTitle = "Direct Saver";
                    break;
                case "Direct ISA":
                    page = new GeneralBondsXaml(this.master, user, acc);
                    newTitle = "Direct ISA";
                    break;
                case "Income Bonds":
                    page = new GeneralBondsXaml(this.master, user, acc);
                    newTitle = "Income Bonds";
                    break;
                case "Children's Bonds":
                    page = new GeneralBondsXaml(this.master, user, acc);
                    newTitle = "Children's Bonds";
                    break;
                case "Investment Account":
                    page = new GeneralBondsXaml(this.master, user, acc);
                    newTitle = "Investment Account";
                    break;
                default:
                    page = new SharedPremiumBonds(this.master, user, acc);
                    newTitle = acc.info.name;
                    break;
            }
            page.BindingContext = acc;
            page.Title = newTitle;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = newTitle;
        }
    }
}