﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace App1.Pages
{
    public static class Constants
    {
        public static string getAccountsURL = "https://safe-atoll-64469.herokuapp.com/bonds/api/accounts/";//key in header
        public static string getAccountDetailsURL = "http://safe-atoll-64469.herokuapp.com/bonds/api/account/"; //requires id at the end
        public static string getUserDetailsURL = "https://safe-atoll-64469.herokuapp.com/bonds/api/user/";//requires username concat at the end
        public static string getProductsURL = "https://safe-atoll-64469.herokuapp.com/bonds/api/productinfo/";
        public static string getTransactionHistoryURL = "";
        public static string authenticationURL = "https://safe-atoll-64469.herokuapp.com/bonds/api/auth/login/";//sent with user json returns key as response
        public static string usersURL = "http://safe-atoll-64469.herokuapp.com/bonds/api/users/";//POST-create new user, PUT-Update user info and GET-gets current users info
        public static string getSyndicatesURL = "https://safe-atoll-64469.herokuapp.com/bonds/api/syndicates/";//key in header
    }
}
