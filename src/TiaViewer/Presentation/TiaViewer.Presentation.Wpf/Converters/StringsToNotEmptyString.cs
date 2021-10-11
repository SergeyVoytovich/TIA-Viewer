using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TiaViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Not empty string chooser
    /// </summary>
    public class NotEmptyStringChooser : IMultiValueConverter
    {
        /// <summary>
        /// <see cref="IMultiValueConverter"/>
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>First not empty string from source array</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => values.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o?.ToString()));

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => new object[] { };
    }
}