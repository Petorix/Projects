using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WGU_App
{
    public partial class App : Application
    {
        public static string FilePath;

        public App(string filePath)
        {
            InitializeComponent();
            FilePath = filePath;

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#002F51"),
                BarTextColor = Color.White

            };
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
