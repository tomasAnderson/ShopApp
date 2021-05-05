using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp.MyViewModel
{
    public class UCChargesViewModel : ViewModelBase
    {
        #region private

        private ObservableCollection<Charges> _chargesOc;
        private ObservableCollection<ExpenseItems> _expenseItems;
        private string tableName = "charges".ToUpper();

        private object _currItem;
        private double _currAmount;
        private DateTime _currChargeDate = DateTime.Today;
        private ExpenseItems _currExpenseItemId;

        #endregion

        #region public

        public ObservableCollection<Charges> ChargesOc
        {
            get => _chargesOc;
            set => Set(() => ChargesOc, ref _chargesOc, value);
        }

        public ObservableCollection<ExpenseItems> ExpenseItemsOc
        {
            get => _expenseItems;
            set => Set(() => ExpenseItemsOc, ref _expenseItems, value);
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

        public DateTime CurrChargeDate
        {
            get => _currChargeDate;
            set => Set(() => CurrChargeDate, ref _currChargeDate, value);
        }

        public ExpenseItems CurrExpenseItemId
        {
            get => _currExpenseItemId;
            set => Set(() => CurrExpenseItemId, ref _currExpenseItemId, value);
        }

        #endregion

        #region public commands

        public ICommand CmdCreate { get; }
        public ICommand CmdDelete { get; }
        public ICommand CmdChange { get; }

        #endregion

        public UCChargesViewModel()
        {
            ExpenseItemsOc = AllInfo.ExpenseItemsOc;
            ChargesOc = AllInfo.ChargesOc;

            CmdCreate = new RelayCommand(CmdCreateHandler);
            CmdDelete = new RelayCommand(CmdDeleteHandler);
            CmdChange = new RelayCommand(CmdChangeHandler);
        }

        #region command handlers

        private void CmdCreateHandler()
        {
            if (CheckForNull())
            {
                string sql = $"INSERT INTO {tableName} (amount, charge_data, expense_item_id) " +
                             $"VALUES ({CurrAmount}, '{CurrChargeDate.Date}', {CurrExpenseItemId.Id})";

                DBConnection.DoSqlCommand(sql);
                ChargesOc = AllInfo.GetCharges();
            }
        }

        private void CmdDeleteHandler()
        {
            var si = (Charges) CurrItem;

            if (CheckForNull() && si != null)
            {
                string sql = $"DELETE FROM {tableName} WHERE id = {si.Id}";
                DBConnection.DoSqlCommand(sql);
                ChargesOc = AllInfo.GetCharges();
            }
        }

        private void CmdChangeHandler()
        {
            var si = (Charges) CurrItem;

            if (CheckForNull() && si != null)
            {
                string sql = $"UPDATE {tableName} SET amount = {CurrAmount}, " +
                             $"charge_data = '{CurrChargeDate}', expense_item_id = {CurrExpenseItemId.Id}" +
                             $" WHERE id = {si.Id}";
                DBConnection.DoSqlCommand(sql);
                ChargesOc = AllInfo.GetCharges();
            }
        }

        #endregion

        #region private methods

        private void SetDataToFields()
        {
            CurrAmount = ((Charges) CurrItem)!.Amount!;
            CurrChargeDate = ((Charges) CurrItem)!.ChargeDate!;
            CurrExpenseItemId = ((Charges) CurrItem)!.ExpenseItemId!;
        }
        
        private bool CheckForNull()
        {
            return CurrAmount != 0 && CurrChargeDate != DateTime.MinValue && CurrExpenseItemId != null;
        }

        #endregion
    }
}