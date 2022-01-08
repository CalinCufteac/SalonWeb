using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Programari
{
    public class EditModel : ProgramareTipsPageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public EditModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Programare = await _context.Programare
             .Include(b => b.Frizer)
             .Include(b => b.ProgramareTips).ThenInclude(b => b.Tip)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            if (Programare == null)
            {
                return NotFound();
            }
            PopulateAssignedTipData(_context, Programare);
            ViewData["FrizerID"] = new SelectList(_context.Set<Frizer>(), "ID", "FrizerNume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTips)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }
            var programareToUpdate = await _context.Programare
            .Include(i => i.Frizer)
            .Include(i => i.ProgramareTips)
            .ThenInclude(i => i.Tip)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (programareToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Programare>(
            programareToUpdate,
             "Programare",
            i => i.Client, i => i.Notite,
            i => i.Ziua, i => i.Frizer))
            {
                UpdateProgramareTips(_context, selectedTips, programareToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateProgramareTips(_context, selectedTips, programareToUpdate);
            PopulateAssignedTipData(_context, programareToUpdate);
            return Page();
        
    
    _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProgramareExists(int id)
        {
            return _context.Programare.Any(e => e.ID == id);
        }
    }
}
