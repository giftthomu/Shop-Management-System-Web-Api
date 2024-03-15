using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_WEB_API.DTOs.Inventory
{
    public class SupplierPurchaseOrderDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Supplier id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Supplier id must be a positive integer")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Items are required")]
        public List<SupplierPurchaseOrderItemDto> Items { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be a positive number")]
        public decimal TotalAmount { get; set; }
    }
}