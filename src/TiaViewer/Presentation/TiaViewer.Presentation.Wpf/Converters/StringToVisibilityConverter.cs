using System.Windows;

namespace TiaViewer.Presentation.Wpf.Converters
{

    public class StringToVisibilityConverter : ConverterBase<string, Visibility>
    {
        public Visibility Empty { get; set; } = Visibility.Collapsed;
        public Visibility NotEmpty { get; set; } = Visibility.Visible;

        protected override Visibility Convert(string source)
            => string.IsNullOrWhiteSpace(source) ? Empty : NotEmpty;
    }
}