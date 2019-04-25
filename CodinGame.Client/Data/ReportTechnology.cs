using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class ReportTechnology
    {
        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("skills")]
        public Skills Skills { get; set; }

        [JsonProperty("total_points")]
        public int TotalPoints { get; set; }
    }
}