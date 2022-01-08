using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWeb.Models
{
    public class ProgramareData
    {
        public IEnumerable<Programare> Programari { get; set; }
        public IEnumerable<Tip> Tips { get; set; }
        public IEnumerable<ProgramareTip> ProgramareTips { get; set; }
    }
}
