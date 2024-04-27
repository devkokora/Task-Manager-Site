using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class JobInfo
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter somthing.")]
        [Display(Name = "Job Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Details")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Time must be within 0 - 999")]
        [Display(Name = "Duration")]
        [Range(0, 999, ErrorMessage = "Duration must be between 1 and 999 hours.")]
        public int Duration { get; set; } = 0;
    }
}
