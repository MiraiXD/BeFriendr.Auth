using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeFriendr.Accounts.Requests
{
    public class UnregisterRequest
    {
        [Required]
        [StringLength(15,MinimumLength =3)]
        public string UserName { get; init; }       
    }
}