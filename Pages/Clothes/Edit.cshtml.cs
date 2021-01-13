using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Dunca.Data;
using Proiect_Dunca.Models;

namespace Proiect_Dunca.Pages.Clothes
{
    public class EditModel : PageModel
    {
        private readonly Proiect_Dunca.Data.Proiect_DuncaContext _context;

        public EditModel(Proiect_Dunca.Data.Proiect_DuncaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clothe Clothe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothe = await _context.Clothe.FirstOrDefaultAsync(m => m.ID == id);

            if (Clothe == null)
            {
                return NotFound();
            }
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID", "DesignerName");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Clothe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClotheExists(Clothe.ID))
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

        private bool ClotheExists(int id)
        {
            return _context.Clothe.Any(e => e.ID == id);
        }
    }
}
