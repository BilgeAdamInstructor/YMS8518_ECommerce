using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.DTOs
{
    public class User_LoginAction_Request
    {
        [Required, MinLength(6), MaxLength(350)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(64)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}