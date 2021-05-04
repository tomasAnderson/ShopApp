using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp.MyViewModel
{
    public class UCTop5ChargesViewModel : ViewModelBase
    {
        private string tableName = "warehouses".ToUpper();

        public ObservableCollection<Warehouses> WarehousesList => GetTop5Warehouses();
        public DateTime FirstDate { get; set; } = new DateTime(2020, 1, 1);
        public DateTime SecondDate { get; set; } = new DateTime(2022, 1, 1);

        private ObservableCollection<Warehouses> GetTop5Warehouses()
        {
            var res = AllInfo.GetSalesOc().Where(x => x.SaleDate >= FirstDate && x.SaleDate <= SecondDate)
                .Select(x => x.WarehouseId);
            return new ObservableCollection<Warehouses>(res);
        }
    }
}