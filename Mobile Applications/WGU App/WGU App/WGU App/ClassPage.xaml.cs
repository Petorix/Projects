using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WGU_App.Classes;
using SQLite;
using Xamarin.Essentials;
using System.Text.RegularExpressions;
using Plugin.LocalNotifications;

namespace WGU_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClassPage : ContentPage
    {
        private string[] Status = new string[] { "Plan to take", "In Progress", "Completed", "Dropped" };
        private int TermId;
        private int PrimaryId;
        private bool newClass;
        private DateTime prevStartDate;
        private DateTime prevEndDate;
        private int ClassHash;

        public ClassPage(int termId)
        {
            InitializeComponent();
            TermId = termId;
            PrimaryId = -1;

            CheckAndRemoveAssessments();

            StatusPicker.ItemsSource = Status;
            StatusPicker.SelectedIndex = 0;
            newClass = true;
            StartDate.MinimumDate = DateTime.Today;
            EndDate.MinimumDate = StartDate.Date.AddDays(1);
            prevStartDate = StartDate.Date;
            prevEndDate = EndDate.Date;
            ClassHash = StaticMethods.HashMaker($"Class{termId}");

            //Events
            StartDate.DateSelected += (s, e) =>
            {
                EndDate.MinimumDate = StartDate.Date.AddDays(1);
            };

            var addClassClickEvent = new TapGestureRecognizer();
            addClassClickEvent.Tapped += (s, e) => { ToggleEdit(); };
            EditLabel.GestureRecognizers.Add(addClassClickEvent);


            //Make Content Scrollable
            Content = new ScrollView { Content = Content };
        }

        public ClassPage(int termId, int classId)
        {
            InitializeComponent();
            TermId = termId;
            PrimaryId = classId;
            StatusPicker.ItemsSource = Status;
            newClass = false;
            StudentClass sc;

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<StudentClass>();
                sc = conn.Table<StudentClass>().ToList().Single(s => s.Id == PrimaryId);
            }

            //Fill in Data
            //Class
            TitleEntry.Text = sc.Title;
            StartDate.Date = sc.StartDate;
            EndDate.Date = sc.EndDate;
            prevStartDate = StartDate.Date;
            prevEndDate = EndDate.Date;
            StartDate.MinimumDate = sc.StartDate.Date;
            EndDate.MinimumDate = StartDate.Date.AddDays(1);
            StatusPicker.SelectedIndex = sc.Status;
            //Instructor
            NameEntry.Text = sc.Instructor;
            PhoneEntry.Text = sc.Phone;
            EmailEntry.Text = sc.Email;
            //Notification
            NotifySwitch.IsToggled = sc.Notifications;
            //Notes
            NoteEditor.Text = sc.Notes;

            ClassHash = sc.UniqueHash;

            ToggleEdit();

            //Events
            StartDate.DateSelected += (s, e) =>
            {
                EndDate.MinimumDate = StartDate.Date.AddDays(1);
            };

            var addClassClickEvent = new TapGestureRecognizer();
            addClassClickEvent.Tapped += (s, e) => { ToggleEdit(); };
            EditLabel.GestureRecognizers.Add(addClassClickEvent);

            //Make Content Scrollable
            Content = new ScrollView { Content = Content };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            TestDisplay();
        }

        private void TestDisplay()
        {
            TestsHolder.Children.Clear();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Assessment>();

                var tests = conn.Table<Assessment>().ToList().Where(s => s.ForeignClassId == PrimaryId);
                int counter = 0;

                foreach(Assessment item in tests)
                {
                    string typeText = (item.AssessmentType == 0) ? "Objective Assessment" : "Performance Assessment";
                    
                    StackLayout innerStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                            {
                                new Label { Text = $"{item.Name}", VerticalOptions = LayoutOptions.CenterAndExpand },
                                new Label
                                {
                                    Text = $"{typeText}",
                                    HorizontalOptions = LayoutOptions.EndAndExpand,
                                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                                    VerticalOptions = LayoutOptions.CenterAndExpand,
                                    Margin = new Thickness(0, 0, 5, 0)
                                },
                                new DatePicker
                                {
                                    HorizontalOptions = LayoutOptions.End,
                                    VerticalOptions = LayoutOptions.Center,
                                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(DatePicker)),
                                    IsEnabled = false,
                                    Date = item.StartDate
                                },
                                new Label { Text = "-", HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center },
                                new DatePicker
                                {
                                    HorizontalOptions = LayoutOptions.End,
                                    VerticalOptions = LayoutOptions.Center,
                                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(DatePicker)),
                                    IsEnabled = false,
                                    Date = item.EndDate
                                },

                            }
                    };

                    var assessmentClickEvent = new TapGestureRecognizer();
                    assessmentClickEvent.Tapped += (s, e) => {
                        Navigation.PushAsync(new AssessmentPage(PrimaryId, item.Id));
                    };
                    innerStack.GestureRecognizers.Add(assessmentClickEvent);

                    BoxView divider = new BoxView { Color = Color.FromHex("#002F51"), HeightRequest = 1, Margin = new Thickness(0, 0, 0, 5) };

                    TestsHolder.Children.Add(innerStack);
                    TestsHolder.Children.Add(divider);

                    counter++;
                }

                AddAssessmentButton.IsVisible = counter < 2;
            }
        }

        //Helper Functions
        private void ToggleEdit()
        {
            //Class
            TitleEntry.IsReadOnly ^= true;
            EntryColorSwapper(TitleEntry);
            CheckAndToggleDates();
            StatusPicker.IsEnabled ^= true;

            //Instructor
            NameEntry.IsReadOnly ^= true;
            EntryColorSwapper(NameEntry);
            PhoneEntry.IsReadOnly ^= true;
            EntryColorSwapper(PhoneEntry);
            EmailEntry.IsReadOnly ^= true;
            EntryColorSwapper(EmailEntry);

            //Notification
            NotifySwitch.IsEnabled ^= true;

            //Notes
            NoteEditor.IsReadOnly ^= true;

            EditButtons.IsVisible ^= true;
        }

        private void EntryColorSwapper(Entry entry)
        {
            if(entry.BackgroundColor == Color.FromHex("#EEEEEE"))
            {
                entry.BackgroundColor = Color.Transparent;
            }
            else
            {
                entry.BackgroundColor = Color.FromHex("#EEEEEE");
            }
        }

        private StudentClass UpdateClass(StudentClass sc)
        {
            sc.ForeignTermId = TermId;
            sc.Title = TitleEntry.Text;
            sc.StartDate = StartDate.Date;
            sc.EndDate = EndDate.Date;
            sc.Status = StatusPicker.SelectedIndex;
            sc.Instructor = NameEntry.Text;
            sc.Phone = PhoneEntry.Text;
            sc.Email = EmailEntry.Text;
            sc.Notifications = NotifySwitch.IsToggled;
            sc.Notes = NoteEditor.Text;

            return sc;
        }

        private bool ValidateEntries()
        {
            string errormsg = "";
            bool valid = true;

            if(String.IsNullOrWhiteSpace(TitleEntry.Text))
            {
                errormsg += "Title missing.  ";
                valid = false;
            }
            if(String.IsNullOrWhiteSpace(NameEntry.Text))
            {
                errormsg += "Instructor name missing.  ";
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(PhoneEntry.Text))
            {
                errormsg += "Instructor phone number missing.  ";
                valid = false;
            }
            if (String.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                errormsg += "Instructor email missing.  ";
                valid = false;
            }
            else if (!IsValidEmail())
            {
                errormsg += "Incorrect format for instructor email.  ";
                valid = false;
            }

            if (!valid)
            {
                ErrorMessageLabel.IsVisible = true;
                ErrorMessageLabel.Text = errormsg;
            }

            return valid;
        }

        private bool IsValidEmail()
        {
            Regex rx = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(EmailEntry.Text);
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

        private void CheckAndRemoveAssessments()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Assessment>();
                var tests = conn.Table<Assessment>().ToList().Where(s => s.ForeignClassId == PrimaryId);

                foreach (Assessment assess in tests)
                {
                    conn.Delete(assess);
                }
            }
        }

        private void CheckAndUpdateAssessments()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<StudentClass>();
                conn.CreateTable<Assessment>();

                StudentClass sc = conn.Table<StudentClass>().ToList().Last();
                var tests = conn.Table<Assessment>().ToList().Where(s => s.ForeignClassId == -1);

                foreach (Assessment assess in tests)
                {
                    assess.ForeignClassId = sc.Id;
                    conn.Update(assess);
                }
            }

        }

        private void SetNotification()
        {
            if (NotifySwitch.IsToggled == true)
            {
                string start = StartDate.Date.ToString("MMMM dd yyyy");
                string end = EndDate.Date.ToString("MMMM dd yyyy");

                CrossLocalNotifications.Current.Show($"{TitleEntry.Text}", $"Scheduled: {start} - {end}", ClassHash, StartDate.Date);
            }
            else if (NotifySwitch.IsToggled == false)
            {
                CrossLocalNotifications.Current.Cancel(ClassHash);
            }
        }

        private async Task ShareNote()
        {
            await Share.RequestAsync(new ShareTextRequest { 
                Text = NoteEditor.Text,
                Title = "Share Class Note"
            });
        }

        //Events
        private void DeleteClassButton_Clicked(object sender, EventArgs e)
        {
            CheckAndRemoveAssessments();

            if (PrimaryId == -1) 
            {
                Navigation.PopAsync();
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<StudentClass>();
                conn.Delete(conn.Table<StudentClass>().ToList().Single(s => s.Id == PrimaryId));
            }

            CrossLocalNotifications.Current.Cancel(ClassHash);

            Navigation.PopAsync();
        }

        private void SaveClassButton_Clicked(object sender, EventArgs e)
        {
            if(!ValidateEntries()) { return; }

            if (newClass)
            {
                StudentClass sc = new StudentClass();

                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<StudentClass>();
                    conn.Insert(UpdateClass(sc));
                }

                CheckAndUpdateAssessments();
            }
            else
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.CreateTable<StudentClass>();
                    StudentClass sc = conn.Table<StudentClass>().ToList().Single(s => s.Id == PrimaryId);
                    conn.Update(UpdateClass(sc));
                }
            }

            SetNotification();

            Navigation.PopAsync();
        }

        private void CancelClassButton_Clicked(object sender, EventArgs e)
        {
            ToggleEdit();
        }

        private void AddAssessmentButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssessmentPage(PrimaryId));
        }

        private async void ShareNoteButton_Clicked(object sender, EventArgs e)
        {
            await ShareNote();
        }
    }
}