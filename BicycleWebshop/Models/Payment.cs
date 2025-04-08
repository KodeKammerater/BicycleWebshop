namespace BicycleWebshop.Models;

public class Payment
{
    public int PaymentID { get; set; } // primary key
    public int OrderID { get; set; } // foreign key
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public Order Order { get; set; } // navigation property
}
