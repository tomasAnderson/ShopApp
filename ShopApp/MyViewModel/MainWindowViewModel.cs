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
                _ => throw new ArgumentOutOfRangeException(nameof(pagesEnum), pagesEnum, null)
            };
        }
    }
}