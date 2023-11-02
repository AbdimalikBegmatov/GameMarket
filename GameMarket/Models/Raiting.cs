using System.ComponentModel.DataAnnotations;

namespace GameMarket.Models
{
    public class Raiting
    {
        public int Id { get; set; }

        [Range(minimum: 0.0, maximum: 10.0)]
        public float Rait { get; set; }
    }
}
