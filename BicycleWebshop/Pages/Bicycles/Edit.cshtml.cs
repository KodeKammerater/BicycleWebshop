using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Data;
using BicycleWebshop.Models;

namespace BicycleWebshop.Pages.Bicycles
{
    public class EditModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public EditModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bicycle Bicycle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle =  await _context.Bicycle.FirstOrDefaultAsync(m => m.BicycleID == id);
            if (bicycle == null)
            {
                return NotFound();
            }
            Bicycle = bicycle;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bicycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BicycleExists(Bicycle.BicycleID))
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

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.BicycleID == id);
        }
    }
}
