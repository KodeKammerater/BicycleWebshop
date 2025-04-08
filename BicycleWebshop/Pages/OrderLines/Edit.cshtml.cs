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

namespace BicycleWebshop.Pages.OrderLines
{
    public class EditModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public EditModel(BicycleWebshop.Data.BicycleWebshopContext context)
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

            var orderline =  await _context.OrderLine.FirstOrDefaultAsync(m => m.OrderLineID == id);
            if (orderline == null)
            {
                return NotFound();
            }
            OrderLine = orderline;
           ViewData["BicycleID"] = new SelectList(_context.Bicycle, "BicycleID", "BicycleID");
           ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID");
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

            _context.Attach(OrderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineExists(OrderLine.OrderLineID))
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

        private bool OrderLineExists(int id)
        {
            return _context.OrderLine.Any(e => e.OrderLineID == id);
        }
    }
}
