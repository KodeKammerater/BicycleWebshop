using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BicycleWebshop.Data;
using BicycleWebshop.Models;

namespace BicycleWebshop.Pages.OrderLines
{
    public class CreateModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public CreateModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BicycleID"] = new SelectList(_context.Bicycle, "BicycleID", "BicycleID");
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID");
            return Page();
        }

        [BindProperty]
        public OrderLine OrderLine { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.OrderLine.Add(OrderLine);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
