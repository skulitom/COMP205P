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
    public partial class GeneralBondsXaml : ContentPage
    {
        RestService obj = new RestService();
        UserResponse user;
        MasterDetailPage master;
        Accounts acc;
        public GeneralBondsXaml(MasterDetailPage master, UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.master = master;
            var options = new List<Titles> {
                new Titles ("Transactions"),
                new Titles ("Deposit"),
                new Titles ("Withdraw"),
                new Titles ("Transfer"),
                new Titles ("Account Details"),
            };
            this.acc = acc;
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
                case "Deposit":
                    page = new Deposit(user, acc);
                    break;
                case "Withdraw":
                    page = new Withdraw(user, acc);
                    break;
                case "Transfer":
                    page = new Transfer(user, acc);
                    break;
                default:
                    page = new GeneralBondsXaml(master,user, acc);
                    break;
            }
            page.BindingContext = acc;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = page.Title;
        }
    }
}