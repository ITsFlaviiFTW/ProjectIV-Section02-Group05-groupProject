using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StormSocial_Server.Classes
{
    internal class Message
    {
        private string sender;
        private string recipient;
        private string message;

        public void setSender(string sender) { this.sender = sender; }
        public void setRecipient(string recipient) { this.recipient = recipient; }
        public void setMessage(string message) { this.message = message; }

        public string getSender() { return this.sender; }   
        public string getRecipient() { return this.recipient; }
        public string getMessage() { return this.message; }

        public string createStringToWriteToFile()
        {
            return string.Concat(this.getSender(), ";", this.getRecipient(), ";", this.getMessage());
        }
    }
    public class Chat
    {
        private string sender;
        private string recipient;
        private string fileName;

        public Chat(string sender, string recipient)
        {
            this.sender = sender;
            this.recipient = recipient;
            this.fileName = string.Concat(this.getSender(), "-", this.getRecipient(), "-", "chats.txt");
        }

        public string getSender() { return this.sender; }
        public string getRecipient() { return this.recipient; }
        public void setSender(string sender) { this.sender = sender;}
        public void setRecipient(string recipient) {  this.recipient = recipient;}
        public string getFile() { return this.fileName; }

        public void addMessageTochat(string msg)
        {
            if(File.Exists(this.getFile()))
            {
                using (StreamWriter writer = new StreamWriter(this.getFile(), true))
                {
                    writer.WriteLine(msg);
                    writer.Close();
                }
            }
            else
            {
                using (FileStream f = File.Create(this.getFile())) ;
                using (StreamWriter writer = new StreamWriter(this.getFile(), true))
                {
                    writer.WriteLine(string.Concat(this.getSender(), ":", this.getRecipient(), ":"));
                    writer.WriteLine(msg);
                    writer.Close();
                }

            }
        }
        public string fillTextBox()
        {
            if (File.Exists(this.getFile()))
            {
                return File.ReadAllText(this.getFile());
            }
            return "";
        }
        
    }
}
/*
 * each user will have a txt file for each conversation
 * this will just be named email-chat1, email-chat2.....
 */