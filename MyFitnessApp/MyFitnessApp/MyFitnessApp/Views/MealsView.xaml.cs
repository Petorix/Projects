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
    public partial class MealsView : ContentPage
    {
        private readonly MealsVM vm;
        public MealsView()
        {
            InitializeComponent();

            BindingContext = vm = new MealsVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.OnAppearing();
        }
    }
}