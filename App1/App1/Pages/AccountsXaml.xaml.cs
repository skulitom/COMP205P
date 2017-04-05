﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.Pages
{
    public partial class AccountsXaml : ContentPage
    {
        UserResponse user;
        MasterDetailPage master;
        RestService obj = new RestService();
        public AccountsXaml(MasterDetailPage master,  UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            this.master = master;
        }
    protected async override void OnAppearing()
        {
            base.OnAppearing();
            var accounts = obj.RefreshAccountsAsync(user);
            listView.ItemsSource = await accounts;
        }
    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var acc = e.SelectedItem as Accounts;

            if (acc == null)
            {
                return;
            }

            ContentPage page = null;

            string newTitle = "";

            switch (acc.info.name)
            {
                case "Shared Premium Bonds":
                    page = new SharedBondsXaml(user);
                    newTitle = "Shared Premium Bonds";
                    break;
                case "Premium Bonds":
                    page = new PremiumBondsXaml(user);
                    newTitle = "Premium Bonds";
                    break;
                case "Direct Saver":
                    page = new SharedBondsXaml(user);
                    newTitle = "Direct Saver";
                    break;
                case "Direct ISA":
                    page = new SharedBondsXaml(user);
                    newTitle = "Direct ISA";
                    break;
                case "Income Bonds":
                    page = new SharedBondsXaml(user);
                    newTitle = "Income Bonds";
                    break;
                case "Children's Bonds":
                    page = new SharedBondsXaml(user);
                    newTitle = "Children's Bonds";
                    break;
                case "Investment Account":
                    page = new SharedBondsXaml(user);
                    newTitle = "Investment Account";
                    break;
                default:
                    page = new SharedBondsXaml(user);
                    newTitle = "Shared Premium Bonds";
                    break;
            }

            page.BindingContext = acc;
            page.Title = newTitle;
            this.master.Detail = new NavigationPage(page);
            this.master.Title = newTitle;
        }
    }
}
