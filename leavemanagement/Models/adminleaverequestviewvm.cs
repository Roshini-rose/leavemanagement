using System.ComponentModel.DataAnnotations;

namespace leavemanagement.Models
{
    public class adminleaverequestviewvm
    {
        [Display(Name = "Total Number Of Requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }

        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }

        public List<leaverequestvm> LeaveRequests { get; set; }
    }
}
