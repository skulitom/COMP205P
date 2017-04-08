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
    public partial class Transactions : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj = new RestService();
        public Transactions(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var task = obj.getTransactionsAsync(user, acc.id.ToString());
            listView.ItemsSource = await task;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private async void startDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            var task = obj.getTransactionsAsync(user, acc.id.ToString());
            var allTasks = await task;
            for (int i = allTasks.Count - 1; i >= 0; --i)
            {
                if (Convert.ToDateTime(GetUntilOrEmpty(allTasks[i].created)) > startDate.Date && Convert.ToDateTime(GetUntilOrEmpty(allTasks[i].created)) < endDate.Date)
                {
                }
                else {
                    allTasks.RemoveAt(i);
                }
            }
            listView.ItemsSource = allTasks;
        }

        private async void endDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            var task = obj.getTransactionsAsync(user, acc.id.ToString());
            var allTasks = await task;
            for (int i = allTasks.Count - 1; i >= 0; --i)
            {
                if (Convert.ToDateTime(GetUntilOrEmpty(allTasks[i].created)) > startDate.Date && Convert.ToDateTime(GetUntilOrEmpty(allTasks[i].created)) < endDate.Date)
                {
                }
                else
                {
                    allTasks.RemoveAt(i);
                }
            }
            listView.ItemsSource = allTasks;
        }

        public static string GetUntilOrEmpty(string text, string stopAt = "T")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }
}
