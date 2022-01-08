using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Frizeri
{
    public class CreateModel : PageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public CreateModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Frizer Frizer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Frizer.Add(Frizer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
