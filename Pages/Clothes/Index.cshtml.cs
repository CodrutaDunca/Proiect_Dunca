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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Dunca.Data.Proiect_DuncaContext _context;

        public IndexModel(Proiect_Dunca.Data.Proiect_DuncaContext context)
        {
            _context = context;
        }

        public IList<Clothe> Clothe { get;set; }

        public async Task OnGetAsync()
        {
            Clothe = await _context.Clothe.Include(b => b.Designer).Include(b => b.Category).ToListAsync();
            
        }
    }
}
