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
    public partial class BuyBonds : ContentPage
    {

        UserResponse user;
        Accounts acc;
        RestService obj;
        public BuyBonds(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
        }

        async void OnBuyButtonClicked(object sender, EventArgs e)
        {
            var check = await obj.SPBActionAsync(user, acc.id.ToString(), new SPBActions("BUY",Int32.Parse(buyBondsEntry.Text)));
            if (check)
            {
                buyMessageLabel.Text = "Bought £" + buyBondsEntry.Text;
                buyBondsEntry.Text = string.Empty;
            }
            else
            {
                buyMessageLabel.Text = "You do not have enough balance";
                buyBondsEntry.Text = string.Empty;
            }
        }
    }
}
