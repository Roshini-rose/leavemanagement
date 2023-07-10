using System.ComponentModel.DataAnnotations.Schema;

namespace leavemanagement.Data
{
    public class leaverequest:baseentity
    {
        public DateTime startdate { get;set;}
        public DateTime enddate { get;set;}

        [ForeignKey("leavetypeid")]
        public leavetype leavetype { get; set;}
        public int leavetypeid { get; set;}
        public DateTime daterequested { get; set;}
        public string requestcomments { get; set;}
        public bool? approved { get; set;}
        public bool cancelled { get; set;}
        public string requestingemployeeid { get; set;}
    }
}
