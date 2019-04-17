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

        public async Task<List<Campaign>> GetCampaignsAsync() =>
            JsonConvert.DeserializeObject<List<Campaign>>(await GetAsync("campaigns"));

        public async Task<TestSent> SendTestAsync(SendTest input)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(input));
            return JsonConvert.DeserializeObject<TestSent>(await PostAsync($"campaigns/{input.Id}/actions/send", requestBody));
        }

        public async Task<TestStatus> GetStatusAsync(int id) =>
            JsonConvert.DeserializeObject<TestStatus>(await GetAsync($"tests/{id}"));

        public async Task CancelTestAsync(int id)
        {
            await PostAsync($"tests/{id}/actions/cancel");
        }

        public async Task ResendInvitationAsync(int id)
        {
            await PostAsync($"tests/{id}/actions/resend");
        }

        private async Task<string> GetAsync(string uri) =>
            await GetContentAsync(await client.GetAsync(uri));

        private async Task<string> PostAsync(string uri, StringContent requestBody = null) =>
            await GetContentAsync(await client.PostAsync(uri, requestBody ?? new StringContent(String.Empty)));

        private async Task<string> GetContentAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new CodinGameException(JsonConvert.DeserializeObject<Error>(content));
            }

            return content;
        }
    }
}