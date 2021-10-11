using System;
using System.Globalization;
using System.Windows.Data;

namespace TiaViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Base value converter
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TDestination">Destination type</typeparam>
    public abstract class ConverterBase<TSource, TDestination> : IValueConverter
    {

        #region Methods

        #region IValueConverter

        /// <summary>
        /// <see cref="IValueConverter"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => Convert(value is TSource source ? source : default);

        /// <summary>
        /// <see cref="IValueConverter"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => ConvertBack(value is TDestination source ? source : default);

        #endregion

        /// <summary>
        /// Convert from source to destination
        /// </summary>
        /// <param name="source">The source object</param>
        /// <returns>Instance of destination type or null</returns>
        protected abstract TDestination Convert(TSource source);

        /// <summary>
        /// Convert back from destination to source
        /// </summary>
        /// <param name="destination">The destination object</param>
        /// <returns>Instance of source type or null</returns>
        protected virtual TSource ConvertBack(TDestination destination)
        {
            return default;
        }
        #endregion
    }
}