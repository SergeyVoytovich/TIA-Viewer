using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TiaViewer.Common.Domain;
using TiaViewer.Presentation.Wpf.Commands;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Main view model
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        /// Selected file
        /// </summary>
        public string SelectedFile { get => Get<string>(); set => Set(value); }

        /// <summary>
        /// Nodes
        /// </summary>
        public IList<NodeViewModel> Nodes { get => Get<List<NodeViewModel>>(); set => Set(value); }

        /// <summary>
        /// Open file command
        /// </summary>
        public ICommand OpenFileCommand { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="environment">View model environment</param>
        public MainViewModel(ViewModelEnvironment environment) : base(environment)
        {
            OpenFileCommand = new AsyncCommand(OpenFileAsync);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Open file
        /// </summary>
        /// <returns>Task</returns>
        internal virtual async Task OpenFileAsync()
        {
            if (!(Services.FileDialog.Show(out var file)) || string.IsNullOrWhiteSpace(file))
            {
                return;
            }

            SelectedFile = Path.GetFileName(file);
            await LoadNodes(file);
        }

        /// <summary>
        /// Load nodes
        /// </summary>
        /// <param name="file">Source file path</param>
        /// <returns>Task</returns>
        internal virtual async Task LoadNodes(string file)
        {
            var nodes = await Application.GetNodesAsync(file);
            DisplayNodes(nodes);
        }

        /// <summary>
        /// Display nodes
        /// </summary>
        /// <param name="nodes">List of nodes</param>
        internal virtual void DisplayNodes(IEnumerable<INode> nodes)
        {
            Nodes = nodes.Select(n => new NodeViewModel(new ViewModelEnvironment(Application, Services))
            {
                Type = n.Type,
                Properties = n.Properties
            }).ToList();
        }

        #endregion
    }
}