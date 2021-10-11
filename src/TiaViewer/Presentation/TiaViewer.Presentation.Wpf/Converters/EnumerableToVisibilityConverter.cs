using System.Collections;
using System.Windows;

namespace TiaViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Collection to visibility converter
    /// </summary>
    /// <remarks>Check collection is empty or not</remarks>
    public class CollectionToVisibilityConverter : ConverterBase<ICollection, Visibility>
    {
        /// <summary>
        /// Visibility by empty collection
        /// </summary>
        public Visibility Empty { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// Visibility by not empty collection
        /// </summary>
        public Visibility NotEmpty { get; set; } = Visibility.Visible;

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="source">The collection</param>
        /// <returns>Visibility</returns>
        protected override Visibility Convert(ICollection source)
            => source?.Count > 0 ? NotEmpty : Empty;
    }
}