namespace GameMarket.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustumerName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public bool Shipped { get; set; }
        public DateTime AddedTime { get; set; } = DateTime.Now;
        public DateTime ShippedTime { get; set; }

        public ICollection<OrderLines> OrderLines { get; set; }
    }
}
