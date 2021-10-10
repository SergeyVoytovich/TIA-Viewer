using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TiaViewer.Common.Domain;
using TiaViewer.Presentation.Wpf.Commands;

namespace TiaViewer.Presentation.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public string SelectedFile { get => Get<string>(); set => Set(value); }

        public IList<NodeViewModel> Nodes { get => Get<List<NodeViewModel>>(); set => Set(value); }

        public ICommand OpenFileCommand { get; }

        public ICommand SelectTypeCommand { get; }

        public string SelectedType { get; set; }

        #endregion


        #region Constructors

        public MainViewModel(ViewModelEnvironment environment) : base(environment)
        {
            OpenFileCommand = new AsyncCommand(OpenFileAsync);
            SelectTypeCommand = new Command<object>(o => SelectedType = o.ToString());
        }

        #endregion


        #region Methods

        internal virtual async Task OpenFileAsync()
        {
            if (!(Services.FileDialog.Show(out var file)) || string.IsNullOrWhiteSpace(file))
            {
                return;
            }

            SelectedFile = Path.GetFileName(file);
            await LoadNodes(file);
        }

        internal virtual async Task LoadNodes(string file)
        {
            var nodes = await Application.GetNodesAsync(file);
            DisplayNodes(nodes);
        }

        internal virtual void DisplayNodes(IEnumerable<INode> nodes)
        {
            Nodes = nodes.Select(n => new NodeViewModel(new ViewModelEnvironment(Application, Services))
            {
                Type = n.Type
            }).ToList();
        }

        #endregion
    }
}