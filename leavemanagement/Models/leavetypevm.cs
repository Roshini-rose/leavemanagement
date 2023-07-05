using System.ComponentModel.DataAnnotations;

namespace leavemanagement.Models
{
    public class leavetypevm
    {
        public int id { get; set; }

        [Display(Name = "Leave Type Name")]
        [Required]
        public string name { get; set; }

        [Display(Name="Default No.of Days")]
        [Required]
        [Range(0,25,ErrorMessage ="Enter a valid number")]
        public int defaultdays { get; set; }

    }
}
