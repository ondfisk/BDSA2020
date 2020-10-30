using Lecture09.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Lecture09.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SuperheroesViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel = App.Container.GetRequiredService<SuperheroesViewModel>();

            _viewModel.LoadCommand.Execute(this);
        }
    }
}
