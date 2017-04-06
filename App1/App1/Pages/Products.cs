using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1.Pages
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public string interest_rate { get; set; }

        public int min_deposit { get; set; }
        public int payout_period { get;set; }

        public Products()
        {

        }
        public Products(string name)
        {
            this.name = name;
        }

        //public Products(string name, string description, string image)
        //{
        //    Name = name;
        //    Description = description;
        //    Image = image;
        //}

        //public Products(string name, int productNo)
        //{
        //    Name = name;
        //    ProductNo = productNo;
        //}

        //public Products(string name, string description, int productNo)
        //{
        //    Name = name;
        //    Description = description;
        //    productNo = ProductNo;
        //}

        public override string ToString()
        {
            return name;
        }
    }
}
