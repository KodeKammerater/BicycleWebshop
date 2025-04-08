using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Models;
using BicycleWebshop.Pages.Customer;

namespace BicycleWebshop.Data
{
    public class BicycleWebshopContext : DbContext
    {
        public BicycleWebshopContext (DbContextOptions<BicycleWebshopContext> options)
            : base(options)
        {
        }

        public DbSet<BicycleWebshop.Models.Bicycle> Bicycle { get; set; } = default!;
        public DbSet<BicycleWebshop.Pages.Customer.Customer> Customer { get; set; } = default!;
    }
}
