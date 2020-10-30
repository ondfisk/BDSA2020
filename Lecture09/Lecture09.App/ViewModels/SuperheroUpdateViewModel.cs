using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Lecture09.App.Models;
using Lecture09.App.Services;

namespace Lecture09.App.ViewModels
{
    public class SuperheroUpdateViewModel : BaseViewModel
    {
        private readonly IRestClient _client;

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _alterEgo;
        public string AlterEgo
        {
            get { return _alterEgo; }
            set { SetProperty(ref _alterEgo, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _portraitUrl;
        public string PortraitUrl
        {
            get { return _portraitUrl; }
            set { SetProperty(ref _portraitUrl, value); }
        }

        private string _occupation;
        public string Occupation
        {
            get { return _occupation; }
            set { SetProperty(ref _occupation, value); }
        }

        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set { SetProperty(ref _cityName, value); }
        }

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        private int? _firstAppearance;
        public int? FirstAppearance
        {
            get { return _firstAppearance; }
            set { SetProperty(ref _firstAppearance, value); }
        }

        private string _backgroundUrl;
        public string BackgroundUrl
        {
            get { return _backgroundUrl; }
            set { SetProperty(ref _backgroundUrl, value); }
        }

        private string _powers;
        public string Powers
        {
            get { return _powers; }
            set { SetProperty(ref _powers, value); }
        }

        public ObservableCollection<Gender> GenderNames { get; } = new ObservableCollection<Gender> { Gender.Female, Gender.Male };

        public ICommand LoadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public SuperheroUpdateViewModel(IRestClient client)
        {
            _client = client;

            LoadCommand = new RelayCommand(o => ExecuteLoadCommand((SuperheroDetailsDTO)o), _ => !IsBusy);
            SaveCommand = new RelayCommand(async _ => await ExecuteSaveCommand(), _ => !IsBusy);
            CancelCommand = new RelayCommand(async _ => await ExecuteCancelCommand(), _ => !IsBusy);
        }

        private void ExecuteLoadCommand(SuperheroDetailsDTO superhero)
        {
            IsBusy = true;

            Title = superhero.AlterEgo;
            Id = superhero.Id;
            Name = superhero.Name;
            AlterEgo = superhero.AlterEgo;
            PortraitUrl = superhero.PortraitUrl;
            Occupation = superhero.Occupation;
            CityName = superhero.CityName;
            Gender = superhero.Gender;
            FirstAppearance = superhero.FirstAppearance;
            BackgroundUrl = superhero.BackgroundUrl;
            Powers = string.Join(Environment.NewLine, superhero.Powers);

            IsBusy = false;
        }

        private async Task ExecuteSaveCommand()
        {
            IsBusy = true;

            var powers = Powers?.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()) ?? new string[0];

            var superhero = new SuperheroUpdateDTO
            {
                Id = Id,
                Name = Name,
                AlterEgo = AlterEgo,
                Occupation = Occupation,
                CityName = CityName,
                PortraitUrl = PortraitUrl,
                BackgroundUrl = BackgroundUrl,
                FirstAppearance = FirstAppearance,
                Gender = Gender,
                Powers = new HashSet<string>(powers)
            };

            await _client.PutAsync($"superheroes/{Id}", superhero);

            var superheroDetailsDTO = new SuperheroDetailsDTO
            {
                Id = Id,
                Name = Name,
                AlterEgo = AlterEgo,
                Occupation = Occupation,
                CityName = CityName,
                PortraitUrl = PortraitUrl,
                BackgroundUrl = BackgroundUrl,
                FirstAppearance = FirstAppearance,
                Gender = Gender,
                Powers = superhero.Powers
            };

            IsBusy = false;
        }

        private async Task ExecuteCancelCommand()
        {
            IsBusy = true;

            await Task.Delay(1);

            IsBusy = false;
        }
    }
}
