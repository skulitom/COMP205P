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
    public partial class UserManagement : ContentPage
    {
        UserResponse user;
        Accounts acc;
        RestService obj;
        Syndicate binder;
        int removeid;
        public UserManagement(UserResponse user, Accounts acc)
        {
            InitializeComponent();
            this.user = user;
            this.acc = acc;
            obj = new RestService();
        }

        async void OnAddUserButtonClicked(object sender, EventArgs e)
        {
            AddorDelUser temp = new AddorDelUser(addUserEntry.Text);
            Boolean check = await obj.UserMangementAsync(user, acc.id.ToString(), "add", temp);
            if (check)
            {
                addUserMessageLabel.Text = "Added User: " + addUserEntry.Text;
                addUserEntry.Text = string.Empty;
            }
            else
            {
                addUserMessageLabel.Text = "This is not a valid user";
                addUserEntry.Text = string.Empty;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var members = obj.getSyndicateDetailsAsync(user,acc.id.ToString());
            User me = await obj.getUserDetailsAsync(user);
            binder = await members;
            foreach (Members temp in binder.members)
            {
                if (temp.username != me.username)
                    pickerRemoveUser.Items.Add(temp.username);
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerRemoveUser.SelectedIndex == -1)
            {
                removeUserMessageLabel.Text = "Pick a valid user";
            }
            else
            {
                string picktrans = pickerRemoveUser.Items[pickerRemoveUser.SelectedIndex];
                System.Diagnostics.Debug.WriteLine("                        user picked is " + picktrans);
                foreach (Members temp in binder.members)
                {
                    if (temp.username.Equals(picktrans))
                    {
                        System.Diagnostics.Debug.WriteLine("                        user id for removal is set to " + temp.id);
                        removeid = temp.id;
                    }
                }
            }

        }

        async void OnRemoveUserButtonClicked(object sender, EventArgs e)
        {
            AddorDelUser temp = new AddorDelUser(removeid);
            Boolean check = await obj.UserMangementAsync(user, acc.id.ToString(), "remove", temp);
            if (check)
            {
                removeUserMessageLabel.Text = "User succesfully removed";
            }
            else
            {
                removeUserMessageLabel.Text = "Only the creator of the group can remove a user";
            }
        }
    }
}
