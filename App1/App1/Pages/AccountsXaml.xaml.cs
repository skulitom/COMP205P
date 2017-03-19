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
        public AccountsXaml()
        {
            InitializeComponent();
            var products = new List<Products> {
                new Products ("Shared Premium Bonds", 1234),
                new Products ("Premium Bonds", 1234),
                new Products ("Direct Saver", 1234),
                new Products ("Direct ISA", 1234),
                new Products ("Income Bonds", 1234),
                new Products ("Childrens Bonds", 1234),
                new Products ("Investment Account", 1234)
            };
            listView.ItemsSource = products;
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var products = e.SelectedItem as Products;

            if (products == null)
            {
                return;
            }

            ContentPage page = null;

            switch (products.Name)
            {
                case "Shared Premium Bonds":
                    page = new SharedBondsXaml();
                    break;
                case "Premium Bonds":
                    page = new HomeXaml();
                    break;
                case "Direct Saver":
                    page = new HomeXaml();
                    break;
                case "Direct ISA":
                    page = new HomeXaml();
                    break;
                case "Income Bonds":
                    page = new HomeXaml();
                    break;
                case "Childrens Bonds":
                    page = new HomeXaml();
                    break;
                case "Investment Account":
                    page = new HomeXaml();
                    break;
                default:
                    page = new HomeXaml();
                    break;
            }

            page.BindingContext = products;
            Navigation.PushAsync(page);
        }
    }
}
