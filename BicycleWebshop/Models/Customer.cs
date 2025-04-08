namespace BicycleWebshop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Totalspent { get; set; }
        public bool isloggedin { get; set; }
     

    }
}
