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
        MasterDetailPage master;
        Accounts acc;
        public PremiumBondsXaml(MasterDetailPage master, UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            this.master = master;
            var options = new List<Titles> {
                new Titles ("Transactions"),
                new Titles ("Buy Bonds"),
                new Titles ("Sell Bonds"),
                new Titles ("Have I Won?"),
            };
            listView.ItemsSource = options;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ContentPage page = null;
            var options = e.SelectedItem as Titles;
            switch (options.Name)
            {
                case "Transactions":
                    page = new Transactions(user, acc);
                    break;
                case "Buy Bonds":
                    page = new BuyBonds(user, acc, false);
                    break;
                case "Sell Bonds":
                    page = new SellBonds(user, acc, false);
                    break;
                case "Have I Won?":
                    page = new HaveIwon();
                    break;
                default:
                    page = new PremiumBondsXaml(master, user, acc);
                    break;
            }
            page.BindingContext = acc;
            this.master.Title = options.Name;
            this.master.Detail = new NavigationPage(page);
        }
    }

}