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
    public class IndexModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public IndexModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public IList<OrderLine> OrderLine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderLine = await _context.OrderLine
                .Include(o => o.Bicycle)
                .Include(o => o.Order).ToListAsync();
        }
    }
}
