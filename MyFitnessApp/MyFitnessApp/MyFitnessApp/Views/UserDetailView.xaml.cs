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
    public partial class UserDetailView : ContentPage
    {
        private readonly UserDetailVM vm;

        public UserDetailView()
        {
            InitializeComponent();

            BindingContext = vm = new UserDetailVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.OnAppearing();
        }
    }
}