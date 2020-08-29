using MyFitnessApp.Models;
using MyFitnessApp.Services;
using MyFitnessApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFitnessApp
{
    public partial class App : Application
    {
        public static string FilePath;
        public static DataManager dm;

        public App(string path)
        {
            FilePath = path;
            dm = new DataManager();

            InitializeComponent();

            var logged = Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result;
            if (logged == "1")
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new SetupView();
            }
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
