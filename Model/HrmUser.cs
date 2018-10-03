using System;
namespace TaapHrmApi.Model
{
    public class HrmUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public DateTime CrDate { get; set; } 
        public string Enable { get; set; }
        public int ComId { get; set; }
        public string Level { get; set; }
        public DateTime UserExpdate { get; set; }
        public int UserSme { get; set; }
        public string Tel { get; set; }
        public string UserIt { get; set; }
    }
}
