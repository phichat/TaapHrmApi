using System;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace TaapHrmApi.Model
{
    public class HrmTestChoice
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Choice { get; set; }
        public string Img { get; set; }
        public string ImgName { get; set; }
        public int IsActive { get; set; }
        public int AnswerChoice { get; set; }
        public int UpdateUserPosi { get; set; }
        public DateTime UpdateDatePosi { get; set; }
    }
    
    public class HrmTestChoiceFormBody
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Choice { get; set; }
        public string Img { get; set; }
        public string ImgName { get; set; }
        public int IsActive { get; set; }
        public DateTime UpdateDatePosi { get; set; }
        public bool? IsSelect { get; set; }
        public int? UserId { get; set; }
    }
}
