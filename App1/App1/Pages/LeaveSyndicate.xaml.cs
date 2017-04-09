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
    public partial class LeaveSyndicate : ContentPage
    {

        UserResponse user;
        Accounts acc;
        RestService obj = new RestService();
        public LeaveSyndicate(UserResponse user)
        {
            InitializeComponent();
            this.user = user;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var syn = e.SelectedItem as Syndicate;


            
        }


    }
}
