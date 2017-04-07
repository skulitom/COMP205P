using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1.Pages
{
    class RestService
    {
        HttpClient client;

        public User user { get; private set; }
        public List<Accounts> acc { get; private set; }
        public Accounts account { get; private set; }
        public List<Products> prods { get; private set; }
        public List<TransactionItem> transactions { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<UserResponse> AuthenticateuserAsync(User user)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(Constants.authenticationURL, string.Empty));
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"          Login is successful");
                    var temp = await response.Content.ReadAsStringAsync();
                    UserResponse authUser = JsonConvert.DeserializeObject<UserResponse>(temp);
                    return authUser;
                }
                else
                {
                    Debug.WriteLine(@"          Logging in failed with " + response.StatusCode);    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR authenticating {0}", ex.InnerException.Message);
            }
            return null;
        }

        public async Task<UserResponse> addUserAsync(User user)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(Constants.userCreateURL, string.Empty));
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				User Successfully Signed up.");
                    var temp = await response.Content.ReadAsStringAsync();
                    UserResponse authUser = JsonConvert.DeserializeObject<UserResponse>(temp);
                    return authUser;
                }
                else
                {
                    Debug.WriteLine(@"				User Failed Signing up with response code as " + response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<User> getUserDetailsAsync(UserResponse userResponse)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(Constants.userUpdateViewURL, string.Empty));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + userResponse.key);
            try
            {
                Debug.WriteLine("               TRYING TO GET USER DETAILS");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                    Debug.WriteLine("Succesful response for getting details");
                }
                else
                {
                    Debug.WriteLine("Unsuccesful response for getting details with code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            Debug.WriteLine("User BEING RETURNED: " + user.username);
            return user;
        }

        public async Task<Boolean> updateUserDetailsAsync(UserResponse userResponse, User user)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(Constants.userUpdateViewURL, string.Empty));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + userResponse.key);
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Debug.WriteLine("       JSON OBJECT TO CHANGE USER DETAILS: " + json);
                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				User setting Successfully changed.");
                    var temp = await response.Content.ReadAsStringAsync();
                    UserResponse authUser = JsonConvert.DeserializeObject<UserResponse>(temp);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"				User setting Unsuccessful with code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return false;
        }

        public async Task<List<Accounts>> RefreshAccountsAsync(UserResponse user)
        {
            HttpClient client = new HttpClient();
            acc = new List<Accounts>();
            var uri = new Uri(string.Format(Constants.getAccountsURL, string.Empty));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + user.key);
            try
            {
                Debug.WriteLine("               TRYING TO GET LISTS OF ACCOUNTS");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    acc = JsonConvert.DeserializeObject<List<Accounts>>(content);
                    Debug.WriteLine("Succesful response for accounts");
                }
                else
                {
                    Debug.WriteLine("Unsuccesful response for accounts with code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            Debug.WriteLine("LIST OF ACCOUNTS BEING RETURNED: " + acc);
            foreach (Accounts element in acc) {
                Debug.WriteLine("Account ID = " + element.id );
            }
            return acc;
        }

        public async Task<List<Products>> RefreshProductsAsync(UserResponse user)
        {
            HttpClient client = new HttpClient();
            prods = new List<Products>();
            var uri = new Uri(string.Format(Constants.getProductsURL, string.Empty));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + user.key);
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    prods = JsonConvert.DeserializeObject<List<Products>>(content);
                    Debug.WriteLine("Succesful response for products");
                }
                else
                {
                    Debug.WriteLine("Unsuccesful response for products");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            Debug.WriteLine("LIST OF PRODUCTS BEING RETURNED: " + prods);
            foreach (Products element in prods)
            {
                Debug.WriteLine("Product ID = " + element.id);
            }
            return prods;
        }

        public async Task<List<TransactionItem>> RefreshTransactionHistoryAsync(UserResponse token, string accNo)
        {
            HttpClient client = new HttpClient();
            string url = Constants.userAccountAction + accNo + "/transactions/";
            transactions = new List<TransactionItem>();
            var uri = new Uri(string.Format(url));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + token.key);
            try
            {
                Debug.WriteLine("               TRYING TO GET LISTS OF TRANSACTIONS");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("               SUCCESS response from transactions");
                    var content = await response.Content.ReadAsStringAsync();
                    transactions = JsonConvert.DeserializeObject<List<TransactionItem>>(content);
                }
                else
                {
                    Debug.WriteLine("               FAILED response from transactions with code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return transactions;
        }

        //action = deposit/transfer/withdraw
        public async Task<Boolean> accountActionAsync(UserResponse token,string accNo, string action, AccountActions accAct)
        {
            HttpClient client = new HttpClient();
            string url = Constants.userAccountAction + accNo + "/" + action + "/";
            var uri = new Uri(string.Format(url));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + token.key);
            try
            {
                Debug.WriteLine("               TRYING TO PERFORM " + action);
                var json = JsonConvert.SerializeObject(accAct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Debug.WriteLine("                   JSON " + json);
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Account action successful: " + action);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"				Account action failed with response code as " + response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return false;
        }

        public async Task<Accounts> getAccountDetailsAsync(UserResponse user, string accNo)
        {
            HttpClient client = new HttpClient();
            account = new Accounts();
            var uri = new Uri(string.Format(Constants.getAccountDetailsURL, accNo));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + user.key);
            try
            {
                Debug.WriteLine("               TRYING TO GET ACCOUNT DETAILS");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    account = JsonConvert.DeserializeObject<Accounts>(content);
                    Debug.WriteLine("Succesful response for account");
                }
                else
                {
                    Debug.WriteLine("Unsuccesful response for account with response code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return account;
        }

        public async Task<Syndicate> getSyndicateDetailsAsync(UserResponse user, string accNo)
        {
            HttpClient client = new HttpClient();
            Syndicate syn = new Syndicate();
            string url = Constants.getSyndicateDetailsURL + accNo + "/";
            var uri = new Uri(string.Format(url));
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + user.key);
            try
            {
                Debug.WriteLine("               TRYING TO GET Syndicate DETAILS");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    syn = JsonConvert.DeserializeObject<Syndicate>(content);
                    Debug.WriteLine("Succesful response for syndicate");
                }
                else
                {
                    Debug.WriteLine("Unsuccesful response for syndicate with response code " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return syn;
        }

        public async Task<Boolean> SPBActionAsync(UserResponse token, string accNo, SPBActions accAct)
        {
            HttpClient client = new HttpClient();
            string url = Constants.sharedAccountAction + accNo + "/bonds/";
            var uri = new Uri(string.Format(url));
            Debug.WriteLine("               URI " + uri);
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + token.key);
            try
            {
                Debug.WriteLine("               TRYING TO PERFORM " + accAct.kind);
                var json = JsonConvert.SerializeObject(accAct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Debug.WriteLine("                   JSON " + json);
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				SPB action successful: " + accAct.kind);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"				SPB action failed with response code as " + response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return false;
        }

        public async Task<Boolean> UserMangementAsync(UserResponse token, string accNo,string action, string email, int id)
        {
            string temp = "";
            HttpClient client = new HttpClient();
            string url = Constants.sharedAccountAction + accNo + "/manage/" + action + "_member/";
            var uri = new Uri(string.Format(url));
            Debug.WriteLine("               URI " + uri);
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + token.key);
            try
            {
                Debug.WriteLine("               TRYING TO PERFORM " + action);
                if (action.Equals("add"))
                    temp = @"{user: '" + email + "'}";
                else if(action.Equals("remove"))
                    temp = @"{user: " + id + "}";
                var json = JsonConvert.SerializeObject(temp);
                var content = new StringContent(json, Encoding.UTF8, "application /json");
                Debug.WriteLine("                   JSON " + json);
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				User management successful: " + action);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"				User management failed with response code as " + response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return false;
        }

        public async Task<Boolean> PBActionAsync(UserResponse token, SPBActions accAct)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(Constants.soleBondsAction));
            Debug.WriteLine("               URI " + uri);
            client.DefaultRequestHeaders.Add("Authorization", "TOKEN " + token.key);
            try
            {
                Debug.WriteLine("               TRYING TO PERFORM " + accAct.kind);
                var json = JsonConvert.SerializeObject(accAct);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Debug.WriteLine("                   JSON " + json);
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				PB action successful: " + accAct.kind);
                    return true;
                }
                else
                {
                    Debug.WriteLine(@"				PB action failed with response code as " + response.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return false;
        }
    }
}
