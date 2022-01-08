using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWeb.Models
{
    public class Tip
    {
        public int ID { get; set; }
        public string TipTuns { get; set; }
        public ICollection<ProgramareTip> ProgramareTips { get; set; }
    }
}
