namespace InventorySystem_PeterWilliams
{
    partial class AddPart
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
            this.inHouseRadio = new System.Windows.Forms.RadioButton();
            this.addPartLabel = new System.Windows.Forms.Label();
            this.outsourcedRadio = new System.Windows.Forms.RadioButton();
            this.namePartText = new System.Windows.Forms.TextBox();
            this.partNameLabel = new System.Windows.Forms.Label();
            this.invPartText = new System.Windows.Forms.TextBox();
            this.invPartLabel = new System.Windows.Forms.Label();
            this.pricePartText = new System.Windows.Forms.TextBox();
            this.pricePartLabel = new System.Windows.Forms.Label();
            this.maxPartText = new System.Windows.Forms.TextBox();
            this.maxPartLabel = new System.Windows.Forms.Label();
            this.minPartText = new System.Windows.Forms.TextBox();
            this.minPartLabel = new System.Windows.Forms.Label();
            this.swingPartText = new System.Windows.Forms.TextBox();
            this.swingPartLabel = new System.Windows.Forms.Label();
            this.savePartButton = new System.Windows.Forms.Button();
            this.cancelPartButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // inHouseRadio
            // 
            this.inHouseRadio.AutoSize = true;
            this.inHouseRadio.Checked = true;
            this.inHouseRadio.Location = new System.Drawing.Point(66, 48);
            this.inHouseRadio.Name = "inHouseRadio";
            this.inHouseRadio.Size = new System.Drawing.Size(68, 17);
            this.inHouseRadio.TabIndex = 0;
            this.inHouseRadio.TabStop = true;
            this.inHouseRadio.Text = "In-House";
            this.inHouseRadio.UseVisualStyleBackColor = true;
            this.inHouseRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.inHouseRadio_MouseClick);
            // 
            // addPartLabel
            // 
            this.addPartLabel.AutoSize = true;
            this.addPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPartLabel.Location = new System.Drawing.Point(12, 9);
            this.addPartLabel.Name = "addPartLabel";
            this.addPartLabel.Size = new System.Drawing.Size(71, 20);
            this.addPartLabel.TabIndex = 1;
            this.addPartLabel.Text = "Add Part";
            // 
            // outsourcedRadio
            // 
            this.outsourcedRadio.AutoSize = true;
            this.outsourcedRadio.Location = new System.Drawing.Point(155, 48);
            this.outsourcedRadio.Name = "outsourcedRadio";
            this.outsourcedRadio.Size = new System.Drawing.Size(80, 17);
            this.outsourcedRadio.TabIndex = 2;
            this.outsourcedRadio.Text = "Outsourced";
            this.outsourcedRadio.UseVisualStyleBackColor = true;
            this.outsourcedRadio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.outsourcedRadio_MouseClick);
            // 
            // namePartText
            // 
            this.namePartText.BackColor = System.Drawing.Color.Salmon;
            this.namePartText.Cursor = System.Windows.Forms.Cursors.Default;
            this.namePartText.Location = new System.Drawing.Point(114, 87);
            this.namePartText.Name = "namePartText";
            this.namePartText.Size = new System.Drawing.Size(100, 20);
            this.namePartText.TabIndex = 6;
            this.namePartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.namePartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // partNameLabel
            // 
            this.partNameLabel.AutoSize = true;
            this.partNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNameLabel.Location = new System.Drawing.Point(59, 87);
            this.partNameLabel.Name = "partNameLabel";
            this.partNameLabel.Size = new System.Drawing.Size(41, 15);
            this.partNameLabel.TabIndex = 5;
            this.partNameLabel.Text = "Name";
            // 
            // invPartText
            // 
            this.invPartText.BackColor = System.Drawing.Color.Salmon;
            this.invPartText.Cursor = System.Windows.Forms.Cursors.Default;
            this.invPartText.Location = new System.Drawing.Point(114, 113);
            this.invPartText.Name = "invPartText";
            this.invPartText.Size = new System.Drawing.Size(100, 20);
            this.invPartText.TabIndex = 8;
            this.invPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.invPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerChecker_KeyPress);
            this.invPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // invPartLabel
            // 
            this.invPartLabel.AutoSize = true;
            this.invPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invPartLabel.Location = new System.Drawing.Point(45, 113);
            this.invPartLabel.Name = "invPartLabel";
            this.invPartLabel.Size = new System.Drawing.Size(55, 15);
            this.invPartLabel.TabIndex = 7;
            this.invPartLabel.Text = "Inventory";
            // 
            // pricePartText
            // 
            this.pricePartText.BackColor = System.Drawing.Color.Salmon;
            this.pricePartText.Cursor = System.Windows.Forms.Cursors.Default;
            this.pricePartText.Location = new System.Drawing.Point(114, 139);
            this.pricePartText.Name = "pricePartText";
            this.pricePartText.Size = new System.Drawing.Size(100, 20);
            this.pricePartText.TabIndex = 10;
            this.pricePartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.pricePartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DecimalChecker_KeyPress);
            this.pricePartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // pricePartLabel
            // 
            this.pricePartLabel.AutoSize = true;
            this.pricePartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricePartLabel.Location = new System.Drawing.Point(32, 139);
            this.pricePartLabel.Name = "pricePartLabel";
            this.pricePartLabel.Size = new System.Drawing.Size(68, 15);
            this.pricePartLabel.TabIndex = 9;
            this.pricePartLabel.Text = "Price / Cost";
            // 
            // maxPartText
            // 
            this.maxPartText.BackColor = System.Drawing.Color.Salmon;
            this.maxPartText.Cursor = System.Windows.Forms.Cursors.Default;
            this.maxPartText.Location = new System.Drawing.Point(114, 165);
            this.maxPartText.Name = "maxPartText";
            this.maxPartText.Size = new System.Drawing.Size(30, 20);
            this.maxPartText.TabIndex = 12;
            this.maxPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.maxPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerChecker_KeyPress);
            this.maxPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // maxPartLabel
            // 
            this.maxPartLabel.AutoSize = true;
            this.maxPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxPartLabel.Location = new System.Drawing.Point(69, 165);
            this.maxPartLabel.Name = "maxPartLabel";
            this.maxPartLabel.Size = new System.Drawing.Size(31, 15);
            this.maxPartLabel.TabIndex = 11;
            this.maxPartLabel.Text = "Max";
            // 
            // minPartText
            // 
            this.minPartText.BackColor = System.Drawing.Color.Salmon;
            this.minPartText.Cursor = System.Windows.Forms.Cursors.Default;
            this.minPartText.Location = new System.Drawing.Point(184, 165);
            this.minPartText.Name = "minPartText";
            this.minPartText.Size = new System.Drawing.Size(30, 20);
            this.minPartText.TabIndex = 14;
            this.minPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.minPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerChecker_KeyPress);
            this.minPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // minPartLabel
            // 
            this.minPartLabel.AutoSize = true;
            this.minPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minPartLabel.Location = new System.Drawing.Point(152, 166);
            this.minPartLabel.Name = "minPartLabel";
            this.minPartLabel.Size = new System.Drawing.Size(28, 15);
            this.minPartLabel.TabIndex = 13;
            this.minPartLabel.Text = "Min";
            // 
            // swingPartText
            // 
            this.swingPartText.BackColor = System.Drawing.Color.Salmon;
            this.swingPartText.Cursor = System.Windows.Forms.Cursors.Default;
            this.swingPartText.Location = new System.Drawing.Point(114, 191);
            this.swingPartText.Name = "swingPartText";
            this.swingPartText.Size = new System.Drawing.Size(100, 20);
            this.swingPartText.TabIndex = 16;
            this.swingPartText.TextChanged += new System.EventHandler(this.namePartText_TextChanged);
            this.swingPartText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SwingChecker_KeyPress);
            this.swingPartText.MouseHover += new System.EventHandler(this.Tooltip_MouseHover);
            // 
            // swingPartLabel
            // 
            this.swingPartLabel.AutoSize = true;
            this.swingPartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swingPartLabel.Location = new System.Drawing.Point(30, 192);
            this.swingPartLabel.Name = "swingPartLabel";
            this.swingPartLabel.Size = new System.Drawing.Size(70, 15);
            this.swingPartLabel.TabIndex = 15;
            this.swingPartLabel.Text = "Machine ID";
            // 
            // savePartButton
            // 
            this.savePartButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.savePartButton.Location = new System.Drawing.Point(108, 232);
            this.savePartButton.Name = "savePartButton";
            this.savePartButton.Size = new System.Drawing.Size(58, 25);
            this.savePartButton.TabIndex = 17;
            this.savePartButton.Text = "Save";
            this.savePartButton.UseVisualStyleBackColor = false;
            this.savePartButton.Click += new System.EventHandler(this.savePartButton_Click);
            // 
            // cancelPartButton
            // 
            this.cancelPartButton.Location = new System.Drawing.Point(177, 232);
            this.cancelPartButton.Name = "cancelPartButton";
            this.cancelPartButton.Size = new System.Drawing.Size(58, 25);
            this.cancelPartButton.TabIndex = 18;
            this.cancelPartButton.Text = "Cancel";
            this.cancelPartButton.UseVisualStyleBackColor = true;
            this.cancelPartButton.Click += new System.EventHandler(this.cancelPartButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 280);
            this.Controls.Add(this.cancelPartButton);
            this.Controls.Add(this.savePartButton);
            this.Controls.Add(this.swingPartText);
            this.Controls.Add(this.swingPartLabel);
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
            this.Controls.Add(this.outsourcedRadio);
            this.Controls.Add(this.addPartLabel);
            this.Controls.Add(this.inHouseRadio);
            this.Name = "AddPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Part";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton inHouseRadio;
        private System.Windows.Forms.Label addPartLabel;
        private System.Windows.Forms.RadioButton outsourcedRadio;
        private System.Windows.Forms.TextBox namePartText;
        private System.Windows.Forms.Label partNameLabel;
        private System.Windows.Forms.TextBox invPartText;
        private System.Windows.Forms.Label invPartLabel;
        private System.Windows.Forms.TextBox pricePartText;
        private System.Windows.Forms.Label pricePartLabel;
        private System.Windows.Forms.TextBox maxPartText;
        private System.Windows.Forms.Label maxPartLabel;
        private System.Windows.Forms.TextBox minPartText;
        private System.Windows.Forms.Label minPartLabel;
        private System.Windows.Forms.TextBox swingPartText;
        private System.Windows.Forms.Label swingPartLabel;
        private System.Windows.Forms.Button savePartButton;
        private System.Windows.Forms.Button cancelPartButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}