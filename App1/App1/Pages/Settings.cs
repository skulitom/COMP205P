using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{
    class Settings
    {
        public string Name { get; private set; }

        public Settings(string name)
        {
            Name = name;
        }
    }
}
