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
        public string key { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string ID { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string username { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string password { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string email { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string FirstName { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string LastName { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string Language { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string SecurityQuestion { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string Answer { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string ProfilePic { get; set; }

        public User()
         {
        }

       public User(string username, string password)
       {
           this.username = username;
           this.password = password;
           email = string.Empty;
       }

       public User(string username, string password, string email)
       {
           this.username = username;
           this.password = password;
           this.email = email;
       }

       public User(string id, string email, string firstname, string lastname)
       {
           ID = id;
           this.email = email;
           FirstName = firstname;
           LastName = lastname;
       }
   }
}
