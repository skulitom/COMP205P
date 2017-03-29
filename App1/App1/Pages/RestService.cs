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

        public User authUser { get; private set; }
        public List<Accounts> acc { get; private set; }
        public List<Products> prods { get; private set; }
        public List<TransactionItem> transactions { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<UserResponse> AuthenticateuserAsync(User user)
        {
            var uri = new Uri(string.Format(Constants.authenticationURL, string.Empty));
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"          Response is successful");
                    var temp = await response.Content.ReadAsStringAsync();
                    UserResponse authUser = JsonConvert.DeserializeObject<UserResponse>(temp);
                    return authUser;
                }
                else
                {
                    Debug.WriteLine(@"          Response failed with " + response.StatusCode);    
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
            var uri = new Uri(string.Format(Constants.getUserDetailsURL, string.Empty));
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

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<List<Accounts>> RefreshAccountsAsync(UserResponse user)
        {
            acc = new List<Accounts>();
            var uri = new Uri(string.Format(Constants.getAccountsURL, string.Empty));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", user.key);
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
                    Debug.WriteLine("Unsuccesful response for accounts");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            Debug.WriteLine("LIST OF ACCOUNTS BEING RETURNED: " + acc);
            foreach (Accounts element in acc) {
                Debug.WriteLine("Element ID = " + element.info.id );
            }
            return acc;
        }

        public async Task<List<Products>> RefreshProductsAsync(UserResponse user)
        {
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
                Debug.WriteLine("Element ID = " + element.id);
            }
            return prods;
        }

        public async Task<List<TransactionItem>> RefreshTransactionHistoryAsync()
        {
            transactions = new List<TransactionItem>();
            var uri = new Uri(string.Format(Constants.getTransactionHistoryURL, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    transactions = JsonConvert.DeserializeObject<List<TransactionItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return transactions;
        }

        public async Task editAccountAsync(Accounts acc)
        {
            var uri = new Uri(string.Format(Constants.getAccountsURL, acc.info.id));
            try
            {
                var json = JsonConvert.SerializeObject(acc);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				Account successfully editted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        public async Task editUserAsync(User user)
        {
            var uri = new Uri(string.Format(Constants.getUserDetailsURL, user.ID));
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				UserField successfully changed.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }
    }
}
