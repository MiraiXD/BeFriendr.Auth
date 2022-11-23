using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendr.Accounts.Requests
{
    public class RegisterRequest
    {
       [Required]
        [EmailAddress]
        public string Email { get; init; }
        [Required]
        [StringLength(15,MinimumLength =3)]
        public string UserName { get; init; }
        [Required]
        [StringLength(15,MinimumLength =3)]
        public string Password { get; init; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; init; }
        [Required]
        [StringLength(20,MinimumLength =2)]
        public string FirstName { get; init; }
        [Required]
        [StringLength(20,MinimumLength =2)]
        public string LastName { get; init; }
        [Required]
        public DateTime BirthDate { get; init; }
        [Required]
        public string Gender { get; init; }
    }
}