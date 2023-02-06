using LetsBeReal.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBeReal.Shared
{
    public class Reviews
    {
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Game Title does not meet the requirement")]
        public string ReviewTitle { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Review Description does not meet the requirement")]
        public string ReviewDescription { get; set; }
        public int UserCategoryId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; }
        public int ID { get; set; }
    }
}
