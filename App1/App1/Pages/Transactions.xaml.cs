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
    public partial class Transactions : ContentPage
    {
        UserResponse user;
        Accounts acc;
        public Transactions(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            var settings = new List<Titles> {
                new Titles ("Buy Bonds"),
                new Titles ("Sell Bonds"),
                new Titles ("Add/Delete a member"),
                new Titles ("Have I Won?"),
                new Titles ("What is my payout?"),
                new Titles ("Account Details"),
                new Titles ("Leave the group"),
            };
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ContentPage page = null;
            var options = e.SelectedItem as Titles;
            switch (options.Name)
            {
                case "Buy Bonds":
                    page = new BuyBonds(user, acc, true);
                    break;
                case "Sell Bonds":
                    page = new SellBonds(user, acc, true);
                    break;
                case "Add/Delete a member":
                    page = new UserManagement(user, acc);
                    break;
                case "Have I Won?":
                    page = new HaveIWonXaml();
                    break;
                default:
                    page = new HaveIWonXaml();
                    break;
            }
            page.BindingContext = acc;
        }
    }
}
