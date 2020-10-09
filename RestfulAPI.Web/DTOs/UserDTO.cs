using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Web.DTOs
{
    public class UserDTO // user data transfer object
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
