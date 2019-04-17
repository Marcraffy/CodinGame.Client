using CodinGame.Exceptions;
using CodinGame.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodinGame
{
    public class Client
    {
        private readonly string key;
        private readonly HttpClient client;

        private const string ApiURL = "https://www.codingame.com/assessment/api/v1.1/";

        public Client(string key)
        {
            this.key = key;
            client = new HttpClient
            {
                BaseAddress = new Uri(ApiURL)
            };
            client.DefaultRequestHeaders.Add("API-Key", this.key);
        }

        public async Task<List<Campaign>> GetCampaigns()
        {
            var response = await client.GetAsync("campaigns");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<List<Campaign>>(content);
                return output;
            }

            var error = JsonConvert.DeserializeObject<Error>(content);
            throw new CodinGameException(error);
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