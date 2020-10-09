using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestfulAPI.Web.DTOs;
using RestfulAPI.Web.Entities;
using RestfulAPI.Web.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Web.Services
{
    public class UserRepository : IUserRepository // userRepository that contains the methods for the user
    {
        public UserManager<User> Context { get; set; }

        public UserRepository(UserManager<User> context)
        {
            Context = context; 
        }


        public IEnumerable<UserDTO> GetUsersByPage(int pageNumber)
        {
            var users = Context.Users;
            var numberToSkip = (pageNumber-1) * 5;
            return users.Skip(numberToSkip).Select(x =>
            new UserDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Photo = x.Photo
            }).Take(5);

        }

        public UserDTO GetLoggedinUserDetails(EmailDTO loginDetails)
        {
            return Context.Users.Select(x => new UserDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Photo = x.Photo
            }).FirstOrDefault(x => x.Email == loginDetails.Email);
        }

        public async Task<bool> RegisterNewUser(RegisterUserDTO details)
        {
            var newUser = new User
            {
                FirstName = details.FirstName,
                LastName = details.LastName,
                Email = details.Email,
                Photo = details.Photo,
                UserName = details.Email
            };
            var result = await Context.CreateAsync(newUser, details.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var users = Context.Users;
            return users.Select(x =>
            new UserDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Photo = x.Photo
            });
        }
    }
}
