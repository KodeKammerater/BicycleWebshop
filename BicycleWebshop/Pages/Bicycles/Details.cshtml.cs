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
    public class DetailsModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public DetailsModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

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
    }
}
