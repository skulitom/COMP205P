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
        Boolean sharedornot;
        public BuyBonds(UserResponse user, Accounts acc, Boolean sharedornot)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
            this.sharedornot = sharedornot;
        }

        async void OnBuyButtonClicked(object sender, EventArgs e)
        {
            Boolean check;
            if (sharedornot)
                check = await obj.SPBActionAsync(user, acc.id.ToString(), new SPBActions("BUY", Int32.Parse(buyBondsEntry.Text)));
            else
                check = await obj.PBActionAsync(user, new SPBActions("BUY", Int32.Parse(buyBondsEntry.Text)));
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
