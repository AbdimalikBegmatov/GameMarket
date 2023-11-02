using System.ComponentModel.DataAnnotations;

namespace GameMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DeveloperCompany { get; set; }
        public DateTime Released { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public DateTime AddedTime { get; set; }= DateTime.Now;
        public DateTime EditedTime { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Raiting>? Raitings { get; set; }

    }
}
