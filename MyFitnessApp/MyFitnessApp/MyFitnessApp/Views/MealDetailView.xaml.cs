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
    public partial class MealDetailView : ContentPage
    {
        private readonly MealDetailVM vm;

        public MealDetailView()
        {
            InitializeComponent();

            BindingContext = vm = new MealDetailVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}