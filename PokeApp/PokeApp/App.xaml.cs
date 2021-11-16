using PokeApp.Mvvm.Boilerplate;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokeApp
{
    public partial class App : Application
    {
        // Backing property for the Locator instance
        public Locator Locator { get; private set; }

        public App()
        {
            InitializeComponent();

            // Create our Locator instance and tell it about the Application instance ...
            Locator = new Locator(this);

            // Ask the Locator to get us going ...
            _ = Locator.SetFirstPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
