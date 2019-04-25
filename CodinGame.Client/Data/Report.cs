using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class Report
    {
        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("warnings")]
        public string[] Warnings { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("technologies")]
        public Technologies Technologies { get; set; }

        [JsonProperty("total_duration")]
        public long TotalDuration { get; set; }

        [JsonProperty("total_points")]
        public int TotalPoints { get; set; }

        [JsonProperty("comparative_score")]
        public double ComparativeScore { get; set; }
    }
}