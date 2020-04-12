using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.DTO
{
    public class User_RegisterAction_Request
    {
        [Required, MinLength(6), MaxLength(350)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(64)]
        public string Password { get; set; }

        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [Required, MaxLength(50), MinLength(2)]
        public string Surname { get; set; }
    }
}