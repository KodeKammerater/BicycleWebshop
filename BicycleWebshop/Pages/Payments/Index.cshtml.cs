using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Data;
using BicycleWebshop.Models;

namespace BicycleWebshop.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public IndexModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Payment = await _context.Payment
                .Include(p => p.Order).ToListAsync();
        }
    }
}
