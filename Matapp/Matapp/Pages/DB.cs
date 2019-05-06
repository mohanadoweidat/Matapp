using Newtonsoft.Json;
using Matapp.Database;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Matapp.Pages
{
    public class DB
    {
       //Must update the link!!
        private const string L = "http://www.ml.somee.com/api/";
        private const string AC = "Accounts";
        private const string Da = "Images";
        
        public static List<Account> accounts = new List<Account>();
        //Fix
        public static List<Image> Bilder = new List<Image>();
       
         
        public static async Task LoadAccounts()
        {
            accounts.Clear();
            HttpClient client = new HttpClient();
            var responce = await client.GetStringAsync(L+AC);
            accounts = JsonConvert.DeserializeObject<List<Account>>(responce);
        }

        public static async void Attach(Account acc, Image img)
        {
            if(acc.Attached != null && acc.Attached != "")
            {
                acc.Attached += ","+img.ID;
            } else
            {
                acc.Attached = img.ID+"";
            }
        }

        public static async Task RemoveAccountTotally(Account ac)
        {
            await ClearImages(ac);
            await RemoveAccount(ac);
        }

        public static async Task ClearImages(Account ac)
        {
            string[] a = ac.Attached.Split(',');
            if (a.Length > 0)
            {
                for (int x = 0; x < a.Length; x++)
                {
                    await RemoveImage(int.Parse(a[x]));
                }
            }
        }

        
        public static async Task<HttpResponseMessage> RemoveAccount(Account account)
        {
            HttpClient client = new HttpClient();
            return await client.DeleteAsync(L + AC +"/" + account.ID);
        }
         
        public static async Task<HttpResponseMessage> EditAccount(Account account)
        {
            var json = JsonConvert.SerializeObject(account);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var responce = await client.PutAsync(L + AC + "/" + account.ID, content);
            return responce;
        }

        public static async Task<HttpResponseMessage> AddAccount(Account account)
        {
            var json = JsonConvert.SerializeObject(account);
            var c = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            return await client.PostAsync(L + AC, c);
        }
         
        public static Account getAccountByName(string name)
        {
            for(int x = 0; x < accounts.Count; x++)
            {
                if(accounts[x].Username == name)
                {
                    return accounts[x];
                }
            }
            return null;
        }

         
        public static bool CheckStudent(Account account)
        {
            for(int x = 0; x < accounts.Count; x++)
            {
                if(accounts[x].Username == account.Username)
                {
                    return true;
                }
            }
            return false;
        }



        public static async Task<Image> LoadImage(Image _image)
        {
            HttpClient client = new HttpClient();
            try
            {
                var responce = await client.GetStringAsync(L + Da + "/" + _image.ID);
                return JsonConvert.DeserializeObject<Image>(responce);
            }
            catch (Exception e)
            {
                return null;
            }
        }
          public static async Task<HttpResponseMessage> RemoveImage(int id)
          {
            HttpClient client = new HttpClient();
            return await client.DeleteAsync(L + Da + "/" + id);
          }

        public static async Task AddImage(Image img)
        {
            var json = JsonConvert.SerializeObject(img);
            var c = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var r = await client.PostAsync(L + Da, c);
        }

        public static async Task<HttpResponseMessage> EditImage(Image img)
        {
            var json = JsonConvert.SerializeObject(img);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var responce = await client.PutAsync(L + AC + "/" + img.ID, content);
            return responce;
        }








    }
}
