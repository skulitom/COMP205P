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
    public partial class DSXaml : ContentPage
    {
        Uri uri;
        Products product;
        public DSXaml(Products product)
        {
            InitializeComponent();
            this.product = product;
            uri = new Uri("https://www.nsandi.com/direct-saver");
            BindingContext = product;
        }

        protected async override void OnAppearing()
        {
            BindingContext = product;
        }

        async void OnRedirectButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(uri);
        }
    }
}
