using LetsBeReal.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsBeReal.Server.Configurations.Entities
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre
                {
                    Id = 1,
                    GenreTitle = "Genre1",
                    RPG = "RPG Games",
                    MMORPG = "MMORPG Games",
                    shooterFPS = "Shooter FPS Games",
                    Horror = "Horror Games",
                    Sports = "Sports Games",
                    Strategy = "Strategy Games",
                }
                );

        }
    }
}

