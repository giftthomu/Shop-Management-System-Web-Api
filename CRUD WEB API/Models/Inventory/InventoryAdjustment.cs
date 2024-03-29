﻿using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Inventory
{
    public class InventoryAdjustment
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityAdjustment { get; set; }
        public string Reason { get; set; }
        public DateTime AdjustmentDate { get; set; }

        public Product Product { get; set; }
    }
}
