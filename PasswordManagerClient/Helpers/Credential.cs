using System.ComponentModel.DataAnnotations;

namespace PasswordManagerClient.Helpers
{
    public class Credential
    {

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Too many / few characters")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = ""; 
    }

}
