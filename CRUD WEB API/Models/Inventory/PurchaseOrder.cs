using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Inventory
{
    public class PurchaseOrder
    {
        [Key]
        public int Id { get; set; }

        public  DateTime OrderDate { get; set;}

        public List<PurchaseOrderItem> Items { get; set; }

        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }
}
