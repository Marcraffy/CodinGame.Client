using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class Technologies
    {
        [JsonProperty("C#")]
        public ReportTechnology CSharp { get; set; }

        [JsonProperty("javascript")]
        public ReportTechnology JavaScript { get; set; }
    }
}