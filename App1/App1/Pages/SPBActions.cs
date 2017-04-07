using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    public class SPBActions
    {
        public string kind { get; set; }
        public int amount { get; set; }

        public SPBActions(string kind, int amt)
        {
            amount = amt;
            this.kind = kind;
        }
    }
}
