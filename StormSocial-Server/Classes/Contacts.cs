using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace StormSocial_Server.Classes
{
    internal class Contacts
    {
        private List <string> contacts;

        public void addNewContact(string email)
        {
            this.contacts.Add(email);
        }


        public void writeContactToFile(string emailOfUser)
        {
            string fileName = string.Concat(emailOfUser, "-contacts.txt");

            if(File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
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
        public void populateContactsFromFile(string email)
        {
            string fileName = string.Concat(email, "-contacts.txt");

            if(File.Exists(fileName))
            {
                using(StreamReader read = new StreamReader(fileName))
                {
                    string line;
                    int i = 0;
                    while ((line = read.ReadLine()) != null)
                    {
                        this.contacts[i] = line;
                        i++;
                    }
                }
            }
            else
            {
                using (FileStream newFile = File.Create(fileName)) ;//Create new file

            }
        }
    }
}
