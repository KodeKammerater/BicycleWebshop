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
    public class IndexModel : PageModel
    {
        private readonly BicycleWebshop.Data.BicycleWebshopContext _context;

        public IndexModel(BicycleWebshop.Data.BicycleWebshopContext context)
        {
            _context = context;
        }

        public IList<Bicycle> Bicycle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bicycle = await _context.Bicycle.ToListAsync();
        }
    }
}
