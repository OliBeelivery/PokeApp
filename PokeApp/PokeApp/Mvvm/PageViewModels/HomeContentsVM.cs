using System;
using System.Collections.Generic;
using System.Text;
using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using PokeApp.Mvvm.Pages;
using PokeApp.Mvvm.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokeApp.Mvvm.PageViewModels
{
    public class HomeContentsVM : BaseVM
    {
        private readonly IPageServiceZero _pageService;
        public ICommand PokedexContentsCommand { get; }
        public ICommand WalkthroughContentsCommand { get; }

        public HomeContentsVM(IPageServiceZero pageService)
        {
            _pageService = pageService;

            PokedexContentsCommand = new CommandBuilder().SetExecuteAsync(PokedexContentsCommandExecuteAsync).SetName("Pokedex Contents").Build();

            WalkthroughContentsCommand = new CommandBuilder().SetExecuteAsync(WalkthroughContentsCommandExecuteAsync).SetName("Walkthrough Contents").Build();
        }

        private async Task PokedexContentsCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<PokedexContents, PokedexContentsVM>((vm) => {});
        }

        private async Task WalkthroughContentsCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<WalkthroughContents, WalkthroughContentsVM>((vm) => { });
        }
    }
}
