using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ShopApp.Connection;
using ShopApp.Converters;

namespace ShopApp.MyViewModel
{
    public class UCCurrentMonthIncomeViewModel : ViewModelBase
    {
        public double Income { get; set; }
        public string Message { get; set; }

        public ICommand CmdCreateReport { get; }

        public UCCurrentMonthIncomeViewModel()
        {
            GetIncome();
            CmdCreateReport = new RelayCommand(CmdCreateReportHandler);
            Message = $"Прибыль за посдедние 4 месяца: {Income}";
        }

        private void GetIncome()
        {
            var res = DBConnection.DoSqlCommand("SELECT get_income()", 1);
            foreach (var r in res)
                Income = (double) r?.FirstOrDefault();
        }

        private void CmdCreateReportHandler()
        {
            MessageBoxConverter.Convert(OutputReport.CreateReport(Message));
        }
    }
}