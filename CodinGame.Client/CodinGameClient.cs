﻿using CodinGame.Data;
using CodinGame.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Campaign>> GetCampaignsAsync() =>
            Deserialize<List<Campaign>>(await GetAsync("campaigns"));

        public async Task<TestStatus> GetStatusAsync(int id) =>
            Deserialize<TestStatus>(await GetAsync($"tests/{id}"));

        public async Task<TestSent> SendTestAsync(int id, SendTest input)
        {
            var requestBody = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
            return Deserialize<TestSent>(await PostAsync($"campaigns/{id}/actions/send", requestBody));
        }

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
            await GetContentAsync(await client.PostAsync(uri, requestBody ?? new StringContent(String.Empty, Encoding.UTF8, "application/json")));

        private static async Task<string> GetContentAsync(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return content;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new CodinGameException(Deserialize<Error>(content));
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new CodinGameException("The API Key is invalid or expired");
            }
            else
            {
                throw new CodinGameException("An unexpected error occurred");
            }
        }

        private static T Deserialize<T>(string message)
        {
            var output = JsonConvert.DeserializeObject<T>(message);
            if ((object)output == null)
            {
                throw new CodinGameException("An error occurred while deserializing the response body");
            }
            return output;
        }
    }
}