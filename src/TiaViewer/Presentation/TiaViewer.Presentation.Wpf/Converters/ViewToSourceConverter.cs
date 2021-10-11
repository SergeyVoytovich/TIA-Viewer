using System.Collections.Generic;
using System.Windows.Data;

namespace TiaViewer.Presentation.Wpf.Converters
{

    /// <summary>
    /// <see cref="ListCollectionView"/> to the list groups converter
    /// </summary>
    public class ListCollectionViewToGroupsConverter : ConverterBase<ListCollectionView, ICollection<object>>
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="source"><see cref="ListCollectionView"/></param>
        /// <returns>Grouped list</returns>
        protected override ICollection<object> Convert(ListCollectionView source)
            => source?.Groups;
    }
}