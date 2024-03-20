using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_WEB_API.DTOs.Inventory
{
    public class SupplierDto
    {
        
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(50, ErrorMessage = "Supplier name must be between 3 and 50 characters", MinimumLength = 3)]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Contact person is required")]
        [StringLength(50, ErrorMessage = "Contact person must be between 3 and 50 characters", MinimumLength = 3)]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Supplier phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string SupplierPhone { get; set; }

        public List<SupplierPurchaseOrderDto> SupplierPurchaseOrders { get; set; }
    }
}