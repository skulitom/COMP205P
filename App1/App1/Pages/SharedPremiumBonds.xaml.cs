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
    public partial class SharedPremiumBonds : ContentPage
    {
        RestService obj = new RestService();
        UserResponse user;
        MasterDetailPage master;
        Accounts acc;
        public SharedPremiumBonds(MasterDetailPage master, UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            this.master = master;
            var settings = new List<Titles> {
                new Titles ("Buy Bonds"),
                new Titles ("Sell Bonds"),
                new Titles ("Add/Delete a member"),
                new Titles ("Have I Won?"),
                new Titles ("What is my payout?"),
                new Titles ("Account Details"),
                new Titles ("Leave the group"),
            };
            listView.ItemsSource = settings;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ContentPage page = null;
            var options = e.SelectedItem as Titles;
            switch (options.Name)
            {
                case "Buy Bonds":
                    page = new BuyBonds(user, acc);
                    break;
                case "Sell Bonds":
                    page = new SellBonds(user, acc);
                    break;
                case "Add/Delete a member":
                    page = new UserManagement(user, acc);
                    break;
                case "Account Details":
                    page = new AccountDetails();
                    break;
                case "Have I Won?":
                    page = new AccountDetails();
                    break;
                default:
                    page = new PremiumBondsXaml(master, user, acc);
                    break;
            }
            page.BindingContext = acc;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = page.Title;
        }
    }
}