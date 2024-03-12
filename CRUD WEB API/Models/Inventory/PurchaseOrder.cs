namespace CRUD_WEB_API.Models.Inventory
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public  DateTime OrderDate { get; set;}

        public List<PurchaseOrderItem> Items { get; set; }

        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }
}
