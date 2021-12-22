using System;
using System.Collections.Generic;
using System.Text;
using FunctionZero.MvvmZero;
using PokeApp.Mvvm.Pages;
using PokeApp.Mvvm.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;
using PokeApiNet;
using FunctionZero.CommandZero;

namespace PokeApp.Mvvm.PageViewModels
{
    public class WalkthroughContentsVM : BaseVM
    {
        private readonly IPageServiceZero _pageService;
        public ICommand WalkthroughCommand { get; }

        public WalkthroughContentsVM(IPageServiceZero pageService)
        {
            _pageService = pageService;
            WalkthroughCommand = new CommandBuilder().SetExecuteAsync(WalkthroughCommandExecuteAsync).SetName("Walkthrough").Build();
        }

        private async Task WalkthroughCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<Walkthrough, WalkthroughVM>((vm) => { });
        }


    }
}
