using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class StudentAccountViewModel
    {
        // Input fields from the form
        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Student ID")]
        public string? StudentId { get; set; }

        // Output fields (what we show after lookup)
        public string? Major { get; set; }
        public string? Year { get; set; }
        public string? Address { get; set; }

        [Display(Name = "Emergency Contact Name")]
        public string? EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Phone")]
        public string? EmergencyContactPhone { get; set; }

        // Helper flags
        public bool HasResult { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
