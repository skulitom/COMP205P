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
    public partial class SharedBondsXaml : ContentPage
    {
        RestService obj = new RestService();
        UserResponse user;
        public SharedBondsXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            var options = new List<Titles> {
                new Titles ("Transactions"),
                new Titles ("Deposit"),
                new Titles ("Withdraw"),
                new Titles ("Transfer"),
                new Titles ("Account Details"),
            };
            listView.ItemsSource = options;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var accounts = obj.RefreshAccountsAsync(user);
            
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            ContentPage page = null;
            ContentPage page2 = null;
            var acc = e.SelectedItem as Accounts;
            var options = e.SelectedItem as Titles;

            if (acc == null)
            {
                return;
            }


            page.BindingContext = acc;
            page2.BindingContext = options;
            Navigation.PushAsync(page);
            Navigation.PushAsync(page2);
        }
    }
}