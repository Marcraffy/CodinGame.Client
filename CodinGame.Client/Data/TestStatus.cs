namespace CodinGame.Data
{
    public class TestStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string URL { get; set; }
        public Report Report { get; set; }
        public long Send_Time { get; set; }
        public long Start_Time { get; set; }
        public long End_Time { get; set; }
        public string Test_URL { get; set; }
    }
}