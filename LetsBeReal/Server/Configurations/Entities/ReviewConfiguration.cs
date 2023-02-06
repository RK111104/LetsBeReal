using LetsBeReal.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsBeReal.Server.Configurations.Entities
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.HasData(
                new Reviews
                {
                    ID = 1,
                    Rating = 5,
                    ReviewTitle = "Game3",
                    ReviewDescription = "Text",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                 },

                new Reviews
                {
                    ID = 2,
                    Rating = 3,
                    ReviewTitle = "Game2",
                    ReviewDescription = "Text",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                }
                );
        }
    }
}
