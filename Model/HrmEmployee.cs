using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model
{
    public partial class HrmEmployee
    {
        public int IdEmp { get; set; }
        public string NoAzEmp { get; set; }
        public string NoNumberEmp { get; set; }
        public int StatusEmp { get; set; }
        public int DepartPosiIdEmp { get; set; }
        public string FirstnameEmp { get; set; }
        public string LastnameEmp { get; set; }
        public int AddUserEmp { get; set; }
        public DateTime AddDateEmp { get; set; }
        public int UpdateUserEmp { get; set; }
        public DateTime UpdateDateEmp { get; set; }
    }
}
