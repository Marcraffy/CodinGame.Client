namespace Abp.AppFactory.CodinGame.Client.CodinGame
{
    public class Report
    {
        public long Duration { get; set; }
        public string[] Warnings { get; set; }
        public int Points { get; set; }
        public double Score { get; set; }
        public Technologies Technologies { get; set; }
        public long Total_Duration { get; set; }
        public int Total_Points { get; set; }
        public double Comparative_Score { get; set; }
    }
}