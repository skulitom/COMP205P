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
	public partial class ProductsXaml : ContentPage
	{
        string temp;
        UserResponse user;
        MasterDetailPage master;
        RestService obj = new RestService();
        public ProductsXaml (MasterDetailPage master, UserResponse user)
		{
			InitializeComponent ();
            this.user = user;
            this.master = master;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var products = obj.RefreshProductsAsync(user);
            listView.ItemsSource = await products;
        }
    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var products = e.SelectedItem as Products;

            if (products == null)
            {
                return;
            }

            ContentPage page = null;

            switch (products.name)
            {
                case "Shared Premium Bonds":
                    temp = "Shared Premium Bonds";
                    page = new SPSXaml(products);
                    break;
                case "Premium Bonds":
                    temp = "Premium Bonds";
                    page = new PSXaml(products);
                    break;
                case "Direct Saver":
                    temp = "Direct Saver";
                    page = new DSXaml(products);
                    break;
                case "Direct ISA":
                    temp = "Direct ISA";
                    page = new DISAXaml(products);
                    break;
                case "Income Bonds":
                    temp = "Income Bonds";
                    page = new IBXaml(products);
                    break;
                case "Childrens Bonds":
                    temp = "Childrens Bonds";
                    page = new CBXaml(products);
                    break;
                case "Investment Account":
                    temp = "Investment Account";
                    page = new IAXaml(products);
                    break;
                default:
                    page = new ProductsXaml(master, user);
                    break;
            }
            
            page.BindingContext = products;
            page.Title = temp;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = page.Title;
            
        }
    }
}
