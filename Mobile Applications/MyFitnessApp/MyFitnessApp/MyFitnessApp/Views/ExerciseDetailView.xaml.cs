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
    public partial class ExerciseDetailView : ContentPage
    {
        private readonly ExerciseDetailVM vm;

        public ExerciseDetailView()
        {
            InitializeComponent();

            BindingContext = vm = new ExerciseDetailVM();
        }
    }
}