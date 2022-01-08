using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonWeb.Models
{
    public class Programare
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele Clientului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50, MinimumLength = 3)]
        public string Client { get; set; }
       
        public string Notite { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Ziua { get; set; }
        public int FrizerID { get; set; }
        public Frizer Frizer { get; set; }
        public ICollection<ProgramareTip> ProgramareTips { get; set; }
    }
}
