using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    public class Syndicate
    {
        public string name  { get; set; }

        public Owner owner { get; set; }

        public int balance { get; set; }

        public int winnings { get; set; }

        public Members[] members { get; set; }


    }

    public class Owner
    {

        public int id { get; set; }

        public string username { get; set; }

        public string first_name { get; set; }
    }

    public class Members
    {
        public int id { get; set; }

        public string username { get; set; }

        public string first_name { get; set; }

        public int share { get; set; }
    }

}
