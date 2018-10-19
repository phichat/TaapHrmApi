using System;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace TaapHrmApi.Model
{
    [MySqlCharset("utf8")]
    public class HrmTestQuestion
    {
        public int Id { get; set; }
        public int QuestionSetId { get; set; }
        [MySqlCharset("utf8")]
        public string Question { get; set; }
        [MySqlCharset("utf8")]
        public string Img { get; set; }
        [MySqlCharset("utf8")]
        public string ImgName { get; set; }
        public int Answer { get; set; }
        public int IsActive { get; set; }
        public int UpdateUserPosi { get; set; }
        public DateTime UpdateDatePosi { get; set; }
    }

    [MySqlCharset("utf8")]
    public class HrmTestQuestionList {
        public int Id { get; set; }
        [MySqlCharset("utf8")]
        public string Question { get; set; }
        [MySqlCharset("utf8")]
        public string ImgName { get; set; }
        public int IsActive { get; set; }
    }

    [MySqlCharset("utf8")]
    public class HrmTestQuestionFormBody
    {
        public int Id { get; set; }
        public int QuestionSetId { get; set; }
        [MySqlCharset("utf8")]
        public string Question { get; set; }
        [MySqlCharset("utf8")]
        public string Img { get; set; }
        [MySqlCharset("utf8")]
        public string ImgName { get; set; }
        public int? Answer { get; set; }
        public int? IsActive { get; set; }
        public int UpdateUserPosi { get; set; }
        public HrmTestChoice[] Choice { get; set; }
    }
}
