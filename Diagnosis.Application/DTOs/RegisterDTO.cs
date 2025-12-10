using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
         ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]",
         ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit and one special character")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        [Compare("Password", ErrorMessage = "password and confirmation do not match")]
        public string? ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }

    public class RegisterResponse
    {
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }
    }
}
