using Newtonsoft.Json;

namespace CodinGame.Data
{
    public class SendTest
    {
        [JsonProperty("candidate_email")]
        public string CandidateEmail { get; set; }

        [JsonProperty("candidate_name")]
        public string CandidateName { get; set; }

        [JsonProperty("recruiter_email")]
        public string RecruiterEmail { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("send_invitation_email")]
        public bool SendInvitationEmail { get; set; }
    }
}