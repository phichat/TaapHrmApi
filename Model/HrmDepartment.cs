using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model
{
    public partial class HrmDepartment
    {
        public int IdDep { get; set; }
        public int StatusDep { get; set; }
        public string NameDep { get; set; }
        public string CodeNameDep { get; set; }
        public int AddUserDep { get; set; }
        public DateTime AddDateDep { get; set; }
        public int UpdateUserDep { get; set; }
        public DateTime UpdateDateDep { get; set; }
    }
}
