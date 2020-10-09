using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Web.Entities
{
    public class User : IdentityUser
    { /*User inherit user Identity*/
        [Required]
        [MaxLength (30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string  Photo { get; set; }
    }
}
