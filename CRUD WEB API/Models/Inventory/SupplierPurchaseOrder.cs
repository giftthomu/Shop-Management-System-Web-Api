using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Inventory
{
    public class SupplierPurchaseOrder
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Supplier id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Supplier id must be a positive integer")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Items are required")]
        public List<SupplierPurchaseOrderItem> Items { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a positive number")]
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);
    }
}