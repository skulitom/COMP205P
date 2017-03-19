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
        RestService obj = new RestService();
        public AccountsXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
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

            //switch (acc.Name)
            //{
            //    case "Shared Premium Bonds":
            //        page = new ;
            //        break;
            //    case "Premium Bonds":
            //        page = new ;
            //        break;
            //    case "Direct Saver":
            //        page = new ;
            //        break;
            //    case "Direct ISA":
            //        page = new ;
            //        break;
            //    case "Income Bonds":
            //        page = new ;
            //        break;
            //    case "Childrens Bonds":
            //        page = new ;
            //        break;
            //    case "Investment Account":
            //        page = new ;
            //        break;
            //    default:
            //        page = new ;
            //        break;
            //}

            page.BindingContext = acc;
            Navigation.PushAsync(page);
        }
    }
}
