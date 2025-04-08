using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BicycleWebshop.Models;

namespace BicycleWebshop.Data
{
    public class BicycleWebshopContext : DbContext
    {
        public BicycleWebshopContext (DbContextOptions<BicycleWebshopContext> options)
            : base(options)
        {
        }

        public DbSet<BicycleWebshop.Models.Bicycle> Bicycle { get; set; } = default!;
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<BicycleWebshop.Models.Order> Order { get; set; } = default!;
        public DbSet<BicycleWebshop.Models.Payment> Payment { get; set; } = default!;
    }
}
