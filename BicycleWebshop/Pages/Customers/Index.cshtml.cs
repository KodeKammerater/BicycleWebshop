using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Data;

namespace BicycleWebshop.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public IndexModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public IList<BicycleWebshop.Models.Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
