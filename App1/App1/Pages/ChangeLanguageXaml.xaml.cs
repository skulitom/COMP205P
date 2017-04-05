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
        User temp;
        UserResponse user;
        RestService obj;
        public ChangeLanguageXaml(UserResponse user, User temp)
        {
            InitializeComponent();
            this.user = user;
            this.temp = temp;
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
                temp.language = languagepicker.Items[languagepicker.SelectedIndex];
                await obj.updateUserDetailsAsync(user, temp);
                await Navigation.PushAsync(new NavigationXaml(user));
            }
            
        }
    }
}
