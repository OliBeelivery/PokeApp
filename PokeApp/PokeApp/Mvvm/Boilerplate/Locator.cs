using System;
using System.Collections.Generic;
using System.Text;
using FunctionZero.MvvmZero;
using PokeApp.Mvvm.Pages;
using PokeApp.Mvvm.PageViewModels;
using SimpleInjector;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApp.Mvvm.Boilerplate
{
	public class Locator
	{
		private Container _IoCC;

		internal Locator(Application currentApplication)
		{
			// Create the IoC container that will contain all our configurable classes ...
			_IoCC = new Container();

			// Tell the IoC container what to do if asked for an IPageService
			_IoCC.Register<IPageServiceZero>(
				() =>
				{
					// This is how we create an instance of PageServiceZero.
					// The PageService needs to know how to get the current NavigationPage it is to interact with.
					// (If you have a FlyoutPage at the root, the navigationGetter should return the current Detail item)
					// It also needs to know how to get Page and ViewModel instances so we provide it with a factory
					// that uses the IoC container. We could easily provide any sort of factory, we don't need to use an IoC container.
					var pageService = new PageServiceZero(() => App.Current.MainPage.Navigation, (theType) => _IoCC.GetInstance(theType));
					return pageService;
				},
				// One only ever will be created.
				Lifestyle.Singleton
			);

			// Tell the IoC container about our Pages.
			_IoCC.Register<Home>(Lifestyle.Singleton);
			_IoCC.Register<Pokedex>(Lifestyle.Singleton);
			_IoCC.Register<Walkthrough>(Lifestyle.Singleton);

			// Tell the IoC container about our ViewModels.
			_IoCC.Register<HomeVM>(Lifestyle.Singleton);
			_IoCC.Register<PokedexVM>(Lifestyle.Singleton);
			_IoCC.Register<WalkthroughVM>(Lifestyle.Singleton);

			// Optionally add more to the IoC conatainer, e.g. loggers, Http comms objects etc. E.g.
			// IoCC.Register<ILogger, MyLovelyLogger>(Lifestyle.Singleton);
		}

		/// <summary>
		/// This is called once during application startup
		/// </summary>
		internal async Task SetFirstPage()
		{
			// Create and assign a top-level NavigationPage.
			// If you use a FlyoutPage instead then its Detail item will need to be a NavigationPage
			// and you will need to modify the 'navigationGetter' provided to the PageServiceZero instance to 
			// something like this:
			// () => ((FlyoutPage)App.Current.MainPage).Detail.Navigation
			App.Current.MainPage = new NavigationPage();
			// Ask the PageService to assemble and present our HomePage ...
			await _IoCC.GetInstance<IPageServiceZero>().PushPageAsync<Home, HomeVM>((vm) => {/* Optionally interact with the vm, e.g. to inject seed-data */ });
		}

		/// <summary>
		/// For debug purposes to let us know when a Page is assembled by the PageService
		/// </summary>
		/// <param name="thePage">A reference to the page that has been presented</param>
		private void PageCreated(Page thePage)
		{
			Debug.WriteLine(thePage);
		}
	}
}
