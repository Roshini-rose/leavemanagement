using leavemanagement.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace leavemanagement.Models
{
    public class leaverequestvm: leaverequestcreatevm
    {
        public int id { get;set; }

        [Display(Name ="Date Requested")]
        public DateTime daterequested { get; set; }

        [Display(Name = "Leave Type")]
        public leavetypevm leavetype { get; set; }
        public bool? approved { get; set; }
        public bool cancelled { get; set; }

        public string? requestingemployeeid { get; set; }
        public employeelistvm employee { get; set;}
    }
}
