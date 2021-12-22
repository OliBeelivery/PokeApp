using System;
using System.Collections.Generic;
using System.Text;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using PokeApp.Mvvm.Pages;
using PokeApp.Mvvm.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using PokeApiNet;

namespace PokeApp.Mvvm.PageViewModels
{
    public class WalkthroughVM : BaseVM
    {
        private readonly IPageServiceZero _pageService;
        public WalkthroughVM(IPageServiceZero pageService)
        {
            _pageService = pageService;
            _ = PokeLocation();
            _ = PokeEncounter();
        }

        private string _displayText;
        private string _displayPokeEncounter;

        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        public string DisplayPokeEncounter
        {
            get
            {
                return _displayPokeEncounter;
            }
            set
            {
                _displayPokeEncounter = value;
                OnPropertyChanged("DisplayPokeEncounter");
            }
        }

        public void Init(string payload)
        {
            DisplayText = payload;
            DisplayPokeEncounter = payload;
        }

        public void InitPN(string pn)
        {
            DisplayPokeEncounter = pn;
        }

        private async Task PokeLocation()
        {
            // instantiate client
            PokeApiClient pokeClient = new PokeApiClient();
            // get a resource by name
            Region sinnoh = await pokeClient.GetResourceAsync<Region>("sinnoh");
            string payload = sinnoh.Name.ToString();
            Init(payload);
            
        }
        
        private async Task PokeEncounter()
        {
            // instantiate client
            PokeApiClient pokeClient = new PokeApiClient();
            // get a resource by name
            LocationArea name = await pokeClient.GetResourceAsync<LocationArea>("tentacool");
            string pn = name.Name.ToString();
            InitPN(pn);
        }
    }
}