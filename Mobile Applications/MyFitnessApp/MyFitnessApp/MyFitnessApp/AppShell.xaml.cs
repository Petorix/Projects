using MyFitnessApp.ViewModels;
using MyFitnessApp.Views;
using Xamarin.Forms;

namespace MyFitnessApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ExerciseView), typeof(ExerciseView));
            Routing.RegisterRoute(nameof(ExerciseDetailView), typeof(ExerciseDetailView));

            Routing.RegisterRoute(nameof(MealsView), typeof(MealsView));
            Routing.RegisterRoute(nameof(MealDetailView), typeof(MealDetailView));

            Routing.RegisterRoute(nameof(UserDetailView), typeof(UserDetailView));
            Routing.RegisterRoute(nameof(GoalDetailView), typeof(GoalDetailView));
            Routing.RegisterRoute(nameof(HistoryView), typeof(HistoryView));
        }
    }
}
