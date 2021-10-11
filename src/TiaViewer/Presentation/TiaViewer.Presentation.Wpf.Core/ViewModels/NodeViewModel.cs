using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Node view model
    /// </summary>
    public class NodeViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        public string Id => OnGetProperty();

        /// <summary>
        /// Name
        /// </summary>
        public string Name => OnGetProperty();

        /// <summary>
        /// Properties
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="environment">View model environment</param>
        public NodeViewModel(ViewModelEnvironment environment) : base(environment)
        {
        }

        #endregion


        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal virtual string OnGetProperty([CallerMemberName] string key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Properties.TryGetValue(key, out var result);
            return result;
        }

        #endregion
    }
}