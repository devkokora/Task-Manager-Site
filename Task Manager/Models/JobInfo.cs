using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class JobInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter somthing.")]
        [Display(Name = "Job Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Details")]
        [StringLength(50, ErrorMessage = "No more than 50 characters")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Time must be within 0 - 999")]
        [Display(Name = "Duration(Hour)")]
        [Range(0, 999, ErrorMessage = "Duration must be between 1 and 999 hours.")]
        public int Duration { get; set; } = 0;
    }
}
