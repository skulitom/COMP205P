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
    public partial class ChangeProfilePictureXaml : ContentPage
    {
        UserResponse user;
        RestService obj;
        public ChangeProfilePictureXaml(UserResponse user)
        {
            InitializeComponent();
            this.user = user;
            obj = new RestService();
        }
    }
}
