//REQUIREMENT F:
//Exception for entering nonexistent or invalid customer data is listed under
//the Save Button Click Event as well as it's EntryChecker helper function

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler_PeterWilliams
{
    public partial class EditCustomer : Form
    {
        public bool Changed { get; set; }

        public string NameCust { get; set; }
        public string Num { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public EditCustomer(List<string> cities)
        {
            InitializeComponent();

            foreach (var item in cities)
            {
                cityBox.Items.Add(item);
            }

            cityBox.DataSource = cities;

            Changed = false;
        }

        public EditCustomer(List<string> cities, string name, string num, string add1, string add2, string zip, string city)
        {
            InitializeComponent();

            titleLab.Text = "Edit Customer";

            foreach (var item in cities)
            {
                cityBox.Items.Add(item);
            }

            cityBox.DataSource = cities;
            nameBox.Text = name;
            numBox.Text = num;
            add1Box.Text = add1;
            add2Box.Text = add2;
            zipBox.Text = zip;
            cityBox.SelectedIndex = cityBox.FindStringExact(city);

            Changed = false;
        }

        private void CancButt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButt_Click(object sender, EventArgs e)
        {
            try
            {
                EntryChecker();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Missing {ex.Message} entry.");
                return;
            }

            NameCust = nameBox.Text;
            Num = numBox.Text;
            Add1 = add1Box.Text;
            Add2 = add2Box.Text;
            Zip = zipBox.Text;
            City = cityBox.SelectedItem.ToString();
            Changed = true;

            Close();
        }

        private void EntryChecker()
        {
            try
            {
                if(String.IsNullOrEmpty(nameBox.Text)) { throw new Exception("Name"); }
                if(String.IsNullOrEmpty(numBox.Text)) { throw new Exception("Phone Number"); }
                if(String.IsNullOrEmpty(add1Box.Text)) { throw new Exception("Street 1"); }
                if(String.IsNullOrEmpty(zipBox.Text)) { throw new Exception("Zip Code"); }
                if(String.IsNullOrEmpty(cityBox.SelectedItem.ToString())) { throw new Exception("City"); }
            }
            catch
            {
                throw;
            }

            //Good to go
        }
    }
}
