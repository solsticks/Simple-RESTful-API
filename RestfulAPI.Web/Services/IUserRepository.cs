using Microsoft.AspNetCore.Identity;
using RestfulAPI.Web.DTOs;
using RestfulAPI.Web.Entities;
using RestfulAPI.Web.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Web.Services
{
    public interface IUserRepository // user interface
    {
        UserManager<User> Context { get; set; }
        UserDTO GetLoggedinUserDetails(EmailDTO loginDetails);
        Task<bool> RegisterNewUser(RegisterUserDTO details);
        IEnumerable<UserDTO> GetUsers();
        IEnumerable<UserDTO> GetUsersByPage(int pageNumber);
    }
}
