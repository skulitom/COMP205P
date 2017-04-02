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
        MasterDetailPage master;
        RestService obj = new RestService();
        public HomeXaml(MasterDetailPage master,UserResponse user)
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

            switch (acc.info.name)
            {
                case "Shared Premium Bonds":
                    page = new SharedBondsXaml(user);
                    break;
                case "Premium Bonds":
                    page = new SharedBondsXaml(user);
                    break;
                case "Direct Saver":
                    page = new SharedBondsXaml(user);
                    break;
                case "Direct ISA":
                    page = new SharedBondsXaml(user);
                    break;
                case "Income Bonds":
                    page = new SharedBondsXaml(user);
                    break;
                case "Childrens Bonds":
                    page = new SharedBondsXaml(user);
                    break;
                case "Investment Account":
                    page = new SharedBondsXaml(user);
                    break;
                default:
                    page = new SharedBondsXaml(user);
                    break;
            }

            page.BindingContext = acc;
            this.master.Detail = page;
            this.master.Title = page.Title;
        }
    }
}
