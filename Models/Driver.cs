using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.RegularExpressions;

namespace UberEats.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must contain characters only.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name must contain characters only.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a date of birth.")]
        [MinimumAge(18, ErrorMessage = "Age must be 18 years or older.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Address must be alphanumeric.")]
        [StringLength(50, ErrorMessage = "Address cannot exceed 50 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a social security number.")]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Social security number must be in the format xxx-xx-xxxx.")]
        public string SSN { get; set; }

        [RegularExpression(@"^\d{5}-\d{4}$", ErrorMessage = "Post Code must be in the format xxxxx-xxxx.")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        // [Remote(action: "VerifyEmail", controller: "Driver", ErrorMessage = "Email already exists.")]
        public string Email { get; set; } = string.Empty;

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}|\d{3}\.\d{3}\.\d{4}$", ErrorMessage = "Phone must be in the format xxx-xxx-xxxx or xxx.xxx.xxxx.")]
        public string Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s-]+$", ErrorMessage = "Driving license number must be alphanumeric.")]
        public string DriverLicense { get; set; } = string.Empty;

        public string Slug =>
            FirstName?.Replace(' ', '-').ToLower() + '-' + SSN?.ToString();
    }

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var age = CalculateAge(dateOfBirth);
                if (age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage);
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
