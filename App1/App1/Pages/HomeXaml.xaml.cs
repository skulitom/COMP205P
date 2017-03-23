using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using App1.ViewModels;
using System.Diagnostics;

namespace App1.Pages
{
    public partial class HomeXaml : ContentPage
    {
        UserResponse user;
        RestService obj = new RestService();
        public HomeXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("           ON APPEARING");
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

            //pages to be filled in when created by artem
            switch (acc.Name)
            {
                case "Shared Premium Bonds":
                    page = new HomeXaml(user);
                    break;
                case "Premium Bonds":
                    page = new HomeXaml(user);
                    break;
                case "Direct Saver":
                    page = new HomeXaml(user);
                    break;
                case "Direct ISA":
                    page = new HomeXaml(user);
                    break;
                case "Income Bonds":
                    page = new HomeXaml(user);
                    break;
                case "Childrens Bonds":
                    page = new HomeXaml(user);
                    break;
                case "Investment Account":
                    page = new HomeXaml(user);
                    break;
                default:
                    page = new HomeXaml(user);
                    break;
            }

            page.BindingContext = acc;
            Navigation.PushAsync(page);
        }
    }
}
