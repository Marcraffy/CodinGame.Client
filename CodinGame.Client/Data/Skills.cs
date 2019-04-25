using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class Skills
    {
        [JsonProperty("Design")]
        public ReportSkill Design { get; set; }

        [JsonProperty("Language Knowledge")]
        public ReportSkill LanguageKnowledge { get; set; }

        [JsonProperty("Reliability")]
        public ReportSkill Reliability { get; set; }

        [JsonProperty("Problem Solving")]
        public ReportSkill ProblemSolving { get; set; }
    }
}