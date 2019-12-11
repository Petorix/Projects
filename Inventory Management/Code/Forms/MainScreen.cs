using System;
using System.Windows.Forms;

namespace InventorySystem_PeterWilliams
{
    public partial class MainScreen : Form
    {
        private Inventory inventory = new Inventory();

        public MainScreen()
        {
            InitializeComponent();

            partsDataGrid.DataSource = inventory.Parts;
            partsDataGrid.AutoGenerateColumns = true;
            foreach (DataGridViewColumn col in partsDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.ReadOnly = true;
            }

            productDataGrid.DataSource = inventory.Products;
            productDataGrid.AutoGenerateColumns = true;
            foreach (DataGridViewColumn col in productDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.ReadOnly = true;
            }
        }

        private void addPartsMainButton_Click(object sender, EventArgs e)
        {
            using (AddPart addPart = new AddPart())
            {
                Hide();
                addPart.ShowDialog();
                Part part = addPart.Part;
                if (part != null)
                {
                    part.PartID = partsDataGrid.Rows.Count;
                    inventory.addPart(part);
                }
                Show();
            }
        }

        private void modPartsMainButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = partsDataGrid.CurrentCell.RowIndex;

                using (ModPart modPart = new ModPart(inventory.lookupPart(index)))
                {
                    Hide();
                    modPart.ShowDialog();
                    Part part = modPart.Part;
                    if (part != null) { inventory.updatePart(index, part); }
                    Show();
                }
            }
            catch
            {
                MessageBox.Show("Please select a part to modify.");
            }
        }

        private void deletePartsMainButton_Click(object sender, EventArgs e)
        {
            try
            {
                var index = partsDataGrid.CurrentCell.RowIndex;

                var msgResult = MessageBox.Show("Are you sure you want to delete this part?", "", MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.No) { return; }

                bool result = inventory.deletePart(inventory.Parts[index]);
                if (result) { return; }
            }
            catch
            {
                MessageBox.Show("Please select a part to delete.");
            }

        }

        private void addProdMainButton_Click(object sender, EventArgs e)
        {
            using (AddProduct addProd = new AddProduct(inventory.Parts))
            {
                Hide();
                addProd.ShowDialog();
                Product prod = addProd.NewProduct;
                if (prod != null)
                {
                    prod.ProductID = productDataGrid.Rows.Count;
                    inventory.addProduct(prod);
                }
                Show();
            }
        }

        private void modProdMainButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = productDataGrid.CurrentCell.RowIndex;

                using (ModProduct modProd = new ModProduct(inventory.Parts, inventory.lookupProduct(index)))
                {
                    Hide();
                    modProd.ShowDialog();
                    Product prod = modProd.NewProduct;
                    if (prod != null) { inventory.updateProduct(index, prod); }
                    Show();
                }
            }
            catch
            {
                MessageBox.Show("Please select a product to modify.");
            }
        }

        private void deleteProdMainButton_Click(object sender, EventArgs e)
        {
            try
            {
                var index = productDataGrid.CurrentCell.RowIndex;

                var msgResult = MessageBox.Show("Are you sure you want to delete this product?", "", MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.No) { return; }

                if (inventory.Products[index].AssociatedParts.Count > 0)
                {
                    MessageBox.Show("Remove associated parts with this product before deleting.");
                    return;
                }

                bool result = inventory.removeProduct(index);
                if (result) { return; }
            }
            catch
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void partsSearchButton_Click(object sender, EventArgs e)
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

        private void productSearchButton_Click(object sender, EventArgs e)
        {
            string val = searchProdText.Text;
            bool found = false;

            try
            {
                foreach (DataGridViewRow row in productDataGrid.Rows)
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
                foreach (DataGridViewRow row in productDataGrid.Rows)
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

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
