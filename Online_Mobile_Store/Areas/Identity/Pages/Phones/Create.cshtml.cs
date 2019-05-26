using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Mobile_Store.Data;
using Online_Mobile_Store.Models;

namespace Online_Mobile_Store.Areas.Identity.Pages.Phones
{
    public class CreateModel : PageModel
    {
        private readonly Online_Mobile_Store.Data.ApplicationDbContext _context;

        public CreateModel(Online_Mobile_Store.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "CompanyId");
        ViewData["CompanyName"] = new SelectList(_context.Companies, "CompanyName", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Phone Phone { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Phones.Add(Phone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}