﻿using Shop_Management_WEB_API.Models.Inventory;
using Shop_Management_WEB_API.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Shop_Management_WEB_API.Data
{
    public class ShopWebApiContext:DbContext
    {
        public ShopWebApiContext(DbContextOptions<ShopWebApiContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<SalesTransactionItem> SalesTransactionItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPurchaseOrder> SupplierPurchaseOrders { get; set; }
        public DbSet<SupplierPurchaseOrderItem> SupplierPurchaseOrderItems { get; set; }
        public DbSet<InventoryAdjustment> InventoryAdjustments { get; set; }
    }
}
