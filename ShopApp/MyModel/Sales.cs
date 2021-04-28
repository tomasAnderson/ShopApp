using System;

namespace ShopApp.MyModel
{
    public class Sales
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public Warehouses WarehouseId { get; set; }
    }
}