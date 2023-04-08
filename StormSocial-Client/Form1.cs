using SimpleClientServer;
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

            // Retrieve the client's socket address
            string clientSocketAddress = Program.clientSocket.RemoteEndPoint.ToString();

            // Include the client's socket address when creating the Login object
            Login login = new Login(LoginEmail, LoginPass, clientSocketAddress);

            if (login.userLogIn(LoginEmail, LoginPass) == true)
            {
                // Add the login object to the loggedInClients dictionary
                Program.loggedInClients.Add(clientSocketAddress, login);
                string email = EmailLoginText.Text;
                var emailPacket = new DataPacket.DataPacketStruct(1, "text/plain", Program.loggedInClients[Program.clientSocket.RemoteEndPoint.ToString()].getEmail(), 0);
                
                var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(emailPacket);
                Form3 Form3 = new Form3();
                Form3.Show();
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