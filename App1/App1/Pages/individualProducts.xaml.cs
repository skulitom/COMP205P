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
    public partial class individualProducts : ContentPage
    {
        Uri uri;
        Products product;
        RestService obj = new RestService();
        UserResponse user;
        public individualProducts(Products product,UserResponse user)
        {
            InitializeComponent();
            Title = product.name;
            this.product = product;
            uri = new Uri(product.link);
            BindingContext = product;
            this.user = user;
        }

        protected override void OnAppearing()
        {
            BindingContext = product;
        }

        protected void OnRedirectButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(uri);
        }

        protected async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            if (product.id != 7 && product.id !=6)
            {
                var check = await obj.registerAccountAsync(user, product.id);
                if (check)
                {
                    registerMessageLabel.Text = "Your account with this product has been openeed";
                }
                else
                {
                    registerMessageLabel.Text = "Your request has failed. Please try again later.";
                }
            }
            else
            {
                registerMessageLabel.Text = "We are still trying to get this working";
            }
        }
    }
}