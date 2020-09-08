using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;
using WGU_App.Classes;
using System.Linq;

namespace WGU_App.Classes
{
    class AddTermViews
    {
        public int TermId
        {
            get;
            set;
        }

        private Label editTermLabel;
        private Entry termName;
        private string previousText;
        private DateMaker dates;        
        private Button saveTermButt;
        private Button cancelTermButt;

        public StackLayout SCStack;
        public Label addClassLabel;
        public Button deleteTermButt;
        public StackLayout layout;

        public AddTermViews(Term term)
        {
            TermId = term.Id;

            editTermLabel = new Label { Text = "Edit Term", HorizontalOptions = LayoutOptions.End, Margin = new Thickness(10, 0) };
            addClassLabel = new Label { Text = "Add Class", HorizontalOptions = LayoutOptions.End, Margin = new Thickness(10, 15, 0, 5), IsVisible = false };

            SCStack = new StackLayout { Margin = new Thickness(15, 2, 0, 0) };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<StudentClass>();
                var scList = conn.Table<StudentClass>().ToList();
                
                foreach (StudentClass sc in scList)
                {
                    if (sc.ForeignTermId == TermId)
                    {
                        StackLayout innerStack = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            StyleId = $"{sc.Id}",
                            Children =
                            {
                                new Label { Text = $"{sc.Title}", VerticalOptions = LayoutOptions.CenterAndExpand },
                                new DatePicker
                                {
                                    HorizontalOptions = LayoutOptions.EndAndExpand,
                                    VerticalOptions = LayoutOptions.Center,
                                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(DatePicker)),
                                    IsEnabled = false,
                                    Date = sc.StartDate
                                },
                                new Label { Text = "-", HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center },
                                new DatePicker
                                {
                                    HorizontalOptions = LayoutOptions.End,
                                    VerticalOptions = LayoutOptions.Center,
                                    FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(DatePicker)),
                                    IsEnabled = false,
                                    Date = sc.EndDate
                                },

                            }
                        };

                        BoxView divider = new BoxView { Color = Color.FromHex("#002F51"), HeightRequest = 1, Margin = new Thickness(0, 0, 0, 5) };

                        SCStack.Children.Add(innerStack);
                        SCStack.Children.Add(divider);
                    }
                }
            }

            dates = new DateMaker(term.StartDate, term.EndDate);

            termName = new Entry 
            { 
                Text = $"{term.Name}", 
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)), 
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center, 
                IsReadOnly = true 
            };
            previousText = termName.Text;

            deleteTermButt = new Button { Text = "Delete", HorizontalOptions = LayoutOptions.StartAndExpand, IsVisible = false };
            saveTermButt = new Button { Text = "Save", IsVisible = false };
            cancelTermButt = new Button { Text = "Cancel", IsVisible = false };

            layout = new StackLayout
            {
                Margin = new Thickness(15, 10),
                BackgroundColor = Color.FromHex("#EEE"),
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    new StackLayout
                    {
                        Margin = new Thickness(15, 10),
                        VerticalOptions = LayoutOptions.Start,
                        Children  =
                        {
                            editTermLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    termName,
                                    dates.GetStart(),
                                    new Label { Text = "-", HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center },
                                    dates.GetEnd()
                                }
                            },
                            new BoxView
                            {
                                Color = Color.FromHex("#002F51"),
                                HeightRequest = 3,
                                Margin = new Thickness(0, 5)
                            },
                            SCStack,
                            addClassLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    deleteTermButt,
                                    saveTermButt,
                                    cancelTermButt
                                }
                            }
                        }
                    }
                }
            };


            //Event Initializers

            var editTermClickEvent = new TapGestureRecognizer();
            editTermClickEvent.Tapped += (s, e) => ToggleEditable();
            editTermLabel.GestureRecognizers.Add(editTermClickEvent);

            saveTermButt.Clicked += SaveTermButton_Clicked;
            cancelTermButt.Clicked += (s, e) => ToggleEditable();
        }

        private void ToggleEditable()
        {
            if (previousText != termName.Text && !termName.IsReadOnly )
            {
                termName.Text = previousText;
            }

            dates.CheckAndToggle();

            termName.IsReadOnly ^= true;
            addClassLabel.IsVisible ^= true;
            deleteTermButt.IsVisible ^= true;
            saveTermButt.IsVisible ^= true;
            cancelTermButt.IsVisible ^= true;
        }

        public void SaveTermButton_Clicked(object sender, EventArgs e)
        {
            previousText = termName.Text;

            dates.UpdateDates();
            ToggleEditable();

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Term>();
                Term term = conn.Table<Term>().ToList().Single(s => s.Id == TermId);

                term.Name = termName.Text;
                term.StartDate = dates.GetStart().Date;
                term.EndDate = dates.GetEnd().Date;

                conn.Update(term);
            }
        }
    }
}
