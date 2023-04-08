using System;
using System.Collections.Generic;
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
    internal class Chat
    {
        private Profile sender;
        private Profile recipient;
        private List <Message> message;

        public Chat(Profile sender, Profile recipient)
        {
            this.sender = sender;
            this.recipient = recipient;
            message = new List <Message>();
        }

        public Profile getSender() { return this.sender; }
        public Profile getRecipient() { return this.recipient; }
        public void setSender(Profile sender) { this.sender = sender;}
        public void setRecipient(Profile recipient) {  this.recipient = recipient;}

        public void addMsg(string sender, string recipient, string msg)
        {
            Message m = new Message(); 
            m.setMessage(msg);
            m.setSender(sender); 
            m.setRecipient(recipient);

            message.Add(m);

        }
        public void writeChatToFile()
        {
            //int numOfChats = getNumOfChats();
            string fileName = string.Concat(this.getSender().GetLogin().getEmail(), "-data-", numOfChats, ".txt");

            if(File.Exists(fileName))
            {
                using(StreamWriter writer= new StreamWriter(fileName))
                {
                    writer.WriteLine(this.getSender().getFirstName() + ";" + this.getRecipient().getFirstName());
                    for(int i = 0; i < message.Count; i++)
                    {
                        writer.WriteLine(message[i].createStringToWriteToFile());
                    }
                }
            }
            else
            {

            }
        }
        //public int getNumOfChats()
        //{
        //    string fileName = string.Concat(this.getSender().GetLogin().getEmail(), "-numOfChats.txt"); //filename will be <example@gmail.com-numOfChats.txt>
        //    int numOfChats;

        //    if (File.Exists(fileName)) //check to see if the file exists
        //    {
        //        string line;
                
        //        using(StreamReader read = new StreamReader(fileName))
        //        {
        //            line = read.ReadLine(); // read the only line of the file
        //            numOfChats = int.Parse(line); //covert contents of the line to an int
        //            //numOfChats++; //increase to reprsent the new chat being added
        //            read.Close();
        //        }
        //        using(StreamWriter write = new StreamWriter(fileName))
        //        {
        //            write.WriteLine(numOfChats);
        //        }
        //    }
        //    else
        //    {
        //        using(FileStream stream = File.Create(fileName)) ; // create file if it does'nt exist
        //        using(StreamWriter write = new StreamWriter(fileName))
        //        {
        //            write.WriteLine("1"); //because the file does not exist this will be first chat so we can set it to 1
        //            write.Close();
        //        }
                
        //        return 1;
        //    }
        //    return numOfChats;
        //}
    }
}
/*
 * each user will have a txt file for each conversation
 * this will just be named email-chat1, email-chat2.....
 */