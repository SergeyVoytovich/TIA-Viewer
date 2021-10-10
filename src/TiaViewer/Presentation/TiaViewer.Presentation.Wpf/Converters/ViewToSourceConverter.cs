using System.Windows.Data;

namespace TiaViewer.Presentation.Wpf.Converters
{
    public class ViewToSourceConverter : ConverterBase<ListCollectionView, object>
    {
        protected override object Convert(ListCollectionView source)
            => source?.Groups;
    }
}