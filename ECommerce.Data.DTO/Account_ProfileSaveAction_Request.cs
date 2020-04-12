using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.DTO
{
    public class Account_ProfileSaveAction_Request
    {
        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string Surname { get; set; }

        [Required, MinLength(6), MaxLength(350)]
        public string Email{ get; set; }
    }
}