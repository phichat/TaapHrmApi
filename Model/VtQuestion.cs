using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model {
    public partial class VtQuestion {
        public int Id { get; set; }
        public string Question { get; set; }
        public string ImgName { get; set; }
        public string ImgSource { get; set; }
        public int Answer { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class ViewQuestion {
        public int Id { get; set; }
        public string Question { get; set; }
        public string ImgName { get; set; }
        public string ImgSource { get; set; }
        public int Answer { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
        public List<ViewChoice> Choice { get; set; }
    }

    public partial class QuestionTest{
        public List<Examination> Examination {get; set;}       
    }

    public class Examination {
        public int QuestionId {get; set;}
        public int Answer {get; set;}
        public string CareerType {get;set;}
        public int UserId {get; set;}
        public string UserName {get;set;}
    }
}