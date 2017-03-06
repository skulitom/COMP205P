using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App1.Pages;
using Xamarin.Forms;

namespace App1
{
    public class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            // The root page of your application
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginXaml());
            }
            else
            {
                MainPage = new NavigationPage(new NavigationXaml());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
