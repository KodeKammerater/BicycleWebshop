using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Data;
using BicycleWebshop.Models;

namespace BicycleWebshop.Pages.OrderLines
{
    public class DetailsModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public DetailsModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public OrderLine OrderLine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.OrderLine.FirstOrDefaultAsync(m => m.OrderLineID == id);

            if (orderline is not null)
            {
                OrderLine = orderline;

                return Page();
            }

            return NotFound();
        }
    }
}
