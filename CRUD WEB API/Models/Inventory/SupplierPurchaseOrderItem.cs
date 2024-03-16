using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Inventory
{
    public class SupplierPurchaseOrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product Product { get; set; }
    }
}
