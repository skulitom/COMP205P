using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    class AccountActions
    {
        public string amount { get; set; }
        public string destination { get; set; }

        public AccountActions(string amt)
        {
            amount = amt;
            destination = "";
        }

        public AccountActions(string amt, string dest)
        {
            amount = amt;
            destination = dest;
        }
    }
}
