using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ShopApp.Converters
{
    public static class MessageBoxConverter
    {
        public static void Convert(string createReport)
        {
            MessageBox.Show(createReport, "Message");
        }
    }
}