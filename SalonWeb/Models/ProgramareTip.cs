using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWeb.Models
{
    public class ProgramareTip
    {
        public int ID { get; set; }
        public int ProgramareID { get; set; }
        public Programare Programare { get; set; }
        public int TipID { get; set; }
        public Tip Tip { get; set; }

    }
}
