using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Frizeri
{
    public class DetailsModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public DetailsModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        public Frizer Frizer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Frizer = await _context.Frizer.FirstOrDefaultAsync(m => m.ID == id);

            if (Frizer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
