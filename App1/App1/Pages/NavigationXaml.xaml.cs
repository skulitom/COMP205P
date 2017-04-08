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
    public partial class NavigationXaml : MasterDetailPage
    {
        UserResponse user;
        User userDetails;
        RestService obj = new RestService();
        public NavigationXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            this.Detail = new NavigationPage(new Pages.HomeXaml(this, user));
            this.Title = this.Detail.Title;
        }

        protected async override void OnAppearing()
         {
             this.userDetails = await obj.getUserDetailsAsync(user);
             BindingContext = userDetails;
         }

    public void SettingsButton_Clicked(object sender, EventArgs e)
        {

            this.Detail = new NavigationPage(new Pages.SettingsXaml(this, user));
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void HomeButton_Clicked(object sender, EventArgs e)
        {

            this.Detail = new NavigationPage(new Pages.HomeXaml(this, user));
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void Contactus_Clicked(object sender, EventArgs e)
        {
            this.Detail = new NavigationPage(new Pages.ContactusXaml());
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void Accounts_Clicked(object sender, EventArgs e)
        {

            this.Detail = new NavigationPage(new Pages.AccountsXaml(this, user));
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

        public void Products_Clicked(object sender, EventArgs e)
        {
            this.Detail = new NavigationPage(new Pages.ProductsXaml(this, user));
            this.Title = this.Detail.Title;
            // change to the detail page
            this.IsPresented = false;
        }

    }
}