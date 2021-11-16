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
        public string DisplayText { get; private set; }
        private async Task Pikachu()
        {
            // instantiate client
            PokeApiClient pokeClient = new PokeApiClient();

            // get a resource by name
            Pokemon pikachu = await pokeClient.GetResourceAsync<Pokemon>("pikachu");
            string payload = pikachu.Height.ToString();
        }

        public void Init(string payload)
        {
            DisplayText = payload;
        }
    }
}
