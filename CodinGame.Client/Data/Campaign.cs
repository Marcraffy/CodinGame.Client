using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class Campaign
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }
    }
}