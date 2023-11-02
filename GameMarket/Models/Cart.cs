namespace GameMarket.Models
{
    public class Cart
    {
        private List<OrderLines> selections = new List<OrderLines>();

        public IEnumerable<OrderLines> Selections { get => selections; }
        public Cart AddItem(Product product, int quantity)
        {

            OrderLines orderLines = selections.Where(p => p.ProductId == product.Id).FirstOrDefault();
            if (orderLines != null)
            {
                orderLines.Quantity += quantity;
            }
            else
            {
                selections.Add(new OrderLines
                {
                    Quantity = quantity,
                    ProductId = product.Id,
                    Product = product
                });
            }
            return this;
        }
        public Cart RemoveItem(int productId)
        {
            selections.RemoveAll(p => p.ProductId == productId);
            return this;
        }
        public void Clear() => selections.Clear();
    }
}
