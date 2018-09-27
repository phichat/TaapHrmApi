using System;
namespace TaapHrmApi.Model
{
    public class HrmTestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QuestionSet { get; set; }
        public int Pass { get; set; }
        public int Fail { get; set; }
        public int Total { get; set; }
    }
}
