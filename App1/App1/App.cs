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
        public App()
        {
            // The root page of your application
            Current.Resources = new ResourceDictionary();
            Color xamarin_color = Color.FromHex("#222222");
            var navigationStyle = new Style(typeof(NavigationPage));
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = xamarin_color };
            navigationStyle.Setters.Add(barBackgroundColorSetter);
            Current.Resources.Add(navigationStyle);
            MainPage = new NavigationPage(new LoginXaml());
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
