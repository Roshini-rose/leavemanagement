using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace leavemanagement.Models
{
    public class leaverequestcreatevm: IValidatableObject
    {
        [Required]
        [Display(Name="Start Date")]
        public DateTime? startdate { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime? enddate { get; set; }

        [Required]
        [Display(Name = "Leave Type Id")]
        public int leavetypeid { get; set; }
        public SelectList? leavetypes { get; set; }

        [Display(Name = "Request Comments")]
        public string? requestcomments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(startdate > enddate)
            {
                yield return new ValidationResult("Start date must be before End date", new[] { nameof(startdate), nameof(enddate) });
            }

            if (requestcomments?.Length > 200)
            {
                yield return new ValidationResult("Comments are too long", new[] { nameof(requestcomments) });
            }
        }
    }
}
