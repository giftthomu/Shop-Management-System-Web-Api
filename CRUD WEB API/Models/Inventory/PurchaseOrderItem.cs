namespace CRUD_WEB_API.Models.Inventory
{
    public class PurchaseOrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
