namespace leavemanagement.Models
{
    public class employeeleaverequestviewvm
    {
        public employeeleaverequestviewvm(List<leaveallocationvm> leaveallocations, List<leaverequestvm> leaverequests)
        {
            Leaveallocations = leaveallocations;
            Leaverequests = leaverequests;
        }
        public List<leaveallocationvm> Leaveallocations { get; set; }  
        public List<leaverequestvm> Leaverequests { get; set; }    
    }
}
