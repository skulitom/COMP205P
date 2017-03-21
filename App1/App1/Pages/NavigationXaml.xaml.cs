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
        UserResponse user;
        public NavigationXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;

        }

        public void SettingsButton_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.SettingsXaml(user);
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void HomeButton_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.HomeXaml(user);
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void Contactus_Clicked(object sender, EventArgs e)
        {
            this.Detail = new Pages.ContactusXaml();
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void Accounts_Clicked(object sender, EventArgs e)
        {

            this.Detail = new Pages.AccountsXaml(user);
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void Products_Clicked(object sender, EventArgs e)
        {
            this.Detail = new Pages.ProductsXaml();
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

    }
}
