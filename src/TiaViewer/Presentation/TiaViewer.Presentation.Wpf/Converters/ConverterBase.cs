using System;
using System.Globalization;
using System.Windows.Data;

namespace TiaViewer.Presentation.Wpf.Converters
{
    public abstract class ConverterBase<TSource, TDestination> : IValueConverter
    {

        #region Methods

        #region IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => Convert(value is TSource source ? source : default);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => ConvertBack(value is TDestination source ? source : default);

        #endregion


        protected abstract TDestination Convert(TSource source);

        protected virtual TSource ConvertBack(TDestination destination)
        {
            return default;
        }
        #endregion
    }
}