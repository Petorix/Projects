//REQUIREMENT F:
//Exception for scheduling outside of business hours is listed under the Save Button Click Event
//Exception for scheduling overlapping appointments is listed under the Save Button Click Event
//Both exceptions take into account the start and end times

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler_PeterWilliams
{
    public partial class EditAppointment : Form
    {
        private List<Appointment> appointments;

        public bool Changed { get; set; }

        public string Title { get; set; }
        public string TypeAppt { get; set; }
        public string Contact { get; set; }
        public string Customer { get; set; }
        public string LocationAppt { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EditAppointment(List<string> customers, List<Appointment> appt)
        {
            InitializeComponent();

            foreach (var item in customers)
            {
                custBox.Items.Add(item);
            }

            custBox.DataSource = customers;
            startTime.CustomFormat = "HH:mm";
            endTime.CustomFormat = "HH:mm";

            Changed = false;

            appointments = appt;
        }

        public EditAppointment(List<string> customers, List<Appointment> appt, string title, string type, string contact, string customer, 
            string loc, string desc, DateTime start, DateTime end)
        {
            InitializeComponent();

            foreach (var item in customers)
            {
                custBox.Items.Add(item);
            }

            custBox.DataSource = customers;
            startTime.CustomFormat = "HH:mm";
            endTime.CustomFormat = "HH:mm";

            Changed = false;

            titleBox.Text = title;
            typeBox.Text = type;
            contBox.Text = contact;
            custBox.SelectedIndex = custBox.FindStringExact(customer);
            locBox.Text = loc;
            descBox.Text = desc;

            startDate.Value = start;
            startTime.Value = start;

            StartDate = startDate.Value.Date + startTime.Value.TimeOfDay;
            EndDate = endDate.Value.Date + endTime.Value.TimeOfDay;

            endDate.Value = end;
            endTime.Value = end;

            appointments = appt;
        }

        private void CancButt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButt_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = 0;
                string exceptionBuilder = "";

                TypeAppt = typeBox.Text;
                Customer = custBox.SelectedItem.ToString();
                StartDate = startDate.Value.Date + startTime.Value.TimeOfDay;
                EndDate = endDate.Value.Date + endTime.Value.TimeOfDay;

                if (!EntryChecker())
                {
                    counter++;
                    exceptionBuilder = exceptionBuilder + "'Need to select your appointment type.'\n";
                }
                
                if(!IsBetween())
                {
                    counter++;
                    exceptionBuilder = exceptionBuilder + "'Start time selected is outside of business hours.'\n";
                }

                if (!IsConflictedSchedule())
                {
                    counter++;
                    exceptionBuilder = exceptionBuilder + "'Conflicting schedules.  Try changing your start and end times.'\n";
                }

                if (counter > 0)
                {
                    exceptionBuilder = $"Encountered {counter} errors: \n\n" + exceptionBuilder;
                    throw new Exception(exceptionBuilder);
                }


                if (titleBox.Text == "")
                {
                    Title = "Not Needed";
                }
                else
                {
                    Title = titleBox.Text;
                }

                if (contBox.Text == "")
                {
                    Contact = "Not Needed";
                }
                else
                {
                    Contact = contBox.Text;
                }

                if (locBox.Text == "")
                {
                    LocationAppt = "Not Needed";
                }
                else
                {
                    LocationAppt = locBox.Text;
                }

                if (descBox.Text == "")
                {
                    Description = "Not Needed";
                }
                else
                {
                    Description = descBox.Text;
                }

                Changed = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool EntryChecker()
        {
            List<string> entries = new List<string>();
            entries.Add(typeBox.Text);
            entries.Add(custBox.SelectedItem.ToString());
            bool test = true;

            foreach (string entry in entries)
            {
                if (String.IsNullOrEmpty(entry))
                {
                    test = false;
                    break;
                }
            }

            return test;
        }

        private bool IsBetween()
        {
            DateTime start = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day, 8, 0, 0);
            DateTime end = new DateTime(startTime.Value.Year, startTime.Value.Month, startTime.Value.Day, 17, 0, 0);
            return (startTime.Value > start && startTime.Value < end);
        }

        private bool IsConflictedSchedule()
        {
            bool test = true;

            foreach (Appointment app in appointments)
            {
                if (StartDate.Ticks >= app.start.Ticks && StartDate.Ticks <= app.end.Ticks)
                {
                    test = false;
                }

                if (EndDate.Ticks >= app.start.Ticks && EndDate.Ticks <= app.end.Ticks)
                {
                    test = false;
                }
            }

            return test;
        }
    }
}
