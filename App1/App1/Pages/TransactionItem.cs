using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    class TransactionItem
    {
        public string name { get; set; }
        public string description { get; set; }
        public string dateAndTime { get; set; }
        public int amount { get; set; }
        public bool type { get; set; } //true for money going out and false for money coming in
    }
}
