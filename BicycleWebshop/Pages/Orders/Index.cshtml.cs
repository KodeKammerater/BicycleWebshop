using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Data;
using BicycleWebshop.Models;

namespace BicycleWebshop.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public IndexModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
