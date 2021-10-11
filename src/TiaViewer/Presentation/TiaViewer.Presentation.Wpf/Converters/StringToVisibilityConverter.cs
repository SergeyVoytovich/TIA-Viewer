using System.Windows;

namespace TiaViewer.Presentation.Wpf.Converters
{

    /// <summary>
    /// String to visibility converter
    /// </summary>
    public class EmptyStringToVisibilityConverter : ConverterBase<string, Visibility>
    {
        /// <summary>
        /// Visibility by empty string
        /// </summary>
        public Visibility Empty { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// Visiblity by not empty string
        /// </summary>
        public Visibility NotEmpty { get; set; } = Visibility.Visible;

        /// <summary>
        /// Convert string to visibility
        /// </summary>
        /// <param name="source">Source strign</param>
        /// <returns>Visibility</returns>
        protected override Visibility Convert(string source)
            => string.IsNullOrWhiteSpace(source) ? Empty : NotEmpty;
    }
}