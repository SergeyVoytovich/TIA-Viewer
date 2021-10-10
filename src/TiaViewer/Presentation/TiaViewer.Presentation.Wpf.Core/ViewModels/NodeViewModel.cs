using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public class NodeViewModel : ViewModelBase
    {
        #region Properties

        public string Type { get; set; }
        public string Id => OnGetProperty();

        private string OnGetProperty([CallerMemberName] string key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            Properties.TryGetValue(key, out var result);
            return result;
        }

        public string Name => OnGetProperty();

    public IDictionary<string, string> Properties { get; set; }

    #endregion

    public NodeViewModel(ViewModelEnvironment environment) : base(environment)
    {
    }
}
}