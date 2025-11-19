using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        // Fake "database" for demo/class purposes
        private static readonly List<StudentAccountViewModel> _students = new()
        {
            new StudentAccountViewModel
            {
                Name = "John Smith",
                StudentId = "A12345",
                Major = "Computer Science",
                Year = "Junior",
                Address = "123 Campus Dr, Corpus Christi, TX",
                EmergencyContactName = "Jane Smith",
                EmergencyContactPhone = "361-555-1111"
            },
            new StudentAccountViewModel
            {
                Name = "Maria Garcia",
                StudentId = "B67890",
                Major = "Business Administration",
                Year = "Senior",
                Address = "456 Islander Way, Corpus Christi, TX",
                EmergencyContactName = "Carlos Garcia",
                EmergencyContactPhone = "361-555-2222"
            }
            // Add more sample students as needed
        };

        // GET: /Account/AccountInformation
        [HttpGet]
        public IActionResult AccountInformation()
        {
            // Empty model for the form
            return View(new StudentAccountViewModel());
        }

        // POST: /Account/AccountInformation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AccountInformation(StudentAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.HasResult = false;
                model.ErrorMessage = "Please fill out both fields.";
                return View(model);
            }

            // Simple lookup: match by StudentId (case-insensitive)
            var student = _students
                .FirstOrDefault(s => s.StudentId != null &&
                                     s.StudentId.ToLower() == model.StudentId!.ToLower());

            if (student == null)
            {
                model.HasResult = false;
                model.ErrorMessage = "No student found with that ID.";
                return View(model);
            }

            // Copy data into the model we send to the view
            model.Name = student.Name;
            model.Major = student.Major;
            model.Year = student.Year;
            model.Address = student.Address;
            model.EmergencyContactName = student.EmergencyContactName;
            model.EmergencyContactPhone = student.EmergencyContactPhone;

            model.HasResult = true;
            model.ErrorMessage = null;

            return View(model);
        }
    }
}
