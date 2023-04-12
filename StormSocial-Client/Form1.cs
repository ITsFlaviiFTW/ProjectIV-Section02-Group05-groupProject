using SimpleClientServer;
using StormSocial_Server.Classes;
using System.Net.Sockets;
using System.Text;

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

                // Arrange
                var emailPacket = new DataPacket.DataPacketStruct
                {
                    sequenceNumber = 1,
                    dataType = "text/plain",
                    email = Program.loggedInClients[Program.clientSocket.RemoteEndPoint.ToString()].getEmail()
                };


                // Serialize the emailPacket to JSON
                var json = DataPacket.PacketManipulation.SerializeDataPacketStruct(emailPacket);

                // Send the serialized emailPacket to the server
                byte[] data = Encoding.ASCII.GetBytes(json);
                Program.clientSocket.Send(data);

                //_ = Task.Run(() => HandleClientAsync(Program.clientSocket));

                Form2 Form2 = new Form2();
                Form2.Show();
                this.Hide();
            }
            else
            {
                SystemLabel.Text = "Invalid login credentials. Please try again.";
            }
        }

        //static async Task HandleClientAsync(Socket clientSocket)
        //{
        //    bool moreFiles = true;
        //    while(moreFiles)
        //    {
        //        var buffer = new byte[DataPacket.DataPacketTcpSocket.MaxPacketSize];
        //        int bytesRead = await Program.clientSocket.ReceiveAsync(buffer, SocketFlags.None);
        //        StringBuilder receivedDataBuilder = new StringBuilder();

        //        string partialReceivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        //        receivedDataBuilder.Append(partialReceivedData);

        //        string receivedData = receivedDataBuilder.ToString();
        //        bool isLastPacket = false;
        //        string currentDataType = "";

        //        receivedDataBuilder.Clear();

        //        try
        //        {
        //            var packet = DataPacket.PacketManipulation.DeserializeDataPacketStruct(receivedData);
        //            isLastPacket = packet.isLastPacket;
        //            currentDataType = packet.GetDataType();

        //            if (currentDataType == "profile_data")
        //            {
        //                File.WriteAllText($"profiles.txt", packet.GetPacketData());
        //            }
        //            if (currentDataType == "chat_history")
        //            {
        //                string content = packet.GetPacketData();
        //                string[] splitContent = content.Split(':');
        //                string fileName = string.Concat(splitContent[0], "-", splitContent[1], "-chats.txt");
        //                File.WriteAllText($"{fileName}", packet.GetPacketData());
        //            }
        //            if (currentDataType == "contact_file")
        //            {
        //                File.WriteAllText($"{packet.GetEmail()}-contacts.txt", packet.GetPacketData());
        //                moreFiles = true;
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }
            
        //}

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