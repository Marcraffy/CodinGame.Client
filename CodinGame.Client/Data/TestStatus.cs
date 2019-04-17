using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Data
{
    public class TestStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string URL { get; set; }
        public Report Report { get; set; }
        public DateTime Send_Time { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public string Test_URL{ get; set; }
    }
}
