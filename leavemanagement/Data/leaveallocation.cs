
using System.ComponentModel.DataAnnotations.Schema;

namespace leavemanagement.Data
{
    public class leaveallocation:baseentity
    {
        public int noofdays { get; set; }

        [ForeignKey("leavetypeid")]
        public leavetype leavetype { get; set; }
        public int period { get; set; }
        public int leavetypeid { get; set; }    

        public string employeeid { get; set; }

    }
}
