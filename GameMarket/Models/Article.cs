namespace GameMarket.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime AddedTime { get; set; } = DateTime.Now;
        public DateTime EditTime { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }
    }
}
