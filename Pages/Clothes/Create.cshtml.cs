﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Dunca.Data;
using Proiect_Dunca.Models;

namespace Proiect_Dunca.Pages.Clothes
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Dunca.Data.Proiect_DuncaContext _context;

        public CreateModel(Proiect_Dunca.Data.Proiect_DuncaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID", "DesignerName");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "CategoryName");

            return Page();
        }

        [BindProperty]
        public Clothe Clothe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clothe.Add(Clothe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
