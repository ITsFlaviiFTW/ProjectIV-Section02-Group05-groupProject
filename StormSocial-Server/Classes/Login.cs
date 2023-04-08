 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElasticEmail.Api;
using ElasticEmail.Client;
using ElasticEmail.Model;



//Elastic Email API key: 4B765D18F45A2A65A6448E3BDF79721C97201EA62A07DD3134E7615A3D453FB02E995AF31D2CD703B48D4DE10FC6B7C2

namespace StormSocial_Server.Classes
{
    public class Login
    {
        private string email;
        private string password;
        private string clientSocketAddress;

        public bool checkForExistingEmailInFile(string email)
        {
            string fileName = "profiles.txt";

            if(File.Exists(fileName)) //check to see if file exists
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) // read lines in untill end of file is reached
                    {
                        string[] seperate = line.Split(';'); //splits the line into array on the ';'
                        if (seperate[0] == email) //email will be at index 0 cuz it was the first item in the line
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        public Login()
        {
            this.email = string.Empty;
            this.password = string.Empty;
        }
        public Login(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public Login(string email, string password, string clientSocketAddress)
        {
            this.email = email;
            this.password = password;
            this.clientSocketAddress = clientSocketAddress;
        }

        //Setters and getters
        public string getEmail() { return this.email; }
        public string getPassword() { return this.password; }
        public void setEmail(string email) { this.email = email; }
        public void setPassword(string password) { this.password = password; }
        public string getClientSocketAddress() { return this.clientSocketAddress; }
        public void setClientSocketAddress(string clientSocketAddress) { this.clientSocketAddress = clientSocketAddress; }


        public int randomCode()
        {
            //generate random 6 digit code
            Random rand = new Random();
            int verification = rand.Next(100000, 999999);
            return verification;
        }

        public bool userLogIn(string email, string password)
        {
            //See checkForExistingEmailInFile() function for documentation
            string fileName = "profiles.txt";

            if (File.Exists(fileName)) 
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] seperate = line.Split(';');
                        if (seperate[0] == email && seperate[1] == password)
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        //this will be called from the sign up form and will pass info from the textboxes on the form
        public bool signUp(string firstName, string lastName, string email, string password, string passConfirm)
        {
            
            if(password == passConfirm)
            {
                if(!checkForExistingEmailInFile(email)) //check to see if email is already in the system
                {
                    //since passwords match and the email is not taken we can add to the system
                    this.setEmail(email);
                    this.setPassword(password);
                    Profile profile = new Profile(firstName, lastName, this);
                    profile.saveProfileToFile();
                    
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false; // if passwords do not match do not create account
            }
            return true;
        }

        public void sendEmail()
        {
            //This just all email API shit
            const string API_KEY = "4B765D18F45A2A65A6448E3BDF79721C97201EA62A07DD3134E7615A3D453FB02E995AF31D2CD703B48D4DE10FC6B7C2";

            Configuration config = new Configuration();
            config.ApiKey.Add("X-ElasticEmail-ApiKey", API_KEY);

            var apiInstance = new EmailsApi(config);

            var to = new List<string>();
            to.Add(this.getEmail());
            var recipients = new TransactionalRecipient(to: to);
            EmailTransactionalMessageData emailData = new EmailTransactionalMessageData(recipients: recipients);
            emailData.Content = new EmailContent();
            emailData.Content.Body = new List<BodyPart>();
            BodyPart htmlBodyPart = new BodyPart();
            htmlBodyPart.ContentType = BodyContentType.HTML;
            htmlBodyPart.Charset = "utf-8";
            htmlBodyPart.Content = "<p1>Verification Code: " + randomCode().ToString() + "<p1>";
            BodyPart plainTextBodyPart = new BodyPart();
            plainTextBodyPart.ContentType = BodyContentType.PlainText;
            plainTextBodyPart.Charset = "utf-8";
            plainTextBodyPart.Content = "Verification Code";
            emailData.Content.Body.Add(htmlBodyPart);
            emailData.Content.Body.Add(plainTextBodyPart);
            emailData.Content.From = "stormsocialverify@gmail.com";
            emailData.Content.Subject = "Verification Code";

            try
            {
                apiInstance.EmailsTransactionalPost(emailData);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception when calling EmailsAPI.EmailsTransactionalPost: " + e.Message);
                Console.WriteLine(" Status Code: " + e.ErrorCode);
                Console.WriteLine(e.StackTrace);
                throw;
            }

        }

    }
}
