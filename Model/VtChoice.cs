using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model {
    public partial class VtChoice {
        public int Id { get; set; }
        public int? IdQuestion { get; set; }
        public string Choice { get; set; }
        public string ImgName { get; set; }
        public string ImgSource { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class ViewChoice {
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public string Choice { get; set; }
        public string ImgName { get; set; }
        public string ImgSource { get; set; }

    }
}