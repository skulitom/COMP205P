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
        public string Name { get; private set; }

        public string Description { get; private set; }

        public int ProductNo { get; private set; }

        public float InterestRate { get; private set; }

        public int MinDeposit { get; private set; }

        public int MaxDeposit { get; private set; }

        public string Image { get; private set; }

        public Products(string name)
        {
            Name = name;
        }

        public Products(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }

        public Products(string name, int productNo)
        {
            Name = name;
            ProductNo = productNo;
        }

        public Products(string name, string description, int productNo)
        {
            Name = name;
            Description = description;
            productNo = ProductNo;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
