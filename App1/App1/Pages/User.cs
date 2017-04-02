using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1.Pages
{
    public class User
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string id { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string username { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string password { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string email { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string first_name { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string last_name { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string language { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string security_question { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string answer { get; set; }

        public User()
        {
        }

       public User(string username, string password)
       {
           this.username = username;
           this.password = password;
           email = string.Empty;
       }

       public User(string username, string password, string email, string firstname, string lastname, string language, string securityquestion, string securityans)
       {
           this.username = username;
           this.password = password;
           this.email = email;
           first_name = firstname;
           last_name = lastname;
            this.language = language;
            security_question = securityquestion;
            answer = securityans;

       }
   }
}
