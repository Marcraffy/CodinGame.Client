using Abp.AppFactory.CodinGame.Client.CodinGame;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Abp.AppFactory.CodinGame.Client
{
    public class CodinGameClient
    {
        private readonly string token;
        private readonly HttpClient client;

        private const string ApiURL = "https://www.codingame.com/assessment/api/v1.1/";

        public CodinGameClient(string token)
        {
            this.token = "token";
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiURL);
            client.DefaultRequestHeaders.Add("API-Key", this.token);
        }

        public async Task<List<Campaign>> GetCampaigns()
        {
            var response = await client.GetAsync("campaigns");
            if (response.IsSuccessStatusCode)
            {
                var output = Newtonsoft.Json.JsonConvert.DeserializeObject<Campaign[]>(await response.Content.ReadAsStringAsync());
            }
            throw new NotImplementedException();
        }

        public Task<TestSent> SendTest(SendTest input)
        {
            throw new NotImplementedException();
        }

        public Task<TestStatus> GetStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task CancelTest(int Id)
        {
            throw new NotImplementedException();
        }

        public Task ResendInvitation(int Id)
        {
            throw new NotImplementedException();
        }
    }
}