using System.ComponentModel.DataAnnotations;

namespace leavemanagement.Models
{
    public class employeelistvm
    {
        public string id { get;set; }
        [Display(Name ="First Name")]
        public string firstname { get;set; }
        [Display(Name = "Last Name")]
        public string lastname { get;set; }
        [Display(Name = "Date Joined")]
        public string datejoined { get;set; }
        [Display(Name = "Email Address")]
        public string email { get; set; }

    }
}
