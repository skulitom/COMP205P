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
    public partial class ChangeLanguageXaml : ContentPage
    {
        UserResponse user;
        RestService obj;
        public ChangeLanguageXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            obj = new RestService();
        }

        async private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languagepicker.SelectedIndex == -1)
                {
                    //should we show some kind of error message here?
                }
            else
            {
                User temp = new User();
                temp.key = user.key;
                temp.Language = languagepicker.Items[languagepicker.SelectedIndex];
                await obj.editUserAsync(temp);
                await Navigation.PushAsync(new NavigationXaml(user));
            }
            
        }
    }
}
