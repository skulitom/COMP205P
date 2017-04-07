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
    public partial class SellBonds : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj;
        Boolean sharedornot;
        public SellBonds(UserResponse user, Accounts acc, Boolean sharedornot)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
            this.sharedornot = sharedornot;
        }

        async void OnSellButtonClicked(object sender, EventArgs e)
        {
            Boolean check;
                if(sharedornot)
                    check = await obj.SPBActionAsync(user, acc.id.ToString(), new SPBActions("SELL", Int32.Parse(sellBondsEntry.Text)));
                else
                    check = await obj.PBActionAsync(user, new SPBActions("SELL", Int32.Parse(sellBondsEntry.Text)));
            if (check)
            {
                sellMessageLabel.Text = "Sold £" + sellBondsEntry.Text;
                sellBondsEntry.Text = string.Empty;
            }
            else
            {
                sellMessageLabel.Text = "You do not have enough bonds";
                sellBondsEntry.Text = string.Empty;
            }
        }
    }
}
