using System;
using System.Collections.Generic;

namespace TaapHrmApi.Model
{
    public partial class HrmCandidateManpower
    {
        public int IdCanMan { get; set; }
        public int CanIdCanMan { get; set; }
        public int ManIdCanMan { get; set; }
        public int StatusCanMan { get; set; }
        public int StatusProcessCanMan { get; set; }
        public string ScoreProfileCanMan { get; set; }
        public string SetTestCanMan { get; set; }
        public string DateInterviewCanMan { get; set; }
        public string DetailsInterviewCanMan { get; set; }
        public string ScoreInterviewCanMan { get; set; }
        public string DateWorkCanMan { get; set; }
        public string DetailsWorkCanMan { get; set; }
        public int? SentTestByCanMan { get; set; }
        public int? SentEmailTestCanMan { get; set; }
        public int? UpdateUserCanMan { get; set; }
        public DateTime UpdateDateCanMan { get; set; }
    }
}
