using System.ComponentModel.DataAnnotations;

namespace leavemanagement.Models
{
    public class employeelistvm
    {
        public string id { get; set; }

        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime datejoined { get;set; }

        [Display(Name = "Email Address")]
        public string email { get; set; }

    }
}
