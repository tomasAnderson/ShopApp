using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using ShopApp.MyModel;

namespace ShopApp.Connection
{
    public class AllInfo
    {
        #region private

        private static List<Sales> _salesOc = new List<Sales>();
        private static ObservableCollection<Warehouses> _warehousesOc = new ObservableCollection<Warehouses>();
        private static ObservableCollection<Charges> _chargesOc = new ObservableCollection<Charges>();
        private static ObservableCollection<ExpenseItems> _expenseItemsOc = new ObservableCollection<ExpenseItems>();

        #endregion

        #region public

        public static List<Sales> SalesOc => (_salesOc.Count == 0) ? GetSalesOc() : _salesOc;

        public static ObservableCollection<Warehouses> WarehosesOc =>
            (_warehousesOc.Count == 0) ? GetWarehousesOc() : _warehousesOc;

        public static ObservableCollection<Charges> ChargesOc =>
            (_chargesOc.Count == 0) ? GetCharges() : _chargesOc;        
        public static ObservableCollection<ExpenseItems> ExpenseItemsOc =>
            (_expenseItemsOc.Count == 0) ? GetExpenseItems() : _expenseItemsOc;

        #endregion

        public static List<Sales> GetSalesOc()
        {
            _salesOc = new List<Sales>();
            var res = DBConnection.DoSqlCommand("SELECT * FROM SALES ORDER BY id", 5);
            foreach (var r in res)
                _salesOc.Add(new Sales()
                {
                    Id = (int) r[0], Amount = (double) r[1], Quantity = (int) r[2], SaleDate = (DateTime) r[3],
                    WarehouseId = WarehosesOc.FirstOrDefault(x => x.Id == (int) r[4])
                });
            return _salesOc;
        }

        public static ObservableCollection<Warehouses> GetWarehousesOc()
        {
            _warehousesOc = new ObservableCollection<Warehouses>();
            var res = DBConnection.DoSqlCommand("SELECT * FROM WAREHOUSES ORDER BY id", 4);
            foreach (var r in res)
                _warehousesOc.Add(new Warehouses()
                {
                    Id = (int) r[0], Name = ((string) r[1]).Trim(), Quantity = (int) r[2], Amount = (double) r[3]
                });
            return _warehousesOc;
        }

        public static ObservableCollection<Charges> GetCharges()
        {
            _chargesOc = new ObservableCollection<Charges>();
            var res = DBConnection.DoSqlCommand("SELECT * FROM CHARGES ORDER BY id", 4);
            foreach (var r in res)
                _chargesOc.Add(new Charges()
                {
                    Id = (int) r[0], Amount = (double) r[1], ChargeDate = (DateTime) r[2], 
                    ExpenseItemId = ExpenseItemsOc.FirstOrDefault(x => x.Id == (int) r[3])
                });
            return _chargesOc;
        }

        public static ObservableCollection<ExpenseItems> GetExpenseItems()
        {
            _expenseItemsOc = new ObservableCollection<ExpenseItems>();
            var res = DBConnection.DoSqlCommand("SELECT * FROM expense_items ORDER BY id", 2);
            foreach (var r in res)
                _expenseItemsOc.Add(new ExpenseItems()
                {
                    Id = (int) r[0], Name = (string) r[1]
                });
            return _expenseItemsOc;
        }

        public static ObservableCollection<User> GetUsers()
        {
            var users = new ObservableCollection<User>();
            var res = DBConnection.DoSqlCommand("SELECT * FROM users", 3);
            foreach (var r in res)
                users.Add(new User()
                {
                    Id = (int) r[0], Name = (string) r[1], Password = (string) r[2]
                });
            return users;
        }
    }
}