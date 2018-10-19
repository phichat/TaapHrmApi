using System;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
namespace TaapHrmApi.Model
{
    [MySqlCharset("utf8")]
    public class HrmTestQuestionSet
    {
        public int Id { get; set; }
        [MySqlCharset("utf8")]
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public int? IsActive { get; set; }
        public int UpdateUserPosi { get; set; }
        public DateTime? UpdateDatePosi { get; set; }
    }

    [MySqlCharset("utf8")]
    public class HrmTestQuestionSetFromBody {
        public int Id { get; set; }
        [MySqlCharset("utf8")]
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public int UpdateUserPosi { get; set; }
        public HrmTestQuestionFormBody Question { get; set; }
    }

    [MySqlCharset("utf8")]
    public class HrmTestQuestionSetResponse
    {
        public int Id { get; set; }
        [MySqlCharset("utf8")]
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public HrmTestQuestionList[] QuestionList { get; set; }
    }

    [MySqlCharset("utf8")]
    public class HrmTestQuestionSetRandom {
        public int Id { get; set; }
        [MySqlCharset("utf8")]
        public string QuestionSet { get; set; }
        public int TimeOut { get; set; }
        public HrmTestQuestionFormBody[] Question { get; set; }
    }
}
