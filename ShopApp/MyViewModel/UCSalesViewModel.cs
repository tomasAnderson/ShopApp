using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp.MyViewModel
{
    public class UCSalesViewModel : ViewModelBase
    {
        #region private

        private ObservableCollection<Sales> _salesOc;
        private ObservableCollection<Warehouses> _warehousesOc;
        private string tableName = "SALES";

        private object _currItem;
        private double _currAmount;
        private int _currQuantity;
        private DateTime _currSaleDate;
        private Warehouses _currWarehouse;

        #endregion

        #region public

        public ObservableCollection<Sales> SalesOc
        {
            get => _salesOc;
            set => Set(() => SalesOc, ref _salesOc, value);
        }

        public ObservableCollection<Warehouses> WarehousesOc
        {
            get => _warehousesOc;
            set => Set(() => WarehousesOc, ref _warehousesOc, value);
        }

        public object CurrItem
        {
            get => _currItem;
            set
            {
                if (Set(() => CurrItem, ref _currItem, value))
                    SetDataToFields();
            }
        }

        public double CurrAmount
        {
            get => _currAmount;
            set => Set(() => CurrAmount, ref _currAmount, value);
        }

        public int CurrQuantity
        {
            get => _currQuantity;
            set => Set(() => CurrQuantity, ref _currQuantity, value);
        }

        public DateTime CurrSaleDate
        {
            get => _currSaleDate;
            set => Set(() => CurrSaleDate, ref _currSaleDate, value);
        }

        public Warehouses CurrWarehouse
        {
            get => _currWarehouse;
            set => Set(() => CurrWarehouse, ref _currWarehouse, value);
        }

        #endregion

        #region public commands

        public ICommand CmdCreate { get; }
        public ICommand CmdDelete { get; }
        public ICommand CmdChange { get; }

        #endregion

        public UCSalesViewModel()
        {
            WarehousesOc = AllInfo.WarehosesOc;
            SalesOc = new ObservableCollection<Sales>(AllInfo.SalesOc);

            CmdCreate = new RelayCommand(CmdCreateHandler);
            CmdDelete = new RelayCommand(CmdDeleteHandler);
            CmdChange = new RelayCommand(CmdChangeHandler);
        }

        #region command handlers

        private void CmdCreateHandler()
        {
            var si = (Sales) CurrItem;

            string sql = $"INSERT INTO {tableName} (amount, quantity, sale_date, warehouses_id) " +
                         $"VALUES ({CurrAmount}, {CurrQuantity}, '{CurrSaleDate.Date}', {CurrWarehouse.Id})";

            DBConnection.DoSqlCommand(sql);
            SalesOc = new ObservableCollection<Sales>(AllInfo.GetSalesOc());
        }

        private void CmdDeleteHandler()
        {
            var si = (Sales) CurrItem;

            string sql = $"DELETE FROM {tableName} WHERE id = {si.Id}";
            DBConnection.DoSqlCommand(sql);
            SalesOc = new ObservableCollection<Sales>(AllInfo.GetSalesOc());
        }

        private void CmdChangeHandler()
        {
            var si = (Sales) CurrItem;

            string sql = $"UPDATE {tableName} SET amount = {CurrAmount}, quantity = {CurrQuantity}, " +
                         $"sale_date = '{CurrSaleDate}', warehouses_id = {CurrWarehouse.Id}" +
                         $" WHERE id = {si.Id}";
            DBConnection.DoSqlCommand(sql);
            SalesOc = new ObservableCollection<Sales>(AllInfo.GetSalesOc());
        }

        #endregion

        #region private methods

        private void SetDataToFields()
        {
            CurrAmount = ((Sales) CurrItem).Amount;
            CurrQuantity = ((Sales) CurrItem).Quantity;
            CurrSaleDate = ((Sales) CurrItem).SaleDate;
            CurrWarehouse = ((Sales) CurrItem).WarehouseId;
        }

        #endregion
    }
}