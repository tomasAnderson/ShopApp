#nullable enable
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp.MyViewModel
{
    public class UCExpenseItemViewModel : ViewModelBase
    {
        #region private

        private ObservableCollection<ExpenseItems> _expenseItems;
        private string tableName = "expense_items".ToUpper();

        private object _currItem;
        private string? _currName;

        #endregion

        #region public

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

        public string? CurrName
        {
            get => _currName;
            set => Set(() => CurrName, ref _currName, value);
        }

        #endregion

        #region public commands

        public ICommand CmdCreate { get; }
        public ICommand CmdDelete { get; }
        public ICommand CmdChange { get; }

        #endregion

        public UCExpenseItemViewModel()
        {
            ExpenseItemsOc = AllInfo.ExpenseItemsOc;

            CmdCreate = new RelayCommand(CmdCreateHandler);
            CmdDelete = new RelayCommand(CmdDeleteHandler);
            CmdChange = new RelayCommand(CmdChangeHandler);
        }

        #region command handlers

        private void CmdCreateHandler()
        {
            if (CheckForNull())
            {
                string sql = $"INSERT INTO {tableName} (name) " +
                             $"VALUES ('{CurrName}')";

                DBConnection.DoSqlCommand(sql);
                ExpenseItemsOc = AllInfo.GetExpenseItems();
            }
        }

        private void CmdDeleteHandler()
        {
            var si = (ExpenseItems) CurrItem;

            if (CheckForNull() && si != null)
            {
                string sql = $"DELETE FROM {tableName} WHERE id = {si.Id}";
                DBConnection.DoSqlCommand(sql);
                ExpenseItemsOc = AllInfo.GetExpenseItems();
            }
        }

        private void CmdChangeHandler()
        {
            var si = (ExpenseItems) CurrItem;

            if (CheckForNull() && si != null)
            {
                string sql = $"UPDATE {tableName} SET name = '{CurrName!}' " +
                             $" WHERE id = {si.Id}";
                DBConnection.DoSqlCommand(sql);
                ExpenseItemsOc = AllInfo.GetExpenseItems();
            }
        }

        #endregion

        #region private methods

        private void SetDataToFields()
        {
            CurrName = ((ExpenseItems) CurrItem!)!.Name?.Trim();
        }
        
        private bool CheckForNull()
        {
            return CurrName != "";
        }

        #endregion
    }

}