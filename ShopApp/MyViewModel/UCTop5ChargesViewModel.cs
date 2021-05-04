using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ShopApp.Connection;
using ShopApp.MyModel;

namespace ShopApp.MyViewModel
{
    public class UCTop5ChargesViewModel : ViewModelBase
    {
        private ObservableCollection<Top5Charges> _top5Charges;

        public ObservableCollection<Top5Charges> TopCharges
        {
            get => _top5Charges;
            set => Set(() => TopCharges, ref _top5Charges, value);
        }
        public DateTime FirstDate { get; set; } = new DateTime(2021, 3, 1);
        public DateTime SecondDate { get; set; } = new DateTime(2022, 3, 1);        

        public ICommand CmdCompute { get; }

        public UCTop5ChargesViewModel()
        {
            CmdCompute = new RelayCommand(CmdComputeHandler);
        }

        private void CmdComputeHandler() => TopCharges = GetTop5Charges();

        private ObservableCollection<Top5Charges> GetTop5Charges()
        {
            var collection = new ObservableCollection<Top5Charges>();
            var res = DBConnection.DoSqlCommand(
                $"SELECT * FROM get_five_most_profit_products('{FirstDate}','{GetEndOfDate(SecondDate)}')", 2);
            foreach (var r in res)
                collection.Add(new Top5Charges()
                {
                    Name = r[0].ToString(), Amount = (double) r[1]
                });
            return collection;
        }

        private DateTime GetEndOfDate(DateTime date)
        {
            return date.AddHours(23.99);
        }
    }
}