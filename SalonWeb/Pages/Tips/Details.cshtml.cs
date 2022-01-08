using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Tips
{
    public class DetailsModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public DetailsModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        public Tip Tip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tip = await _context.Tip.FirstOrDefaultAsync(m => m.ID == id);

            if (Tip == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
