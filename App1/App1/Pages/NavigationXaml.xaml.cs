using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.Pages
{
    public partial class NavigationXaml : MasterDetailPage
    {
        public NavigationXaml()
        {
            InitializeComponent();
        }

        public void SettingsButton_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.SettingsXaml();
            // change to the detail page
            this.IsPresented = false;
        }

        public void HomeButton_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.HomeXaml();
            // change to the detail page
            this.IsPresented = false;
        }

        public void Contactus_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.ContactusXaml();
            // change to the detail page
            this.IsPresented = false;
        }

        public void Accounts_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.AccountsXaml();
            // change to the detail page
            this.IsPresented = false;
        }

        public void Products_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.ProductsXaml();
            // change to the detail page
            this.IsPresented = false;
        }

    }
}
