using System.ComponentModel.DataAnnotations;

namespace leavemanagement.Models
{
    public class leaveallocationvm
    {
        [Required]
        public int id { get; set; }

        [Display(Name ="Number of Days")]
        [Required]
        [Range(1,50,ErrorMessage ="Invalid number")]
        public int noofdays { get; set; }

        [Required]
        [Display(Name ="Allocation Period")]
        public int period { get; set; }
        public leavetypevm? leavetype{ get; set; }
    }
}