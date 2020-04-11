using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Entities
{
    public class User : Abstracts.Entity
    {
        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [Required, MaxLength(50), MinLength(2)]
        public string Surname { get; set; }
        
        [Required, MaxLength(350), MinLength(6)]
        public string Email { get; set; }

        [Required]
        public bool EmailVerified { get; set; }

        [Required, MinLength(40), MaxLength(40)]
        public string Password { get; set; }

        [Required]
        public bool Admin { get; set; }

        public Guid? AutoLoginKey { get; set; }

        public int TitleId { get; set; }
        public virtual Title Title { get; set; }
    }
}