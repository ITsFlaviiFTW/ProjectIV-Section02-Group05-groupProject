using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormSocial_Server.Classes
{
    internal class Message
    {
        private string sender;
        private string message;

        public void setMsg(string msg) { this.message = msg; }
        public void setSender(string sender) { this.sender = sender;}
    }
    internal class Chat
    {
        private Profile sender;
        private Profile recipient;
        private Message[] message;

        public Profile getSender() { return this.sender; }
        public Profile getRecipient() { return this.recipient; }
        public void setSender(Profile sender) { this.sender = sender;}
        public void setRecipient(Profile recipient) {  this.recipient = recipient;}

        public void writeChatToFile()
        {
            //Path.di
        }
        public int getNumOfChats()
        {
            string fileName = string.Concat(this.getSender().GetLogin().getEmail(), "-numOfChats.txt"); //filename will be <example@gmail.com-numOfChats.txt>
            int numOfChats;

            if (File.Exists(fileName)) //check to see if the file exists
            {
                string line;
                
                using(StreamReader read = new StreamReader(fileName))
                {
                    line = read.ReadLine(); // read the only line of the file
                    numOfChats = int.Parse(line); //covert contents of the line to an int
                    numOfChats++; //increase to reprsent the new chat being added
                    read.Close();
                }
                using(StreamWriter write = new StreamWriter(fileName))
                {
                    write.WriteLine(numOfChats);
                }
            }
            else
            {
                using (FileStream stream = File.Create(fileName)) ; // create file if it does'nt exist
                using(StreamWriter write = new StreamWriter(fileName))
                {
                    write.WriteLine("0");
                    write.Close();
                }
                
                return 0;
            }
            return numOfChats;
        }
    }
}
/*
 * each user will have a txt file for each conversation
 * this will just be named email-chat1, email-chat2.....
 * 
 */