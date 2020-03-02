namespace Scheduler_PeterWilliams
{
    partial class EditAppointment
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
            this.titleLab = new System.Windows.Forms.Label();
            this.SaveButt = new System.Windows.Forms.Button();
            this.CancButt = new System.Windows.Forms.Button();
            this.custBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.locBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLab
            // 
            this.titleLab.AutoSize = true;
            this.titleLab.Font = new System.Drawing.Font("Garamond", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLab.Location = new System.Drawing.Point(24, 26);
            this.titleLab.Name = "titleLab";
            this.titleLab.Size = new System.Drawing.Size(201, 27);
            this.titleLab.TabIndex = 7;
            this.titleLab.Text = "New Appointment";
            // 
            // SaveButt
            // 
            this.SaveButt.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButt.Location = new System.Drawing.Point(350, 862);
            this.SaveButt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveButt.Name = "SaveButt";
            this.SaveButt.Size = new System.Drawing.Size(94, 46);
            this.SaveButt.TabIndex = 34;
            this.SaveButt.Text = "Save";
            this.SaveButt.UseVisualStyleBackColor = true;
            this.SaveButt.Click += new System.EventHandler(this.SaveButt_Click);
            // 
            // CancButt
            // 
            this.CancButt.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancButt.Location = new System.Drawing.Point(249, 862);
            this.CancButt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancButt.Name = "CancButt";
            this.CancButt.Size = new System.Drawing.Size(94, 46);
            this.CancButt.TabIndex = 33;
            this.CancButt.Text = "Cancel";
            this.CancButt.UseVisualStyleBackColor = true;
            this.CancButt.Click += new System.EventHandler(this.CancButt_Click);
            // 
            // custBox
            // 
            this.custBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.custBox.Font = new System.Drawing.Font("Garamond", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custBox.FormattingEnabled = true;
            this.custBox.Location = new System.Drawing.Point(196, 320);
            this.custBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.custBox.Name = "custBox";
            this.custBox.Size = new System.Drawing.Size(248, 24);
            this.custBox.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Start:";
            // 
            // titleBox
            // 
            this.titleBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBox.Location = new System.Drawing.Point(196, 109);
            this.titleBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(248, 25);
            this.titleBox.TabIndex = 21;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(26, 109);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(42, 18);
            this.titleLabel.TabIndex = 20;
            this.titleLabel.Text = "Title:";
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(197, 462);
            this.startDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(129, 26);
            this.startDate.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Customer:";
            // 
            // startTime
            // 
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTime.Location = new System.Drawing.Point(333, 462);
            this.startTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startTime.Name = "startTime";
            this.startTime.ShowUpDown = true;
            this.startTime.Size = new System.Drawing.Size(112, 26);
            this.startTime.TabIndex = 37;
            // 
            // endTime
            // 
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTime.Location = new System.Drawing.Point(333, 518);
            this.endTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endTime.Name = "endTime";
            this.endTime.ShowUpDown = true;
            this.endTime.Size = new System.Drawing.Size(112, 26);
            this.endTime.TabIndex = 40;
            // 
            // endDate
            // 
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(197, 518);
            this.endDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(129, 26);
            this.endDate.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 518);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "End:";
            // 
            // typeBox
            // 
            this.typeBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeBox.Location = new System.Drawing.Point(196, 184);
            this.typeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(248, 25);
            this.typeBox.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Type:";
            // 
            // locBox
            // 
            this.locBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locBox.Location = new System.Drawing.Point(196, 392);
            this.locBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.locBox.Name = "locBox";
            this.locBox.Size = new System.Drawing.Size(248, 25);
            this.locBox.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Location:";
            // 
            // contBox
            // 
            this.contBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contBox.Location = new System.Drawing.Point(196, 251);
            this.contBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contBox.Name = "contBox";
            this.contBox.Size = new System.Drawing.Size(248, 25);
            this.contBox.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = "Contact:";
            // 
            // descBox
            // 
            this.descBox.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descBox.Location = new System.Drawing.Point(30, 629);
            this.descBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(415, 206);
            this.descBox.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Description:";
            // 
            // EditAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 941);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.contBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.locBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.SaveButt);
            this.Controls.Add(this.CancButt);
            this.Controls.Add(this.custBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleLab);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EditAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLab;
        private System.Windows.Forms.Button SaveButt;
        private System.Windows.Forms.Button CancButt;
        private System.Windows.Forms.ComboBox custBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox locBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Label label7;
    }
}