using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public IndexModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; }
        public ProgramareData ProgramareD { get; set; }
        public int ProgramareID { get; set; }
        public int TipID { get; set; }

        public async Task OnGetAsync(int? id, int? tipID)
        {
            ProgramareD = new ProgramareData();

            ProgramareD.Programari = await _context.Programare
                .Include(b => b.Frizer)
                .Include(b => b.ProgramareTips)
                .ThenInclude(b => b.Tip)
                .AsNoTracking()
                .OrderBy(b => b.Client)
                .ToListAsync();
            if (id != null)
            {
                ProgramareID = id.Value;
                Programare programare = ProgramareD.Programari
                .Where(i => i.ID == id.Value).Single();
                ProgramareD.Tips = programare.ProgramareTips.Select(s => s.Tip);
            }
        }
    }
}
