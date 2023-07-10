namespace leavemanagement.Models
{
    public class leaveallocationeditvm:leaveallocationvm
    {
        public string employeeid { get; set; }
        public int leavetypeid { get; set; }
        public employeelistvm? employee { get; set; }    

    }
}
