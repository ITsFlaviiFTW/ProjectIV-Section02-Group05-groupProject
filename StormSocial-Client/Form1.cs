using StormSocial_Server.Classes;

namespace StormSocial_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)
        {



        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string LoginEmail = EmailLoginText.Text;
            string LoginPass = PasswordLoginText.Text;
            Login login = new Login(LoginEmail, LoginPass);

            if(login.userLogIn(LoginEmail, LoginPass) == true ) {
                Form2 Form2 = new Form2();
                Form2.Show();
                this.Hide();
            }
            else
            {
                SystemLabel.Text = "Invalid login credentials. Please try again.";
            }

        }

        private void SloganPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CreateAccountFN = FNText.Text;
            string CreateAccountLN = LNText.Text;
            string CreateAccountEmail = EmailText.Text;
            string CreateAccountPass = PassText.Text;
            string PassConfirm = PassText.Text;
            Login login = new Login(CreateAccountEmail, CreateAccountPass);

            if (login.signUp(CreateAccountFN, CreateAccountLN, CreateAccountEmail, CreateAccountPass, PassConfirm) == true)
            {
                SystemLabel.Text = "Account created.";
            }
            else
            {
                SystemLabel.Text = "Email already exists or passwords don't match. Please try again.";
            }
        }
    }
}