using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsBeReal.Shared
{
    public class UserRank
    {
        public int Id { get; set; }
        public int RankNo { get; set; }
        public virtual Reviews Reviews { get; set; }
    }
}
