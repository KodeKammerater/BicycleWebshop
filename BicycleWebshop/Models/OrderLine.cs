namespace BicycleWebshop.Models;

public class OrderLine
{
    public Order OrderID { get; set; }
    
    public Order Order { get; set; } // nav property
    
    public int OrderLineID { get; set; }
    
    public Customer Customer { get; set; } //nav property
    
    public Customer CustomerID { get; set; }
    
    public int Quantity { get; set; }

}