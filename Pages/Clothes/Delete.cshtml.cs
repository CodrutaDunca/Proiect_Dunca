using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Dunca.Data;
using Proiect_Dunca.Models;

namespace Proiect_Dunca.Pages.Clothes
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Dunca.Data.Proiect_DuncaContext _context;

        public DeleteModel(Proiect_Dunca.Data.Proiect_DuncaContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clothe = await _context.Clothe.FindAsync(id);

            if (Clothe != null)
            {
                _context.Clothe.Remove(Clothe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
