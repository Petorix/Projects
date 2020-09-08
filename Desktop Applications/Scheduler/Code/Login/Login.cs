//REQUIREMENT F:
//The requirement can be found inside the 'CheckLogin' function

using System;
using System.Windows.Forms;
using System.Globalization;

namespace Scheduler_PeterWilliams
{
    public partial class Login : Form
    {
        private const string ACCEPTABLE = "test";
        private string currentLang = "";

        public bool Success { get; set; }
        public string User { get; set; }

        public Login()
        {
            InitializeComponent();
            Success = false;

            AdjustLanguage();
        }

        private void AdjustLanguage()
        {
            //This is assuming we want to know the current region
            currentLang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            //This is assuming we want to know the current keyboard selected
            //string currentLang = InputLanguage.CurrentInputLanguage.Culture.TwoLetterISOLanguageName;

            switch (currentLang)
            {
                case "en": //English
                    greetingLabel.Text = "Welcome! Please log in.";
                    usrLab.Text = "Username:";
                    passLabel.Text = "Password:";
                    break;
                case "pt": //Portuguese
                    greetingLabel.Text = "Bem-vindo!  Por favor faça o login.";
                    usrLab.Text = "Nome de Usuário:";
                    passLabel.Text = "Senha:";
                    break;
                default:
                    break;
            }
        }

        private void PassTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckLogin();
            }
        }

        private void LoginButt_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void CheckLogin ()
        {
            try
            {
                if (!(usernameText.Text == passwordText.Text) || !(usernameText.Text == ACCEPTABLE))
                {
                    switch (currentLang)
                    {
                        case "en": //English
                            throw new Exception("The username and password did not match.");
                        case "pt": //Portuguese
                            throw new Exception("O nome de usuário e a senha não coincidem.");
                        default:
                            throw new Exception("Login Error - Username and Password do not match.  Cannot determine langauge."); ;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Success = true;
            User = usernameText.Text;
            Close();
        }
    }
}
