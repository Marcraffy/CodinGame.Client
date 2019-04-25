using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class TestSent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("test_url")]
        public string URL { get; set; }
    }
}