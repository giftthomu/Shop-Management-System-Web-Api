namespace CRUD_WEB_API.Models.Inventory
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }
    }
}
