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
        UserResponse user;
        MasterDetailPage master;
        RestService obj = new RestService();
        public ProductsXaml (MasterDetailPage master, UserResponse user)
		{
			InitializeComponent();
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
     
            ContentPage page = new individualProducts(products,user);
            page.BindingContext = products;
            page.Title = products.name;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = page.Title;
            
        }
    }
}
