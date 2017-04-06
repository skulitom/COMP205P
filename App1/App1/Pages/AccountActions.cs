using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    public class AccountActions
    {
        public int amount { get; set; }
        public int destination { get; set; }

        public AccountActions(int amt)
        {
            amount = amt;
            destination = 0;
        }

        public AccountActions(int amt, int dest)
        {
            amount = amt;
            destination = dest;
        }
    }
}
