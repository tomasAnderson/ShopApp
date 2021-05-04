using System;
using System.Globalization;
using System.Windows.Data;
using ShopApp.Enumerations;

namespace ShopApp.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.GetValues(value?.GetType() ?? throw new NullReferenceException());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}