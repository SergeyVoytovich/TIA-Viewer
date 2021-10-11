using System.Collections;
using System.Windows;

namespace TiaViewer.Presentation.Wpf.Converters
{
    public class EnumerableToVisibilityConverter : ConverterBase<ICollection, Visibility>
    {
        public Visibility Empty { get; set; } = Visibility.Collapsed;
        public Visibility NotEmpty { get; set; } = Visibility.Visible;

        protected override Visibility Convert(ICollection source)
            => source?.Count > 0 ? NotEmpty : Empty;
    }
}