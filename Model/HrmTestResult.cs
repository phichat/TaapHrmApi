using System;
namespace TaapHrmApi.Model
{
    public class HrmTestResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionSetId { get; set; }
        public int TimeOut { get; set; }
        public int TimeUse { get; set; }
        public int Pass { get; set; }
        public int Fail { get; set; }
        public int Total { get; set; }
    }

    public class HrmTestVerifyQuestion {
        public int QuestionSetId { get; set; }
        public int UserId { get; set; }
        public int TimeUse { get; set; }
        public int TimeOut { get; set; }
        public QuestionVerify[] Questions { get; set; }
    }

    public class QuestionVerify {
        public int QuestionId { get; set; }
        public int Answer { get; set; }
    }

    public class HrmTestVerifyQuestionResponse {
        public int Id { get; set; }
        public int QuestionSetId { get; set; }
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public int TimeUse { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int Pass { get; set; }
        public int Fail { get; set; }
        public int Total { get; set; }
        public HrmTestResultDetail[] ResultDetail { get; set; }
    }

    
}
