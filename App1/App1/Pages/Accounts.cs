using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    class Accounts
    {
        public string created { get; set; }

        public Info info { get; set; }

        public Accounts()
        {

        }
    }

    class Info
    {
        public int id { get; set; }

        public string name { get; set; }
        public string description { get; set; }

        public string interest_rate { get; set; }
        public int min_deposit { get; set; }
        public int payout_period { get; set; }
    }
}
