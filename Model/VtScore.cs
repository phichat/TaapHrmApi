using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model
{
    public partial class VtScore
    {
        public int Id { get; set; }
        public string CareerType { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? Past { get; set; }
        public int? NotPast { get; set; }
        public int? TotalQuestion { get; set; }
    }
}
