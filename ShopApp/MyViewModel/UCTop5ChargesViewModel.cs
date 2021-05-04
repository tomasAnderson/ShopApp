using System;
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
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        private ObservableCollection<Warehouses> GetTop5Warehouses()
        {
            var res = AllInfo.GetSalesOc().Select(x => x.WarehouseId);
            return (ObservableCollection<Warehouses>) res;
        }
    }
}