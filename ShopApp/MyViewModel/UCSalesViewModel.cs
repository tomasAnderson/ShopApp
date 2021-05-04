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
        private object _currItem;

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
            set => Set(() => CurrItem, ref _currItem, value);
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
            SalesOc = AllInfo.SalesOc;
            
            CmdCreate = new RelayCommand(CmdCreateHandler);
            CmdDelete = new RelayCommand(CmdDeleteHandler);
            CmdChange = new RelayCommand(CmdChangeHandler);
        }

        #region command handlers

        private void CmdCreateHandler()
        {
            /*var sm = CurrentPredmet;

            string tableName = "Predmety";

            if (tableName.Trim() != "")
            {
                string sql = $"INSERT INTO {tableName} (Predmet, Klass, Semestr, Atest, Datest, Fzvit, Maxbal) " +
                             $"VALUES ('{CurrentSubject}', {CurrentClass?.Id}, {sm.Semestr}, '{sm?.Atest}', '{sm?.Datest}', " +
                             $"'{sm?.Fzvit}', {sm?.Maxbal} )";

                AllData.CreateSomething(sql);
                Predmety = GetPredmetyForTable(AllData.GetPredmety());
            }*/
        }

        private void CmdDeleteHandler()
        {
            /*var sm = CurrentPredmet;

            string tableName = "Predmety";

            if (tableName.Trim() != "")
            {
                string sql = $"DELETE FROM {tableName} WHERE [Код] = {sm.Id}";
                AllData.CreateSomething(sql);
                Predmety = GetPredmetyForTable(AllData.GetPredmety());
            }*/
        }

        private void CmdChangeHandler()
        {
            /*var sm = CurrentPredmet;

            string tableName = "Predmety";

            if (tableName.Trim() != "")
            {
                string sql = $"UPDATE {tableName} SET Predmet = '{CurrentSubject}', Klass = {CurrentClass?.Id}, " +
                             $"Semestr = {sm?.Semestr}, Atest = '{sm?.Atest}', Datest = '{sm?.Datest}', Fzvit = '{sm?.Fzvit}', " +
                             $"Maxbal = {sm?.Maxbal} " +
                             $" WHERE [Код] = {sm?.Id}";
                AllData.CreateSomething(sql);
                Predmety = GetPredmetyForTable(AllData.GetPredmety());
            }*/
        }

        #endregion
    }
}