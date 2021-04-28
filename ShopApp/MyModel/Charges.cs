using System;

namespace ShopApp.MyModel
{
    public class Charges
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime ChargeDate { get; set; }
        public ExpenseItems ExpenseItemId { get; set; }
    }
}