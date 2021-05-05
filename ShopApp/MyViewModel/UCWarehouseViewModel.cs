using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp.MyViewModel
{
    public class UCWarehouseViewModel : ViewModelBase
    {
        #region private

        private ObservableCollection<Warehouses> _warehouses;
        private string tableName = "warehouses".ToUpper();

        private object _currItem;
        private string _currName;
        private int _currQuantity;
        private double _currAmount;

        #endregion

        #region public

        public ObservableCollection<Warehouses> WarehousesOc
        {
            get => _warehouses;
            set => Set(() => WarehousesOc, ref _warehouses, value);
        }

        public object CurrItem
        {
            get => _currItem;
            set
            {
                if (Set(() => CurrItem, ref _currItem, value))
                    if (value != null)
                        SetDataToFields();
            }
        }

        public string CurrName
        {
            get => _currName;
            set => Set(() => CurrName, ref _currName, value);
        }

        public int CurrQuantity
        {
            get => _currQuantity;
            set => Set(() => CurrQuantity, ref _currQuantity, value);
        }

        public double CurrAmount
        {
            get => _currAmount;
            set => Set(() => CurrAmount, ref _currAmount, value);
        }

        #endregion

        #region public commands

        public ICommand CmdCreate { get; }
        public ICommand CmdDelete { get; }
        public ICommand CmdChange { get; }

        #endregion

        public UCWarehouseViewModel()
        {
            WarehousesOc = AllInfo.WarehosesOc;

            CmdCreate = new RelayCommand(CmdCreateHandler);
            CmdDelete = new RelayCommand(CmdDeleteHandler);
            CmdChange = new RelayCommand(CmdChangeHandler);
        }

        #region command handlers

        private void CmdCreateHandler()
        {
            if (CheckForNull())
            {
                string sql = $"INSERT INTO {tableName} (name, quantity, amount) " +
                             $"VALUES ('{CurrName}', {CurrQuantity}, {CurrAmount})";

                DBConnection.DoSqlCommand(sql);
                WarehousesOc = AllInfo.GetWarehousesOc();
            }
        }

        private void CmdDeleteHandler()
        {
            var si = (Warehouses) CurrItem;

            if (CheckForNull() && si != null)
            {
                string sql = $"DELETE FROM {tableName} WHERE id = {si.Id}";
                DBConnection.DoSqlCommand(sql);
                WarehousesOc = AllInfo.GetWarehousesOc();
            }
        }

        private void CmdChangeHandler()
        {
            var si = (Warehouses) CurrItem;

            if (CheckForNull() && si != null)
            {
                string sql = $"UPDATE {tableName} SET name = '{CurrName}', " +
                             $"quantity = {CurrQuantity}, amount = {CurrAmount}" +
                             $" WHERE id = {si.Id}";
                DBConnection.DoSqlCommand(sql);
                WarehousesOc = AllInfo.GetWarehousesOc();
            }
        }

        #endregion

        #region private methods

        private void SetDataToFields()
        {
            CurrName = ((Warehouses) CurrItem).Name.Trim();
            CurrQuantity = ((Warehouses) CurrItem).Quantity;
            CurrAmount = ((Warehouses) CurrItem).Amount;
        }

        private bool CheckForNull()
        {
            return CurrName != "" && CurrQuantity != 0 && CurrAmount != 0;
        }

        #endregion
    }
}