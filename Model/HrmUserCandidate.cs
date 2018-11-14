using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model
{
    public partial class HrmUserCandidate
    {
        public int IdCan { get; set; }
        public int StatusCan { get; set; }
        public string UsernameCan { get; set; }
        public string PasswordCan { get; set; }
        public string FullnameCan { get; set; }
        public string EmailCan { get; set; }
        public DateTime AddDateCan { get; set; }
        public DateTime UpdateDateCan { get; set; }
        public int UpdateUserCan { get; set; }
    }
}
