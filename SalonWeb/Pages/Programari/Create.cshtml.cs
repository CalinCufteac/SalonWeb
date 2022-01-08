using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWeb.Data;
using SalonWeb.Models;

namespace SalonWeb.Pages.Programari
{
    public class CreateModel : ProgramareTipsPageModel
    {
        private readonly SalonWeb.Data.SalonWebContext _context;

        public CreateModel(SalonWeb.Data.SalonWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FrizerID"] = new SelectList(_context.Set<Frizer>(), "ID", "FrizerNume");
            var programare = new Programare();
            programare.ProgramareTips = new List<ProgramareTip>();
            PopulateAssignedTipData(_context, programare);
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedTips)
        {
            var newProgramare = new Programare();
            if (selectedTips != null)
            {
                newProgramare.ProgramareTips = new List<ProgramareTip>();
                foreach (var cat in selectedTips)
                {
                    var catToAdd = new ProgramareTip
                    {
                        TipID = int.Parse(cat)
                    };
                    newProgramare.ProgramareTips.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Programare>(
                newProgramare,
                "Programare",
                i => i.Client, i => i.Notite,
                i => i.Ziua, i => i.FrizerID))
            {
                _context.Programare.Add(newProgramare);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedTipData(_context, newProgramare);
            return Page();
        }
    }


}
