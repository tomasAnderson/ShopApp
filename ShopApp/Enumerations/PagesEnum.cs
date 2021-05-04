using System.ComponentModel;
using ShopApp.Converters;

namespace ShopApp.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum PagesEnum
    {
        [Description("Журнал продаж")]
        Sales,
        [Description("Журнал расходов")]
        Charges,
        [Description("Прибыль магазина за определенную дату")]
        CurrentMonthIncome, //Таблица склада товаров
        [Description("Пять самых доходных товаров за заданный интервал дат")]
        Top5Charges
    }
}