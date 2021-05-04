using System.Linq;
using GalaSoft.MvvmLight;
using ShopApp.Connection;

namespace ShopApp.MyViewModel
{
    public class UCCurrentMonthIncomeViewModel : ViewModelBase
    {
        public double Income { get; set; }
        public string Message { get; set; }

        public UCCurrentMonthIncomeViewModel()
        {
            GetIncome();
            Message = $"Прибыль = {Income}, чукча";
        }

        private void GetIncome()
        {
            var res = DBConnection.DoSqlCommand("SELECT get_income()", 1);
            foreach (var r in res)
                Income = (double)r.FirstOrDefault();
        }
    }
}