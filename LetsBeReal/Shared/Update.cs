using LetsBeReal.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBeReal.Shared
{
    public class Update: BaseDomainModel
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; } = "https://via.placeholder.com/300x300";
        public double price { get; set; }
        public string link { get; set; } 
        public bool Ispublic { get; set; }
        public bool Isdeleted { get; set; }
        public Category category { get; set; }
        public int categoryId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; }
        public int Views { get; set; }
    }
}
