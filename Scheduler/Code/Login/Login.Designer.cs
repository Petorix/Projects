namespace Scheduler_PeterWilliams
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usernameText = new System.Windows.Forms.TextBox();
            this.usrLab = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.loginButt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            resources.ApplyResources(this.usernameText, "usernameText");
            this.usernameText.Name = "usernameText";
            // 
            // usrLab
            // 
            resources.ApplyResources(this.usrLab, "usrLab");
            this.usrLab.Name = "usrLab";
            // 
            // passLabel
            // 
            resources.ApplyResources(this.passLabel, "passLabel");
            this.passLabel.Name = "passLabel";
            // 
            // passwordText
            // 
            resources.ApplyResources(this.passwordText, "passwordText");
            this.passwordText.Name = "passwordText";
            this.passwordText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PassTextBox_KeyUp);
            // 
            // greetingLabel
            // 
            resources.ApplyResources(this.greetingLabel, "greetingLabel");
            this.greetingLabel.Name = "greetingLabel";
            // 
            // loginButt
            // 
            resources.ApplyResources(this.loginButt, "loginButt");
            this.loginButt.Name = "loginButt";
            this.loginButt.UseVisualStyleBackColor = true;
            this.loginButt.Click += new System.EventHandler(this.LoginButt_Click);
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginButt);
            this.Controls.Add(this.greetingLabel);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usrLab);
            this.Controls.Add(this.usernameText);
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label usrLab;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label greetingLabel;
        private System.Windows.Forms.Button loginButt;
    }
}