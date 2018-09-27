using System;
namespace TaapHrmApi.Model
{
    public class HrmTestQuestionSet
    {
        public int Id { get; set; }
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public int? IsActive { get; set; }
        public int UpdateUserPosi { get; set; }
        public DateTime? UpdateDatePosi { get; set; }
    }

    public class HrmTestQuestionSetFromBody {
        public int Id { get; set; }
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public int UpdateUserPosi { get; set; }
        public 
    }
}
