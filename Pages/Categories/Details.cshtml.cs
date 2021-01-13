using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Dunca.Data;
using Proiect_Dunca.Models;

namespace Proiect_Dunca.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Dunca.Data.Proiect_DuncaContext _context;

        public DetailsModel(Proiect_Dunca.Data.Proiect_DuncaContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
