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
    public partial class IAXaml : ContentPage
    {
        public IAXaml()
        {
            var browser = new WebView();

            browser.Source = "https://www.nsandi.com/investment-account";

            Content = browser;
        }
    }
}
