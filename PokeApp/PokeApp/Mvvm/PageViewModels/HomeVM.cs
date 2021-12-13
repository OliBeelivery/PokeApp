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
    public class HomeVM : BaseVM
    {
        private readonly IPageServiceZero _pageService;
        public ICommand HomeContentsCommand { get; }

        public HomeVM(IPageServiceZero pageService)
        {
            _pageService = pageService;

            HomeContentsCommand = new CommandBuilder().SetExecuteAsync(HomeContentsCommandExecuteAsync).SetName("Home Contents").Build();
            _ = Pikachu();
        }

        private async Task HomeContentsCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<HomeContents, HomeContentsVM>((vm) => { });
        }

        private string _displayText;

        public string DisplayText {
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


        private async Task Pikachu()
        {
            // instantiate client
            PokeApiClient pokeClient = new PokeApiClient();

            // get a resource by name
            Pokemon pikachu = await pokeClient.GetResourceAsync<Pokemon>("pikachu");
            string payload = pikachu.Height.ToString();
            Init(payload);
        }

        public void Init(string payload)
        {
            DisplayText = payload;
        }


    }
}
