using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    public class AddorDelUser
    {
        public string email { get; set; }
        public int id { get; set; }

        public AddorDelUser(string email)
        {
            this.email = email;
            this.id = 0;
        }
        public AddorDelUser(int id)
        {
            this.id = id;
            this.email = "";
        }
    }
}
