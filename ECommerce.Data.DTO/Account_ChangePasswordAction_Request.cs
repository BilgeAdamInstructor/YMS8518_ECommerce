using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.DTO
{
    public class Account_ChangePasswordAction_Request
    {
        [Required, MinLength(8), MaxLength(64)]
        public string Password { get; set; }

        [Required, MinLength(8), MaxLength(64)]
        public string NewPassword { get; set; }
    }
}