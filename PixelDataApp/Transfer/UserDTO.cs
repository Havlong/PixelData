using System;
using System.ComponentModel.DataAnnotations;

namespace PixelDataApp.Transfer
{
    public class UserDTO
    {
        [Required]
        [RegularExpression(@"^[A-Za-z0-9 .-_]+$")]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9 .-_]+$")]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        [RegularExpression(@"([A-Z][a-z]*)|([А-Я][а-я]*)")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40)]
        [RegularExpression(@"([A-Z][a-z]*)|([А-Я][а-я]*)")]
        public string LastName { get; set; }
    }
}