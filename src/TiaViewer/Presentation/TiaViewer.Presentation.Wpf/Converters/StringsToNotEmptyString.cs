using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TiaViewer.Presentation.Wpf.Converters
{
    public class StringsToNotEmptyString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => values.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o?.ToString()));

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => new object[] { };
    }
}