namespace InventorySystem_PeterWilliams
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.partsSearchButton = new System.Windows.Forms.Button();
            this.productSearchButton = new System.Windows.Forms.Button();
            this.searchPartsText = new System.Windows.Forms.TextBox();
            this.searchProdText = new System.Windows.Forms.TextBox();
            this.partsLabel = new System.Windows.Forms.Label();
            this.productsLabel = new System.Windows.Forms.Label();
            this.addPartsMainButton = new System.Windows.Forms.Button();
            this.modPartsMainButton = new System.Windows.Forms.Button();
            this.deletePartsMainButton = new System.Windows.Forms.Button();
            this.deleteProdMainButton = new System.Windows.Forms.Button();
            this.modProdMainButton = new System.Windows.Forms.Button();
            this.addProdMainButton = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.partsDataGrid = new System.Windows.Forms.DataGridView();
            this.productDataGrid = new System.Windows.Forms.DataGridView();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // partsSearchButton
            // 
            this.partsSearchButton.Location = new System.Drawing.Point(200, 27);
            this.partsSearchButton.Name = "partsSearchButton";
            this.partsSearchButton.Size = new System.Drawing.Size(68, 20);
            this.partsSearchButton.TabIndex = 2;
            this.partsSearchButton.Text = "Search";
            this.partsSearchButton.UseVisualStyleBackColor = true;
            this.partsSearchButton.Click += new System.EventHandler(this.partsSearchButton_Click);
            // 
            // productSearchButton
            // 
            this.productSearchButton.Location = new System.Drawing.Point(712, 27);
            this.productSearchButton.Name = "productSearchButton";
            this.productSearchButton.Size = new System.Drawing.Size(68, 20);
            this.productSearchButton.TabIndex = 3;
            this.productSearchButton.Text = "Search";
            this.productSearchButton.UseVisualStyleBackColor = true;
            this.productSearchButton.Click += new System.EventHandler(this.productSearchButton_Click);
            // 
            // searchPartsText
            // 
            this.searchPartsText.Location = new System.Drawing.Point(274, 27);
            this.searchPartsText.Name = "searchPartsText";
            this.searchPartsText.Size = new System.Drawing.Size(171, 20);
            this.searchPartsText.TabIndex = 4;
            // 
            // searchProdText
            // 
            this.searchProdText.Location = new System.Drawing.Point(786, 27);
            this.searchProdText.Name = "searchProdText";
            this.searchProdText.Size = new System.Drawing.Size(171, 20);
            this.searchProdText.TabIndex = 5;
            // 
            // partsLabel
            // 
            this.partsLabel.AutoSize = true;
            this.partsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partsLabel.Location = new System.Drawing.Point(8, 42);
            this.partsLabel.Name = "partsLabel";
            this.partsLabel.Size = new System.Drawing.Size(46, 20);
            this.partsLabel.TabIndex = 6;
            this.partsLabel.Text = "Parts";
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsLabel.Location = new System.Drawing.Point(511, 42);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(72, 20);
            this.productsLabel.TabIndex = 7;
            this.productsLabel.Text = "Products";
            // 
            // addPartsMainButton
            // 
            this.addPartsMainButton.Location = new System.Drawing.Point(286, 365);
            this.addPartsMainButton.Name = "addPartsMainButton";
            this.addPartsMainButton.Size = new System.Drawing.Size(49, 23);
            this.addPartsMainButton.TabIndex = 8;
            this.addPartsMainButton.Text = "Add";
            this.addPartsMainButton.UseVisualStyleBackColor = true;
            this.addPartsMainButton.Click += new System.EventHandler(this.addPartsMainButton_Click);
            // 
            // modPartsMainButton
            // 
            this.modPartsMainButton.Location = new System.Drawing.Point(341, 365);
            this.modPartsMainButton.Name = "modPartsMainButton";
            this.modPartsMainButton.Size = new System.Drawing.Size(49, 23);
            this.modPartsMainButton.TabIndex = 9;
            this.modPartsMainButton.Text = "Modify";
            this.modPartsMainButton.UseVisualStyleBackColor = true;
            this.modPartsMainButton.Click += new System.EventHandler(this.modPartsMainButton_Click);
            // 
            // deletePartsMainButton
            // 
            this.deletePartsMainButton.Location = new System.Drawing.Point(396, 365);
            this.deletePartsMainButton.Name = "deletePartsMainButton";
            this.deletePartsMainButton.Size = new System.Drawing.Size(49, 23);
            this.deletePartsMainButton.TabIndex = 10;
            this.deletePartsMainButton.Text = "Delete";
            this.deletePartsMainButton.UseVisualStyleBackColor = true;
            this.deletePartsMainButton.Click += new System.EventHandler(this.deletePartsMainButton_Click);
            // 
            // deleteProdMainButton
            // 
            this.deleteProdMainButton.Location = new System.Drawing.Point(908, 365);
            this.deleteProdMainButton.Name = "deleteProdMainButton";
            this.deleteProdMainButton.Size = new System.Drawing.Size(49, 23);
            this.deleteProdMainButton.TabIndex = 13;
            this.deleteProdMainButton.Text = "Delete";
            this.deleteProdMainButton.UseVisualStyleBackColor = true;
            this.deleteProdMainButton.Click += new System.EventHandler(this.deleteProdMainButton_Click);
            // 
            // modProdMainButton
            // 
            this.modProdMainButton.Location = new System.Drawing.Point(853, 365);
            this.modProdMainButton.Name = "modProdMainButton";
            this.modProdMainButton.Size = new System.Drawing.Size(49, 23);
            this.modProdMainButton.TabIndex = 12;
            this.modProdMainButton.Text = "Modify";
            this.modProdMainButton.UseVisualStyleBackColor = true;
            this.modProdMainButton.Click += new System.EventHandler(this.modProdMainButton_Click);
            // 
            // addProdMainButton
            // 
            this.addProdMainButton.Location = new System.Drawing.Point(798, 365);
            this.addProdMainButton.Name = "addProdMainButton";
            this.addProdMainButton.Size = new System.Drawing.Size(49, 23);
            this.addProdMainButton.TabIndex = 11;
            this.addProdMainButton.Text = "Add";
            this.addProdMainButton.UseVisualStyleBackColor = true;
            this.addProdMainButton.Click += new System.EventHandler(this.addProdMainButton_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(908, 433);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(49, 23);
            this.Exit.TabIndex = 15;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // partsDataGrid
            // 
            this.partsDataGrid.AllowUserToAddRows = false;
            this.partsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.partsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.partsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.partsDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.partsDataGrid.Location = new System.Drawing.Point(12, 65);
            this.partsDataGrid.MultiSelect = false;
            this.partsDataGrid.Name = "partsDataGrid";
            this.partsDataGrid.RowHeadersVisible = false;
            this.partsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsDataGrid.Size = new System.Drawing.Size(462, 277);
            this.partsDataGrid.TabIndex = 16;
            // 
            // productDataGrid
            // 
            this.productDataGrid.AllowUserToAddRows = false;
            this.productDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.productDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.productDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.productDataGrid.Location = new System.Drawing.Point(515, 65);
            this.productDataGrid.MultiSelect = false;
            this.productDataGrid.Name = "productDataGrid";
            this.productDataGrid.RowHeadersVisible = false;
            this.productDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productDataGrid.Size = new System.Drawing.Size(462, 277);
            this.productDataGrid.TabIndex = 17;
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataSource = typeof(InventorySystem_PeterWilliams.Inventory);
            // 
            // partBindingSource
            // 
            this.partBindingSource.DataSource = typeof(InventorySystem_PeterWilliams.Part);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 478);
            this.Controls.Add(this.productDataGrid);
            this.Controls.Add(this.partsDataGrid);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.deleteProdMainButton);
            this.Controls.Add(this.modProdMainButton);
            this.Controls.Add(this.addProdMainButton);
            this.Controls.Add(this.deletePartsMainButton);
            this.Controls.Add(this.modPartsMainButton);
            this.Controls.Add(this.addPartsMainButton);
            this.Controls.Add(this.productsLabel);
            this.Controls.Add(this.partsLabel);
            this.Controls.Add(this.searchProdText);
            this.Controls.Add(this.searchPartsText);
            this.Controls.Add(this.productSearchButton);
            this.Controls.Add(this.partsSearchButton);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System";
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button partsSearchButton;
        private System.Windows.Forms.Button productSearchButton;
        private System.Windows.Forms.TextBox searchPartsText;
        private System.Windows.Forms.TextBox searchProdText;
        private System.Windows.Forms.Label partsLabel;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.Button addPartsMainButton;
        private System.Windows.Forms.Button modPartsMainButton;
        private System.Windows.Forms.Button deletePartsMainButton;
        private System.Windows.Forms.Button deleteProdMainButton;
        private System.Windows.Forms.Button modProdMainButton;
        private System.Windows.Forms.Button addProdMainButton;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private System.Windows.Forms.BindingSource partBindingSource;
        private System.Windows.Forms.DataGridView partsDataGrid;
        private System.Windows.Forms.DataGridView productDataGrid;
    }
}

