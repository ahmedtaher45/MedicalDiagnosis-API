using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class ResetPasswordDTO
    {
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The Password and Confirmation password do not match")]
        public string? PasswordConfirmation { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
