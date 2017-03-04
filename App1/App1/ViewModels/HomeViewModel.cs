using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public class HomeViewModel
    {
        public HomeModel HomeModel { get; set; }

        public HomeViewModel(){
            HomeModel = new HomeModel {
                userName = "Good Afternoon \n John Snow",

            };
        }
    }
}
