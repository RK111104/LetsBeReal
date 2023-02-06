using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBeReal.Shared
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(13, 95, ErrorMessage = "User must be 13 years old or above")]
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required]
        public string UserInfo { get; set; }
        [Required]
        public string UserGenreInterests { get; set; }
        [Required]
        public string Occupation { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Reviews Review { get; set; }
        public virtual Product Product { get; set; }
        public virtual Update NewGame { get; set; }
        public virtual UserInterest Interests { get; set; }
        public virtual UserRank Rank { get; set; }
    }
}