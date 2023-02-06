using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBeReal.Shared
{
    public class Games
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Game Name does not meet the requirement")]
        public string GameName { get; set; }
        [Required]
        public string GamePrice { get; set; }
        public DateTime PublishDate { get; set; }
        public int GamePublishDate { get; set; }
        [Required]
        public string GameCompany { get; set; }
    }
}
