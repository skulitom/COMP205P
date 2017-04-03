using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    class TransactionItem
    {
        public string id { get; set; }
        public string created { get; set; }
        public string kind { get; set; }
        public string amount { get; set; }
        public string account { get; set; }
    }
}
