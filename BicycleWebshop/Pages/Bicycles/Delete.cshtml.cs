using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Data;
using BicycleWebshop.Models;

namespace BicycleWebshop.Pages.Bicycles
{
    public class DeleteModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public DeleteModel(BicycleWebshop.Data.BicycleWebshopContext context)
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

            var bicycle = await _context.Bicycle.FirstOrDefaultAsync(m => m.BicycleID == id);

            if (bicycle is not null)
            {
                Bicycle = bicycle;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle.FindAsync(id);
            if (bicycle != null)
            {
                Bicycle = bicycle;
                _context.Bicycle.Remove(Bicycle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
