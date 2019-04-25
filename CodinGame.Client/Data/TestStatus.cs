using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class TestStatus
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("report")]
        public Report Report { get; set; }

        [JsonProperty("send_time")]
        public long SendTime { get; set; }

        [JsonProperty("start_time")]
        public long? StartTime { get; set; }

        [JsonProperty("end_time")]
        public long? EndTime { get; set; }

        [JsonProperty("test_url")]
        public string TestURL { get; set; }
    }
}