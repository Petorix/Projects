using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGU_App.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Plugin.LocalNotifications;

namespace WGU_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentPage : ContentPage
    {
        private string[] TestTypes = new string[] { "Objective Assessment", "Performance Assessment" };
        private int PrimaryId;
        private int ForeignId;
        private bool newClass;
        private DateTime prevStartDate;
        private DateTime prevEndDate;
        private readonly int AssessmentHash;

        public AssessmentPage(int classId)
        {
            InitializeComponent();
            Random rand = new Random();

            PrimaryId = -1;
            ForeignId = classId;
            newClass = true;
            TypePicker.ItemsSource = TestTypes;
            TypePicker.SelectedIndex = 0;
            prevStartDate = StartDate.Date;
            prevEndDate = EndDate.Date;
            StartDate.MinimumDate = DateTime.Today;
            EndDate.MinimumDate = StartDate.Date.AddDays(1);
            AssessmentHash = StaticMethods.HashMaker($"Assessment{classId}");

            //Events
            var addClassClickEvent = new TapGestureRecognizer();
            addClassClickEvent.Tapped += (s, e) => { ToggleEdit(); };
            EditLabel.GestureRecognizers.Add(addClassClickEvent);

            StartDate.DateSelected += (s, e) =>
            {
                EndDate.MinimumDate = StartDate.Date.AddDays(1);
            };
        }

        public AssessmentPage(int classId, int assessmentId)
        {
            InitializeComponent();
            PrimaryId = assessmentId;
            ForeignId = classId;
            newClass = false;
            TypePicker.ItemsSource = TestTypes;
            Assessment assess;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Assessment>();
                assess = conn.Table<Assessment>().ToList().Single(s => s.Id == assessmentId);
            }

            NameEntry.Text = assess.Name;
            StartDate.Date = assess.StartDate;
            EndDate.Date = assess.EndDate;
            prevStartDate = StartDate.Date;
            prevEndDate = EndDate.Date;
            StartDate.MinimumDate = assess.StartDate.Date;
            EndDate.MinimumDate = StartDate.Date.AddDays(1);
            TypePicker.SelectedIndex = assess.AssessmentType;
            NotifySwitch.IsToggled = assess.Reminders;
            AssessmentHash = assess.UniqueHash;

            ToggleEdit();


            //Events
            var addClassClickEvent = new TapGestureRecognizer();
            addClassClickEvent.Tapped += (s, e) => { ToggleEdit(); };
            EditLabel.GestureRecognizers.Add(addClassClickEvent);

            StartDate.DateSelected += (s, e) =>
            {
                EndDate.MinimumDate = StartDate.Date.AddDays(1);
            };
        }


        //Helper Functions
        private void ToggleEdit()
        {
            //Class
            NameEntry.IsReadOnly ^= true;
            EntryColorSwapper(NameEntry);
            CheckAndToggleDates();
            TypePicker.IsEnabled ^= true;

            //Notification
            NotifySwitch.IsEnabled ^= true;

            EditButtons.IsVisible ^= true;
        }

        private void EntryColorSwapper(Entry entry)
        {
            if (entry.BackgroundColor == Color.FromHex("#EEEEEE"))
            {
                entry.BackgroundColor = Color.Transparent;
            }
            else
            {
                entry.BackgroundColor = Color.FromHex("#EEEEEE");
            }
        }

        private void CheckAndToggleDates()
        {
            if (prevStartDate != StartDate.Date && StartDate.IsEnabled)
            {
                StartDate.Date = prevStartDate;
            }
            if (prevEndDate != EndDate.Date && EndDate.IsEnabled)
            {
                EndDate.Date = prevEndDate;
            }

            StartDate.IsEnabled ^= true;
            EndDate.IsEnabled ^= true;
        }

        private bool ValidateEntries()
        {
            string errormsg = "";
            bool valid = true;

            if (String.IsNullOrWhiteSpace(NameEntry.Text))
            {
                errormsg += "Assessment name missing.  ";
                valid = false;
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Assessment>();
                var assess = conn.Table<Assessment>().ToList().Where(s => s.ForeignClassId == ForeignId);

                foreach(Assessment item in assess)
                {
                    if(item.Id != PrimaryId && item.AssessmentType == TypePicker.SelectedIndex)
                    {
                        errormsg += "Assessment type already assigned to this class, pick another type.  ";
                        valid = false;
                    }
                }
                
            }

            if (!valid)
            {
                ErrorMessageLabel.IsVisible = true;
                ErrorMessageLabel.Text = errormsg;
            }

            return valid;
        }

        private Assessment UpdateAssessment(Assessment assess)
        {
            assess.ForeignClassId = ForeignId;
            assess.Name = NameEntry.Text;
            assess.StartDate = StartDate.Date;
            assess.EndDate = EndDate.Date;
            assess.AssessmentType = TypePicker.SelectedIndex;
            assess.Reminders = NotifySwitch.IsToggled;
            assess.UniqueHash = AssessmentHash;

            return assess;
        }

        private void SetNotification()
        {
            if (NotifySwitch.IsToggled == true)
            {
                string start = StartDate.Date.ToString("MMMM dd yyyy");
                string end = EndDate.Date.ToString("MMMM dd yyyy");

                CrossLocalNotifications.Current.Show($"{NameEntry.Text}", $"Scheduled: {start} - {end}", AssessmentHash, StartDate.Date);
            }
            else if (NotifySwitch.IsToggled == false)
            {
                CrossLocalNotifications.Current.Cancel(AssessmentHash);
            }
        }

        //Events
        private void DeleteTestButton_Clicked(object sender, EventArgs e)
        {
            if (PrimaryId == -1)
            {
                Navigation.PopAsync();
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Assessment>();
                conn.Delete(conn.Table<Assessment>().ToList().Single(s => s.Id == PrimaryId));
            }

            CrossLocalNotifications.Current.Cancel(AssessmentHash);

            Navigation.PopAsync();
        }

        private void SaveTestButton_Clicked(object sender, EventArgs e)
        {
            if (!ValidateEntries()) { return; }

            if (newClass)
            {
                Assessment assess = new Assessment();

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<Assessment>();
                    conn.Insert(UpdateAssessment(assess));
                }
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<StudentClass>();
                    Assessment assess = conn.Table<Assessment>().ToList().Single(s => s.Id == PrimaryId);
                    conn.Update(UpdateAssessment(assess));
                }
            }

            SetNotification();

            Navigation.PopAsync();
        }

        private void CancelTestButton_Clicked(object sender, EventArgs e)
        {
            ToggleEdit();
        }
    }
}