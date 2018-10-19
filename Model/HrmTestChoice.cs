using System;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace TaapHrmApi.Model
{
    [MySqlCharset("utf8")]
    public class HrmTestChoice
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [MySqlCharset("utf8")]
        public string Choice { get; set; }
        [MySqlCharset("utf8")]
        public string Img { get; set; }
        [MySqlCharset("utf8")]
        public string ImgName { get; set; }
        public int IsActive { get; set; }
        public int AnswerChoice { get; set; }
        public int UpdateUserPosi { get; set; }
        public DateTime UpdateDatePosi { get; set; }
    }

    [MySqlCharset("utf8")]
    public class HrmTestChoiceFormBody
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [MySqlCharset("utf8")]
        public string Choice { get; set; }
        [MySqlCharset("utf8")]
        public string Img { get; set; }
        [MySqlCharset("utf8")]
        public string ImgName { get; set; }
        public int IsActive { get; set; }
        public DateTime UpdateDatePosi { get; set; }
        public bool? IsSelect { get; set; }
        public int? UserId { get; set; }
    }
}
