using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using ShopApp.MyModel;

namespace ShopApp.Connection
{
    public class AllInfo
    {
        #region private

        private static ObservableCollection<Sales> _salesOc = new ObservableCollection<Sales>();
        private static ObservableCollection<Warehouses> _warehousesOc = new ObservableCollection<Warehouses>();

        #endregion

        #region public

        public static ObservableCollection<Sales> SalesOc => (_salesOc.Count == 0) ? GetSalesOc() : _salesOc;

        public static ObservableCollection<Warehouses> WarehosesOc =>
            (_warehousesOc.Count == 0) ? GetWarehousesOc() : _warehousesOc;

        #endregion

        public static ObservableCollection<Sales> GetSalesOc()
        {
            _salesOc = new ObservableCollection<Sales>();
            var res = DBConnection.DoSqlCommand("SELECT * FROM SALES", 5);
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
            var res = DBConnection.DoSqlCommand("SELECT * FROM WAREHOUSES", 4);
            foreach (var r in res)
                _warehousesOc.Add(new Warehouses()
                {
                    Id = (int) r[0], Name = ((string) r[1]).Trim(), Quantity = (int) r[2], Amount = (double) r[3]
                });
            return _warehousesOc;
        }
    }
}