using LetsBeReal.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetsBeReal.Server.Configurations.Entities
{
    public class GameConfiguration : IEntityTypeConfiguration<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.HasData(
                new Games
                {
                    Id = 1,
                    GameName = "Minecraft",
                    GamePrice = "$29.99",
                    GamePublishDate = 18,
                    GameCompany = "Mojang"
                },

                new Games
                {
                    Id = 2,
                    GameName = "Terraria",
                    GamePrice = "$29.99",
                    GamePublishDate = 16,
                    GameCompany = "Re-Logic"
                }
                );
        }
    }
}
