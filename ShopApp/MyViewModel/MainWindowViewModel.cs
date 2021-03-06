using System;
using GalaSoft.MvvmLight;
using ShopApp.Enumerations;

namespace ShopApp.MyViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentPage;
        private UCSalesViewModel _salesViewModel;
        private UCChargesViewModel _chargesViewModel;
        private UCWarehouseViewModel _warehouseViewModel;
        private UCExpenseItemViewModel _expenseItemViewModel;
        private UCCurrentMonthIncomeViewModel _currentMonthIncomeViewModel;
        private UCTop5ChargesViewModel _top5ChargesViewModel;

        public PagesEnum PagesEnum { get; }

        public object CurrentPage
        {
            get => _currentPage;
            set
            {
                if (!Set(() => CurrentPage, ref _currentPage, value)) return;
                if (value != null && value.GetType() == typeof(PagesEnum)) SelectViewModel((PagesEnum) value);
            }
        }

        private void SelectViewModel(PagesEnum pagesEnum)
        {
            CurrentPage = pagesEnum switch
            {
                PagesEnum.Sales => _salesViewModel = new UCSalesViewModel(),
                PagesEnum.Charges => _chargesViewModel = new UCChargesViewModel(),
                PagesEnum.Warehouse => _warehouseViewModel = new UCWarehouseViewModel(),
                PagesEnum.ExpenseItem => _expenseItemViewModel = new UCExpenseItemViewModel(),
                PagesEnum.CurrentMonthIncome => _currentMonthIncomeViewModel = new UCCurrentMonthIncomeViewModel(),
                PagesEnum.Top5Charges => _top5ChargesViewModel = new UCTop5ChargesViewModel(),
                _ => throw new ArgumentOutOfRangeException(nameof(pagesEnum), pagesEnum, null)
            };
        }
    }
}