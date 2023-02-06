using LetsBeReal.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsBeReal.Server.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Name = "John",
                    Age = 25,
                    Gender = "Male",
                    UserInfo = "Game enthusiast",
                    Occupation = "Business Man",
                    UserGenreInterests = "FPS, RPG, MMORPG",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                },

                new User
                {
                    Id = 2,
                    Name = "Melissa",
                    Age = 19,
                    Gender = "Female",
                    UserInfo = "Love playing games when I am bored. I like to also review games",
                    Occupation = "Student",
                    UserGenreInterests = "RPG, MMORPG, Strategy",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                }
                );
        }
    }
}