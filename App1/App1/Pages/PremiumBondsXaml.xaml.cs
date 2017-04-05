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
    public partial class PremiumBondsXaml : ContentPage
    {
        RestService obj = new RestService();
        UserResponse user;
        int accNo;
        public PremiumBondsXaml(UserResponse user, int accNo)
        {
            InitializeComponent();
            this.user = user;
            this.accNo = accNo;
            var options = new List<Titles> {
                new Titles ("Transactions"),
                new Titles ("Deposit"),
                new Titles ("Withdraw"),
                new Titles ("Transfer"),
                new Titles ("Have I Won?"),
                new Titles ("Account Details"),
            };
            listView.ItemsSource = options;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //account = await obj.RefreshAccountsAsync(user);

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            ContentPage page = null;
            ContentPage page2 = null;
            var options = e.SelectedItem as Titles;

           //page.BindingContext = account;
            page2.BindingContext = options;
            Navigation.PushAsync(page);
            Navigation.PushAsync(page2);
        }
    }

}