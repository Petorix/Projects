using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using WGU_App.Classes;
using WGU_App;
using Plugin.LocalNotifications;

namespace WGU_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private List<AddTermViews> layouts = new List<AddTermViews>();

        public MainPage()
        {
            InitializeComponent();

            BuildPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BuildPage();
        }

        private void BuildPage()
        {
            List<Term> terms;
            layouts = new List<AddTermViews>();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Term>();
                terms = conn.Table<Term>().ToList();
            }

            if (terms.Count > 0)
            {
                foreach (Term term in terms)
                {
                    AddTermViews view = new AddTermViews(term);

                    view.deleteTermButt.Clicked += (s, e) => DeleteTermButton_Clicked(view.TermId);

                    var addClassClickEvent = new TapGestureRecognizer();
                    addClassClickEvent.Tapped += (s, e) => {
                        view.SaveTermButton_Clicked(s, e);
                        Navigation.PushAsync(new ClassPage(term.Id)); 
                    };
                    view.addClassLabel.GestureRecognizers.Add(addClassClickEvent);

                    var children = view.SCStack.Children;

                    foreach(var child in children)
                    {
                        if(child is StackLayout)
                        {
                            var viewClassClickEvent = new TapGestureRecognizer();
                            viewClassClickEvent.Tapped += (s, e) => { Navigation.PushAsync(new ClassPage(term.Id, Int32.Parse(child.StyleId))); };
                            child.GestureRecognizers.Add(viewClassClickEvent);
                        }
                    }

                    layouts.Add(view);
                }
            }

            if (layouts.Count <= 0) 
            {
                Content = new StackLayout();
                return; 
            }

            StackLayout layout = new StackLayout();

            foreach (AddTermViews item in layouts)
            {
                layout.Children.Add(item.layout);
            }

            Content = new ScrollView { Content = layout };
        }

        private void AddTermButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Term>();
                var result = conn.Insert(new Term());
            }

            BuildPage();
        }

        public void DeleteTermButton_Clicked(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Term>();
                conn.Delete(conn.Table<Term>().ToList().Single(s => s.Id == id));
            }

            BuildPage();
        }

        private void DeleteAllTerms_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Term>();
                conn.DeleteAll<Term>();

                conn.CreateTable<StudentClass>();
                conn.DeleteAll<StudentClass>();

                conn.CreateTable<Assessment>();
                conn.DeleteAll<Assessment>();
            }

            BuildPage();
        }

        private void AddDummyFakeButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Term>();
                conn.CreateTable<StudentClass>();
                conn.CreateTable<Assessment>();

                var term = new Term();
                var course = new StudentClass();
                var ass1 = new Assessment();
                var ass2 = new Assessment();

                term.Name = "Fake Term";

                conn.Insert(term);
                int termId = conn.Table<Term>().ToList().Last().Id;

                course.ForeignTermId = termId;
                course.Title = "Fake Course";
                course.Instructor = "Peter Williams";
                course.Phone = "5413011849";
                course.Email = "pkwilliams1991@gmail.com";
                course.StartDate = DateTime.Today.AddDays(1);
                course.EndDate = course.StartDate.AddDays(1);
                course.Status = 0;
                course.Notifications = true;
                course.Notes = "This is a pre configured course used for demonstration and evaluation";
                course.UniqueHash = StaticMethods.HashMaker($"DummyCourse{termId}");

                conn.Insert(course);
                int courseId = conn.Table<StudentClass>().ToList().Last().Id;

                ass1.ForeignClassId = courseId;
                ass1.Name = "Fake Assessment 1";
                ass1.StartDate = DateTime.Today.AddDays(1);
                ass1.EndDate = ass1.StartDate.AddDays(1);
                ass1.AssessmentType = 0;
                ass1.Reminders = true;
                ass1.UniqueHash = StaticMethods.HashMaker($"DummyTest{courseId}");

                ass2.ForeignClassId = courseId;
                ass2.Name = "Fake Assessment 2";
                ass2.StartDate = DateTime.Today.AddDays(1);
                ass2.EndDate = ass2.StartDate.AddDays(1);
                ass2.AssessmentType = 1;
                ass2.Reminders = true;
                ass2.UniqueHash = StaticMethods.HashMaker($"DummyTest{courseId}");

                conn.Insert(ass1);
                conn.Insert(ass2);

            }

            BuildPage();
        }
    }
}
