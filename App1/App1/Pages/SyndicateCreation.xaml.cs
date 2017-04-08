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
    public partial class SyndicateCreation : ContentPage
    {

        UserResponse user;
        List<Email> syndicateUserList;
        RestService obj = new RestService();
        public SyndicateCreation(UserResponse user)
        {
            InitializeComponent();
            syndicateUserList = new List<Email>();
            this.user = user;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Email email = new Email();
            email.name = addUserEntry.Text;
            if (addUserEntry.Text != null) {
                bool exists = false;
                for (int i = syndicateUserList.Count - 1; i >= 0; --i)
                {
                    if (syndicateUserList[i].Equals(addUserEntry.Text)) {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    syndicateUserList.Add(email);
                }
                addUserEntry.Text = "";
                listView.ItemsSource = syndicateUserList;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            int count=0;
            if (!addSyndicateEntry.Text.Equals("")) 
            {
                string syndicate_name = addSyndicateEntry.Text;
                if(syndicateUserList.Count != 0)
                {
                    string[] temp = new string[syndicateUserList.Count];
                    for(int i=0;i<syndicateUserList.Count;i++)
                    {
                        temp[i] = syndicateUserList[i].name;
                    }
                    CreateSyndicate temp1 = new CreateSyndicate(syndicate_name, temp);
                    var arr = await obj.createSyndicateAsync(user, temp1);
                    System.Diagnostics.Debug.WriteLine("EMAILS ARRAY IS SET");
                    string[] emails_not_found = arr;
                    foreach(string h in emails_not_found)
                    {
                        System.Diagnostics.Debug.WriteLine(h);
                        count++;
                    }
                    System.Diagnostics.Debug.WriteLine("EMAILS ARRAY IS SET again");
                    if (count == 0)
                    {
                        // users added
                        messageLabelSubmit.Text = "Users have been added";
                    }
                    else
                    {
                        //display users that could not be added
                        messageLabelSubmit.Text = "Some users could not be added";
                    }
                }
                else
                {
                    messageLabelSubmit.Text = "Please add in users";
                }
            }
            else
            {
                messageLabelSubmit.Text = "Please enter the name for the syndicate";
            }
            syndicateUserList.Clear();
            listView.ItemsSource = syndicateUserList;
        }
    }
}
