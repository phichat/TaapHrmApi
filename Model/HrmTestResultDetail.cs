using System;
namespace TaapHrmApi.Model
{
    public class HrmTestResultDetail
    {
        public int Id { get; set; }
        public int TestResultId { get; set; }
        public int QuestionId { get; set; }
        public string TestedQuestion { get; set; }
        public string TestedAnswer { get; set; }
        public string Answer { get; set; }
        public bool Result { get; set; }
    }
}
