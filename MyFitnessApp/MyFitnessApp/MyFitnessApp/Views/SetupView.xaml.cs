using MyFitnessApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFitnessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupView : ContentPage
    {
        private readonly SetupVM vm;

        public SetupView()
        {
            InitializeComponent();

            BindingContext = vm = new SetupVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.OnAppearing();
        }
    }
}