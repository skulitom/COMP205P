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
    public partial class Transactions : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj = new RestService();
        public Transactions(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var task = obj.getTransactionsAsync(user, acc.id.ToString());
            listView.ItemsSource = await task;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}
