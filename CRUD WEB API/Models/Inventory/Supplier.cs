﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_Management_WEB_API.Models.Inventory
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(50, ErrorMessage = "Supplier name must be between 3 and 50 characters", MinimumLength = 3)]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Contact person is required")]
        [StringLength(50, ErrorMessage = "Contactperson must be between 3 and 50 characters", MinimumLength = 3)]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Supplier phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string SupplierPhone { get; set; }

        public List<SupplierPurchaseOrder> SupplierPurchaseOrders { get; set; }
    }
}