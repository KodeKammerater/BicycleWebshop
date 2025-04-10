using BicycleWebshop.Migrations;

namespace BicycleWebshop.Models
{
    public class Order 
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Customer Customer { get; set; } // nav property
    }
}
