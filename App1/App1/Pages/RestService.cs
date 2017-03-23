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
        public User authUser { get; private set; }
        public List<Accounts> acc { get; private set; }
        public List<Products> prods { get; private set; }
        public List<TransactionItem> transactions { get; private set; }

        public RestService()
        {

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
            HttpClient client = new HttpClient();
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
            HttpClient client = new HttpClient();
            acc = new List<Accounts>();
            var uri = new Uri(string.Format(Constants.getAccountsURL, string.Empty));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", user.key);
            try
            {
                Debug.WriteLine("               TRYING TO GET LISTS OF ACCOUNTS");
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    acc = JsonConvert.DeserializeObject<List<Accounts>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return acc;
        }

        public async Task<List<Products>> RefreshProductsAsync()
        {
            HttpClient client = new HttpClient();
            prods = new List<Products>();
            var uri = new Uri(string.Format(Constants.getProductsURL, string.Empty));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    prods = JsonConvert.DeserializeObject<List<Products>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return prods;
        }

        public async Task<List<TransactionItem>> RefreshTransactionHistoryAsync()
        {
            HttpClient client = new HttpClient();
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
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format(Constants.getAccountsURL, acc.ID));
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
            HttpClient client = new HttpClient();
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
