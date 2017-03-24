using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProjectTrack.Services
{
    public class NozbeService
    {
        public string Key { get; set; }
        public NozbeService(string email, string password)
        {
            //Key = Login(email, password);
            Key = "xxx";
        }

        public async Task<string> Login(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://webapp.nozbe.com/api/login/email-"+email+"/password-"+password);
                return await result.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Projects()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://webapp.nozbe.com/api/projects/key-" + Key);
                return await result.Content.ReadAsStringAsync();
            }
            
        }

        public async Task<string> Tasks(string Id)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("https://webapp.nozbe.com/api/actions/what-project/id-"+Id+"/key-"+Key);
                return await result.Content.ReadAsStringAsync();
            }
        }


    }
}
