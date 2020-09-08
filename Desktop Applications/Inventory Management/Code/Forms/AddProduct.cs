using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventorySystem_PeterWilliams
{
    public partial class AddProduct : Form
    {
        public Product NewProduct = new Product();
        private string PartName { get; set; }
        private decimal Price { get; set; }
        private int Inv { get; set; }
        private int Min { get; set; }
        private int Max { get; set; }
        private bool tester = false;

        public AddProduct(BindingList<Part> Parts)
        {
            InitializeComponent();

            partsDataGrid.DataSource = Parts;
            partsDataGrid.AutoGenerateColumns = true;
            foreach (DataGridViewColumn col in partsDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.ReadOnly = true;
            }

            prodPartsDataGrid.DataSource = NewProduct.AssociatedParts;
            prodPartsDataGrid.AutoGenerateColumns = true;
            foreach (DataGridViewColumn col in prodPartsDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.ReadOnly = true;
            }
        }

        private void cancProdAdd_Click(object sender, EventArgs e)
        {
            NewProduct = null;
            Close();
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

            if (tester)
            {
                saveProdAddButton.ForeColor = SystemColors.ControlText;
            }
            else
            {
                saveProdAddButton.ForeColor = SystemColors.ControlDark;
            }
        }

        private void saveProdAddButton_Click(object sender, EventArgs e)
        {
            if (!tester) { return; }

            PartName = namePartText.Text;
            Price = Decimal.Parse(pricePartText.Text);
            Inv = Int32.Parse(invPartText.Text);
            Min = Int32.Parse(minPartText.Text);
            Max = Int32.Parse(maxPartText.Text);

            NewProduct.UpdateProduct(PartName, Price, Inv, Min, Max);
            Close();
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

        private void addPartProdButton_Click(object sender, EventArgs e)
        {
            try
            {
                var index = partsDataGrid.CurrentCell.RowIndex;

                Part addPart = partsDataGrid.SelectedRows[0].DataBoundItem as Part;
                NewProduct.addAssociatedPart(addPart);
            }
            catch
            {
                return;
            }
        }

        private void pricePartText_KeyPress(object sender, KeyPressEventArgs e)
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

        private void invPartText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void delPartProdButton_Click(object sender, EventArgs e)
        {
            try
            {
                var index = prodPartsDataGrid.CurrentCell.RowIndex;

                var msgResult = MessageBox.Show("Are you sure you want to delete this part?", "", MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.No) { return; }

                NewProduct.removeAssociatedPart(index);
            }
            catch
            {
                return;
            }
        }
        private void Tooltip_MouseHover(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace((sender as TextBox).Text) || String.IsNullOrEmpty((sender as TextBox).Text))
            {
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
                    default:
                        break;
                }
            }
            else
            {
                toolTip1.SetToolTip((sender as TextBox), null);
            }
        }

        private void searchProdScButton_Click(object sender, EventArgs e)
        {
            string val = searchPartsText.Text;
            bool found = false;

            try
            {
                foreach (DataGridViewRow row in partsDataGrid.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value.ToString().ToLower().Equals(val.ToLower()))
                        {
                            row.Selected = true;
                            found = true;
                            break;
                        }
                    }
                    if (found) { break; }
                }

                if (found) { return; }
                foreach (DataGridViewRow row in partsDataGrid.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value.ToString().ToLower().Contains(val.ToLower()))
                        {
                            row.Selected = true;
                            found = true;
                            break;
                        }
                    }
                    if (found) { break; }
                }
            }
            catch
            {

            }
        }
    }
}
