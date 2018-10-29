using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model
{
    public partial class HrmDepartmentPosition
    {
        public int IdDeposi { get; set; }
        public int StatusDeposi { get; set; }
        public int DepIdDeposi { get; set; }
        public string NameDeposi { get; set; }
        public string CodeNameDeposi { get; set; }
        public int LevelDeposi { get; set; }
        public int RoleDeposi { get; set; }
        public int PetitionDeposi { get; set; }
        public int AddUserDeposi { get; set; }
        public DateTime AddDateDeposi { get; set; }
        public int UpdateUserDeposi { get; set; }
        public DateTime UpdateDateDeposi { get; set; }
    }
}
