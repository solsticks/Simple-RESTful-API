using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestfulAPI.Web.DTOs;
using RestfulAPI.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Web.UserContext
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            // seed the database with dummy data
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    FirstName = "Olusola",
                    LastName = "Adekan",
                    Email = "olusola@adekan.com",
                    Photo = "photo",
                },
                new User()
                {
                    FirstName = "Fred",
                    LastName = "Chinazor",
                    Email = "fred@chinazor.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Neto",
                    LastName = "Anyankah",
                    Email = "neto@anyankah.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Lawrence",
                    LastName = "Mangdong",
                    Email = "law@mang.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Louis",
                    LastName = "Otu",
                    Email = "louis@otu.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Olusegun",
                    LastName = "Adaramaja",
                    Email = "segun@maja.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Victor",
                    LastName = "Nwike",
                    Email = "victor@nwike.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Michael",
                    LastName = "Nwosu",
                    Email = "michael@nwosu.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Oluwaseun",
                    LastName = "Oyetoyan",
                    Email = "seun@oye.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Kosi",
                    LastName = "Nwizu",
                    Email = "Kosi@anwizu.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Chidi",
                    LastName = "Okobia",
                    Email = "chidi@oko.com",
                    Photo = "photo",
                },
                new User()
                {
                    FirstName = "Tunde",
                    LastName = "Ope",
                    Email = "tunde@ope.com",
                    Photo = "photo",
                },
                new User()
                {
                   
                    FirstName = "Ransom",
                    LastName = "Isiah",
                    Email = "ran@isi.com",
                    Photo = "photo",
                }
                );

            base.OnModelCreating(modelBuilder);
        }

    }


}
