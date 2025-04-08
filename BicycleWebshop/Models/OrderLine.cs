namespace BicycleWebshop.Models;

public class OrderLine
{
    public int OrderID { get; set; }
    public Order Order { get; set; } // nav property

    public int OrderLineID { get; set; }

    public int BicycleID { get; set; }
    public Bicycle Bicycle { get; set; } //nav property

    public int Quantity { get; set; }

}