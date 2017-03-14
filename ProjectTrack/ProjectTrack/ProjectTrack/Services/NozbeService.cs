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

        public string Login(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("https://webapp.nozbe.com/api/login/email-"+email+"/password-"+password);
                return result.Result.Content.ReadAsStringAsync().Result;
            }
        }

        public string Projects()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync("https://webapp.nozbe.com/api/projects/key-" + Key);
                return result.Result.Content.ReadAsStringAsync().Result;
            }
            
        }


    }
}
