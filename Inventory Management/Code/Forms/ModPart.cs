using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventorySystem_PeterWilliams
{
    public partial class ModPart : Form
    {
        private int PartID { get; set; }
        private string PartName { get; set; }
        private string SwingEntry { get; set; }
        private decimal Price { get; set; }
        private int Inv { get; set; }
        private int Min { get; set; }
        private int Max { get; set; }

        private bool tester = false;

        public Part Part { get; set; }
        public ModPart(Part currPart)
        {
            InitializeComponent();

            PartID = currPart.PartID;
            partIDText.Text = currPart.PartID.ToString();
            namePartText.Text = currPart.Name.ToString();
            pricePartText.Text = currPart.Price.ToString();
            invPartText.Text = currPart.InStock.ToString();
            minPartText.Text = currPart.Min.ToString();
            maxPartText.Text = currPart.Max.ToString();

            if (currPart is Inhouse)
            {
                inHouseRadio.Checked = true;
                swingPartText.Text = (currPart as Inhouse).MachineID.ToString();
            }
            else if (currPart is Outsourced)
            {
                outsourcedRadio.Checked = true;
                swingPartText.Text = (currPart as Outsourced).CompanyName;
            }
        }

        private void ValidateForm()
        {
            tester = true;

            if (String.IsNullOrWhiteSpace(namePartText.Text)) { tester = false; }
            if (String.IsNullOrWhiteSpace(pricePartText.Text)) { tester = false; }
            if (String.IsNullOrWhiteSpace(invPartText.Text)) { tester = false; }
            if (String.IsNullOrWhiteSpace(pricePartText.Text)) { tester = false; }
            if (String.IsNullOrWhiteSpace(minPartText.Text)) { tester = false; }
            if (String.IsNullOrWhiteSpace(maxPartText.Text)) { tester = false; }
            if (String.IsNullOrWhiteSpace(swingPartText.Text)) { tester = false; }

            if (tester)
            {
                savePartButton.ForeColor = SystemColors.ControlText;
            }
            else
            {
                savePartButton.ForeColor = SystemColors.ControlDark;
            }
        }

        private void savePartButton_Click(object sender, EventArgs e)
        {
            if (!tester) { return; }

            PartName = namePartText.Text;
            Price = Decimal.Parse(pricePartText.Text);
            Inv = Int32.Parse(invPartText.Text);
            Min = Int32.Parse(minPartText.Text);
            Max = Int32.Parse(maxPartText.Text);
            SwingEntry = swingPartText.Text;

            if (inHouseRadio.Checked)
            {
                Part = new Inhouse(PartName, Price, Inv, Min, Max, Int32.Parse(SwingEntry));
                Part.PartID = PartID;
            }
            else
            {
                Part = new Outsourced(PartName, Price, Inv, Min, Max, SwingEntry);
                Part.PartID = PartID;
            }

            Close();
        }

        private void cancelPartButton_Click(object sender, EventArgs e)
        {
            Part = null;
            Close();
        }

        private void IntegerChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DecimalChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void SwingChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inHouseRadio.Checked)
            {
                IntegerChecker_KeyPress(sender, e);
            }
        }

        private void inHouseRadio_MouseClick(object sender, MouseEventArgs e)
        {
            swingPartLabel.Text = "Machine ID";
            swingPartLabel.Location = new Point(30, 192);
            swingPartText.Text = "";
        }

        private void outsourcedRadio_MouseClick(object sender, MouseEventArgs e)
        {
            swingPartLabel.Text = "Company Name";
            swingPartLabel.Location = new Point(4, 192);
            swingPartText.Text = "";
        }

        private void namePartText_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).BackColor = Color.Salmon;
            }
            else
            {
                (sender as TextBox).BackColor = SystemColors.Window;
            }

            ValidateForm();
        }

        private void Tooltip_MouseHover(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace((sender as TextBox).Text) || String.IsNullOrEmpty((sender as TextBox).Text))
            {
                string swing = inHouseRadio.Checked == true ? "Machine ID requires a number" : "Company Name required.";
                switch ((sender as TextBox).Name)
                {
                    case "namePartText":
                        toolTip1.SetToolTip((sender as TextBox), "Name required.");
                        break;
                    case "invPartText":
                        toolTip1.SetToolTip((sender as TextBox), $"Inventory requires a number.");
                        break;
                    case "pricePartText":
                        toolTip1.SetToolTip((sender as TextBox), $"Price requires a numer.");
                        break;
                    case "maxPartText":
                        toolTip1.SetToolTip((sender as TextBox), $"Max requires a number.");
                        break;
                    case "minPartText":
                        toolTip1.SetToolTip((sender as TextBox), $"Min requires a number.");
                        break;
                    case "swingPartText":
                        toolTip1.SetToolTip((sender as TextBox), swing);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                toolTip1.SetToolTip((sender as TextBox), null);
            }
        }
    }
}
