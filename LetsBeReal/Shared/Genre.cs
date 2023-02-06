using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBeReal.Shared
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string GenreTitle { get; set; }
        public string RPG { get; set; }
        public string MMORPG { get; set; }
        public string shooterFPS { get; set; }
        public string Horror { get; set; }
        public string Sports { get; set; }
        public string Strategy { get; set; }
    }
}
