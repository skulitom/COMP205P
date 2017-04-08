using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    public class SyndicateResponse
    {
        public string[] emails_not_found { get; set; }
        public string response { get; set; }
        public Syndicate created { get; set; }

        public SyndicateResponse()
        {

        }
    }
}
