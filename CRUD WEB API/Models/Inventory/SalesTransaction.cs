using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Inventory
{
    public class SalesTransaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<SalesTransactionItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }
}
