using System;
namespace TaapHrmApi.Model
{
    public class HrmTestQuestion
    {
        public int Id { get; set; }
        public int QuestionSetId { get; set; }
        public string Question { get; set; }
        public string Img { get; set; }
        public string ImgName { get; set; }
        public int Answer { get; set; }
        public int IsActive { get; set; }
        public int UpdateUserPosi { get; set; }
        public DateTime UpdateDatePosi { get; set; }
    }

    public class HrmTestQuestionList {
        public int Id { get; set; }
        public string Question { get; set; }
        public string ImgName { get; set; }
        public int IsActive { get; set; }
    }

    public class HrmTestQuestionFormBody
    {
        public int Id { get; set; }
        public int QuestionSetId { get; set; }
        public string Question { get; set; }
        public string Img { get; set; }
        public string ImgName { get; set; }
        public int? Answer { get; set; }
        public int? IsActive { get; set; }
        public int UpdateUserPosi { get; set; }
        public HrmTestChoice[] Choice { get; set; }
    }
}
