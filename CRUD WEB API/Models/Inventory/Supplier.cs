namespace Shop_Management_WEB_API.Models.Inventory
{
    public class Supplier
    {  
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string COntactPerson { get; set; }
        public string Email {  get; set; }
        public string SupplierPhone { get; set;}

        public List<SupplierPurchaseOrder> SupplierPurchaseOrders { get; set;}
        
    }
}
