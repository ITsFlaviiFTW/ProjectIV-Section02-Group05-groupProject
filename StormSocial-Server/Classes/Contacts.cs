using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace StormSocial_Server.Classes
{
    public class Contacts
    {
        private List <string> contacts;

        public Contacts(string email)
        {
            this.contacts = populateContactsFromFile(email);
            
        }
        public List<string> getContacts() { return this.contacts; }
        public void addNewContact(string email)
        {
            this.contacts.Add(email);
            //this.writeContactToFile(email);
        }


        public void writeContactToFile(string emailOfUser)
        {
            string fileName = string.Concat(emailOfUser, "-contacts.txt");

            if(File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    for (int i = 0; i < this.contacts.Count; i++)
                    {
                        sw.WriteLine(this.contacts[i]);
                    }
                }
            }
            else
            {
                using (FileStream newFile = File.Create(fileName)) ; //create a unique textfile for 
                writeContactToFile(emailOfUser);
            }            
        }
        public List<String> populateContactsFromFile(string email)
        {
            List<String> con = new List<String>();
            string fileName = string.Concat(email, "-contacts.txt");

            if(File.Exists(fileName))
            {
                using(StreamReader read = new StreamReader(fileName))
                {
                    string line;
                    int i = 0;
                    while ((line = read.ReadLine()) != null)
                    {
                        con.Add(line);
                    }
                }
            }
            else
            {
                using (FileStream newFile = File.Create(fileName)); //Create new file

            }
            return con;
        }
    }
}
