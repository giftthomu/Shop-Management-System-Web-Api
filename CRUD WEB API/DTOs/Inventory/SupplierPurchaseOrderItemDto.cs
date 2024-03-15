using Shop_Management_WEB_API.DTOs.Inventory;

namespace CRUD_WEB_API.DTOs.Inventory
{
    public class SupplierPurchaseOrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductDto Product { get; set; }
    }
}
