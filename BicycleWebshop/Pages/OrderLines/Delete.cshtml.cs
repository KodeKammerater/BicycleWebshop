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
    public class DeleteModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public DeleteModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = await _context.OrderLine.FindAsync(id);
            if (orderline != null)
            {
                OrderLine = orderline;
                _context.OrderLine.Remove(OrderLine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
