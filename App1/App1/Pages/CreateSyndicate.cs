using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    public class CreateSyndicate
    {
        public string name { get; set; }

        public string[] emails { get; set; }

        public CreateSyndicate(string name, string[] emails)
        {
            this.name = name;
            this.emails = emails;
        }
    }
}
