namespace InventorySystem_PeterWilliams
{
    partial class ModProduct
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
            this.minPartText = new System.Windows.Forms.TextBox();
            this.minPartLabel = new System.Windows.Forms.Label();
            this.maxPartText = new System.Windows.Forms.TextBox();
            this.maxPartLabel = new System.Windows.Forms.Label();
            this.pricePartText = new System.Windows.Forms.TextBox();
            this.pricePartLabel = new System.Windows.Forms.Label();
            this.invPartText = new System.Windows.Forms.TextBox();
            this.invPartLabel = new System.Windows.Forms.Label();
            this.namePartText = new System.Windows.Forms.TextBox();
            this.partNameLabel = new System.Windows.Forms.Label();
            this.idLabelAdd = new System.Windows.Forms.Label();
            this.saveProdAddButton = new System.Windows.Forms.Button();
            this.cancProdAdd = new System.Windows.Forms.Button();
            this.delPartProdButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addPartProdButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPartsText = new System.Windows.Forms.TextBox();
            this.searchProdScButton = new System.Windows.Forms.Button();
            this.addProductLabel = new System.Windows.Forms.Label();
            this.idLabelText = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.prodPartsDataGrid = new System.Windows.Forms.DataGridView();
            this.partsDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.prodPartsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // minPartText
            // 
            this.minPartText.BackColor = System.Drawing.Color.Salmon;
            this.minPartText.Location = new System.Drawing.Point(184, 280);
            this.minPartText.Name = "minPartText";
            this.minPartText.Size = new System.Drawing.Size(30, 20);
            this.minPartText.TabIndex = 68;
            this.minPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.minPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invPartText_KeyPress);
            this.minPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // minPartLabel
            // 
            this.minPartLabel.AutoSize = true;
            this.minPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minPartLabel.Location = new System.Drawing.Point(152, 281);
            this.minPartLabel.Name = "minPartLabel";
            this.minPartLabel.Size = new System.Drawing.Size(28, 15);
            this.minPartLabel.TabIndex = 67;
            this.minPartLabel.Text = "Min";
            // 
            // maxPartText
            // 
            this.maxPartText.BackColor = System.Drawing.Color.Salmon;
            this.maxPartText.Location = new System.Drawing.Point(114, 280);
            this.maxPartText.Name = "maxPartText";
            this.maxPartText.Size = new System.Drawing.Size(30, 20);
            this.maxPartText.TabIndex = 66;
            this.maxPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.maxPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invPartText_KeyPress);
            this.maxPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // maxPartLabel
            // 
            this.maxPartLabel.AutoSize = true;
            this.maxPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPartLabel.Location = new System.Drawing.Point(69, 280);
            this.maxPartLabel.Name = "maxPartLabel";
            this.maxPartLabel.Size = new System.Drawing.Size(31, 15);
            this.maxPartLabel.TabIndex = 65;
            this.maxPartLabel.Text = "Max";
            // 
            // pricePartText
            // 
            this.pricePartText.BackColor = System.Drawing.Color.Salmon;
            this.pricePartText.Location = new System.Drawing.Point(114, 254);
            this.pricePartText.Name = "pricePartText";
            this.pricePartText.Size = new System.Drawing.Size(100, 20);
            this.pricePartText.TabIndex = 64;
            this.pricePartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.pricePartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pricePartText_KeyPress);
            this.pricePartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // pricePartLabel
            // 
            this.pricePartLabel.AutoSize = true;
            this.pricePartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricePartLabel.Location = new System.Drawing.Point(32, 254);
            this.pricePartLabel.Name = "pricePartLabel";
            this.pricePartLabel.Size = new System.Drawing.Size(68, 15);
            this.pricePartLabel.TabIndex = 63;
            this.pricePartLabel.Text = "Price / Cost";
            // 
            // invPartText
            // 
            this.invPartText.BackColor = System.Drawing.Color.Salmon;
            this.invPartText.Location = new System.Drawing.Point(114, 228);
            this.invPartText.Name = "invPartText";
            this.invPartText.Size = new System.Drawing.Size(100, 20);
            this.invPartText.TabIndex = 62;
            this.invPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.invPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invPartText_KeyPress);
            this.invPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // invPartLabel
            // 
            this.invPartLabel.AutoSize = true;
            this.invPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invPartLabel.Location = new System.Drawing.Point(45, 228);
            this.invPartLabel.Name = "invPartLabel";
            this.invPartLabel.Size = new System.Drawing.Size(55, 15);
            this.invPartLabel.TabIndex = 61;
            this.invPartLabel.Text = "Inventory";
            // 
            // namePartText
            // 
            this.namePartText.BackColor = System.Drawing.Color.Salmon;
            this.namePartText.Location = new System.Drawing.Point(114, 202);
            this.namePartText.Name = "namePartText";
            this.namePartText.Size = new System.Drawing.Size(100, 20);
            this.namePartText.TabIndex = 60;
            this.namePartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.namePartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // partNameLabel
            // 
            this.partNameLabel.AutoSize = true;
            this.partNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNameLabel.Location = new System.Drawing.Point(59, 202);
            this.partNameLabel.Name = "partNameLabel";
            this.partNameLabel.Size = new System.Drawing.Size(41, 15);
            this.partNameLabel.TabIndex = 59;
            this.partNameLabel.Text = "Name";
            // 
            // idLabelAdd
            // 
            this.idLabelAdd.AutoSize = true;
            this.idLabelAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabelAdd.Location = new System.Drawing.Point(81, 175);
            this.idLabelAdd.Name = "idLabelAdd";
            this.idLabelAdd.Size = new System.Drawing.Size(19, 15);
            this.idLabelAdd.TabIndex = 57;
            this.idLabelAdd.Text = "ID";
            // 
            // saveProdAddButton
            // 
            this.saveProdAddButton.Location = new System.Drawing.Point(598, 449);
            this.saveProdAddButton.Name = "saveProdAddButton";
            this.saveProdAddButton.Size = new System.Drawing.Size(50, 24);
            this.saveProdAddButton.TabIndex = 56;
            this.saveProdAddButton.Text = "Save";
            this.saveProdAddButton.UseVisualStyleBackColor = true;
            this.saveProdAddButton.Click += new System.EventHandler(this.saveProdAddButton_Click);
            // 
            // cancProdAdd
            // 
            this.cancProdAdd.Location = new System.Drawing.Point(654, 449);
            this.cancProdAdd.Name = "cancProdAdd";
            this.cancProdAdd.Size = new System.Drawing.Size(50, 24);
            this.cancProdAdd.TabIndex = 55;
            this.cancProdAdd.Text = "Cancel";
            this.cancProdAdd.UseVisualStyleBackColor = true;
            this.cancProdAdd.Click += new System.EventHandler(this.cancProdAdd_Click);
            // 
            // delPartProdButton
            // 
            this.delPartProdButton.Location = new System.Drawing.Point(654, 396);
            this.delPartProdButton.Name = "delPartProdButton";
            this.delPartProdButton.Size = new System.Drawing.Size(50, 24);
            this.delPartProdButton.TabIndex = 54;
            this.delPartProdButton.Text = "Delete";
            this.delPartProdButton.UseVisualStyleBackColor = true;
            this.delPartProdButton.Click += new System.EventHandler(this.delPartProdButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Parts Associated with this Product";
            // 
            // addPartProdButton
            // 
            this.addPartProdButton.Location = new System.Drawing.Point(654, 211);
            this.addPartProdButton.Name = "addPartProdButton";
            this.addPartProdButton.Size = new System.Drawing.Size(50, 24);
            this.addPartProdButton.TabIndex = 52;
            this.addPartProdButton.Text = "Add";
            this.addPartProdButton.UseVisualStyleBackColor = true;
            this.addPartProdButton.Click += new System.EventHandler(this.addPartProdButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "All-candidate Parts";
            // 
            // searchPartsText
            // 
            this.searchPartsText.Location = new System.Drawing.Point(546, 43);
            this.searchPartsText.Name = "searchPartsText";
            this.searchPartsText.Size = new System.Drawing.Size(158, 20);
            this.searchPartsText.TabIndex = 48;
            // 
            // searchProdScButton
            // 
            this.searchProdScButton.Location = new System.Drawing.Point(486, 43);
            this.searchProdScButton.Name = "searchProdScButton";
            this.searchProdScButton.Size = new System.Drawing.Size(54, 20);
            this.searchProdScButton.TabIndex = 47;
            this.searchProdScButton.Text = "Search";
            this.searchProdScButton.UseVisualStyleBackColor = true;
            this.searchProdScButton.Click += new System.EventHandler(this.searchProdScButton_Click);
            // 
            // addProductLabel
            // 
            this.addProductLabel.AutoSize = true;
            this.addProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProductLabel.Location = new System.Drawing.Point(12, 9);
            this.addProductLabel.Name = "addProductLabel";
            this.addProductLabel.Size = new System.Drawing.Size(114, 20);
            this.addProductLabel.TabIndex = 46;
            this.addProductLabel.Text = "Modify Product";
            // 
            // idLabelText
            // 
            this.idLabelText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.idLabelText.Location = new System.Drawing.Point(114, 176);
            this.idLabelText.Name = "idLabelText";
            this.idLabelText.Size = new System.Drawing.Size(100, 20);
            this.idLabelText.TabIndex = 69;
            this.idLabelText.Text = "label3";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // prodPartsDataGrid
            // 
            this.prodPartsDataGrid.AllowUserToAddRows = false;
            this.prodPartsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.prodPartsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.prodPartsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.prodPartsDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.prodPartsDataGrid.Location = new System.Drawing.Point(304, 268);
            this.prodPartsDataGrid.MultiSelect = false;
            this.prodPartsDataGrid.Name = "prodPartsDataGrid";
            this.prodPartsDataGrid.RowHeadersVisible = false;
            this.prodPartsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prodPartsDataGrid.Size = new System.Drawing.Size(400, 122);
            this.prodPartsDataGrid.TabIndex = 71;
            // 
            // partsDataGrid
            // 
            this.partsDataGrid.AllowUserToAddRows = false;
            this.partsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.partsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.partsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.partsDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.partsDataGrid.Location = new System.Drawing.Point(304, 83);
            this.partsDataGrid.MultiSelect = false;
            this.partsDataGrid.Name = "partsDataGrid";
            this.partsDataGrid.RowHeadersVisible = false;
            this.partsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsDataGrid.Size = new System.Drawing.Size(400, 122);
            this.partsDataGrid.TabIndex = 70;
            // 
            // ModProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 485);
            this.Controls.Add(this.prodPartsDataGrid);
            this.Controls.Add(this.partsDataGrid);
            this.Controls.Add(this.idLabelText);
            this.Controls.Add(this.minPartText);
            this.Controls.Add(this.minPartLabel);
            this.Controls.Add(this.maxPartText);
            this.Controls.Add(this.maxPartLabel);
            this.Controls.Add(this.pricePartText);
            this.Controls.Add(this.pricePartLabel);
            this.Controls.Add(this.invPartText);
            this.Controls.Add(this.invPartLabel);
            this.Controls.Add(this.namePartText);
            this.Controls.Add(this.partNameLabel);
            this.Controls.Add(this.idLabelAdd);
            this.Controls.Add(this.saveProdAddButton);
            this.Controls.Add(this.cancProdAdd);
            this.Controls.Add(this.delPartProdButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addPartProdButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchPartsText);
            this.Controls.Add(this.searchProdScButton);
            this.Controls.Add(this.addProductLabel);
            this.Name = "ModProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.prodPartsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox minPartText;
        private System.Windows.Forms.Label minPartLabel;
        private System.Windows.Forms.TextBox maxPartText;
        private System.Windows.Forms.Label maxPartLabel;
        private System.Windows.Forms.TextBox pricePartText;
        private System.Windows.Forms.Label pricePartLabel;
        private System.Windows.Forms.TextBox invPartText;
        private System.Windows.Forms.Label invPartLabel;
        private System.Windows.Forms.TextBox namePartText;
        private System.Windows.Forms.Label partNameLabel;
        private System.Windows.Forms.Label idLabelAdd;
        private System.Windows.Forms.Button saveProdAddButton;
        private System.Windows.Forms.Button cancProdAdd;
        private System.Windows.Forms.Button delPartProdButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addPartProdButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchPartsText;
        private System.Windows.Forms.Button searchProdScButton;
        private System.Windows.Forms.Label addProductLabel;
        private System.Windows.Forms.Label idLabelText;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView prodPartsDataGrid;
        private System.Windows.Forms.DataGridView partsDataGrid;
    }
}