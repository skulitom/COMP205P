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
		public ProductsXaml ()
		{
			InitializeComponent ();
            var products = new List<Products> {
                new Products ("Shared Premium Bonds", "Come together with friends and put money fourth to increase your chances of winning ", "front.png"),
                new Products ("Premium Bonds", "1.25%. Rate used to clculate prize fund. The odds of each £1 unit are 30,000 to 1 each month. The rate and odds are variable", "front.png"),
                new Products ("Direct Saver", "0.80% gross/AER, variable", "front.png"),
                new Products ("Direct ISA", "1.00% tax-free/AER,variable", "front.png"),
                new Products ("Income Bonds", "1.00% gross/AER, variable", "front.png"),
                new Products ("Childrens Bonds", "2.50% tax-free/AER, guaranteed for 5 years", "front.png"),
                new Products ("Investment Account", "0.45% gross/AER,varaible", "front.png")
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
                    temp = "Shared Premium Bonds";
                    page = new SPSXaml();
                    break;
                case "Premium Bonds":
                    temp = "Premium Bonds";
                    page = new PSXaml();
                    break;
                case "Direct Saver":
                    temp = "Direct Saver";
                    page = new DSXaml();
                    break;
                case "Direct ISA":
                    temp = "Direct ISA";
                    page = new DISAXaml();
                    break;
                case "Income Bonds":
                    temp = "Income Bonds";
                    page = new IBXaml();
                    break;
                case "Childrens Bonds":
                    temp = "Childrens Bonds";
                    page = new CBXaml();
                    break;
                case "Investment Account":
                    temp = "Investment Account";
                    page = new IAXaml();
                    break;
                default:
                    page = new ProductsXaml();
                    break;
            }
            
            page.BindingContext = products;
            page.Title = temp;
            Navigation.PushAsync(page);
            
        }
    }
}
