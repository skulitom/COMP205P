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
    public partial class SharedBondsXaml : ContentPage
    {
        RestService obj = new RestService();
        UserResponse user;
        public SharedBondsXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var accounts = obj.RefreshAccountsAsync(user);
            listView.ItemsSource = await accounts;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            ContentPage page = null;
            var acc = e.SelectedItem as Accounts;

            if (acc == null)
            {
                return;
            }


            page.BindingContext = acc;
            Navigation.PushAsync(page);
        }
    }
}
