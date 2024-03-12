namespace CRUD_WEB_API.Models.Inventory
{
    public class SupplierPurchaseOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int SupplierId { get; set; }
        public List<SupplierPurchaseOrderItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }
}
