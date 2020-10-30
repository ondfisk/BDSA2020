using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Lecture09.App.Models;
using Lecture09.App.Services;
using System.Windows.Input;

namespace Lecture09.App.ViewModels
{
    public class SuperheroesViewModel : BaseViewModel
    {
        private readonly IRestClient _client;

        public ObservableCollection<SuperheroListDTO> Items { get; } = new ObservableCollection<SuperheroListDTO>();

        private SuperheroListDTO _selectedItem;
        public SuperheroListDTO SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                if (value != null)
                {
                    ViewCommand.Execute(null);
                    SelectedItem = null;
                }
            }
        }

        public ICommand LoadCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand ViewCommand { get; set; }

        public SuperheroesViewModel(IRestClient client)
        {
            _client = client;

            Title = "Browse";

            LoadCommand = new RelayCommand(async _ => await ExecuteLoadCommand(), _ => !IsBusy);
            NewCommand = new RelayCommand(async _ => await ExecuteNewCommand(), _ => !IsBusy);
            ViewCommand = new RelayCommand(async _ => await ExecuteViewCommand(), _ => !IsBusy);
        }

        private async Task ExecuteLoadCommand()
        {
            IsBusy = true;

            Items.Clear();

            var items = await _client.GetAllAsync<SuperheroListDTO>("superheroes");

            foreach (var item in items)
            {
                Items.Add(item);
            }

            IsBusy = false;
        }

        private async Task ExecuteNewCommand()
        {
            await Task.Delay(1);
        }

        private async Task ExecuteViewCommand()
        {
            await Task.Delay(1);
        }
    }
}
