using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StormSocial_Server.Classes
{
    public class Profile
    {
        private string firstName;
        private string lastName;
        private Login log_in;
        private Contacts contacts;

        /******************\/CONSTRUCTORS\/******************************************/
        public Profile(string firstName, string lastName, Login log_in)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.log_in = log_in;
            //this.setContacts();
        }
        public Profile()
        {
            this.log_in.setEmail(string.Empty);
            this.log_in.setPassword(string.Empty);
            this.firstName = string.Empty;
            this.lastName = string.Empty;
        }
        public Profile(string email)
        {
            string fileName = "profiles.txt";

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)  // read lines in untill end of file is reached
                    {
                        string[] seperate = line.Split(';');    //splits the line into array on the ';'
                        if (seperate[0] == email)               //email will be at index 0 cuz it was the first item in the line
                        {
                            Login l = new Login();
                            l.setEmail(email);
                            l.setPassword(seperate[1]);         //email[0] password[1] firstName[2] lastName[3] 
                            this.setLogin(l);
                            this.setLastName(seperate[2]);
                            this.setLastName(seperate[3]);
                            this.loadContacts(email);

                            break;
                        }
                    }
                }
            }
        }
        /******************^CONSTRUCTORS^******************************************/

        /***********SETTERS AND GETTERS******************************************/
        public void setFirstName(string firstName) { this.firstName = firstName; }
        public void setLastName(string lastName) { this.lastName = lastName; }
        public void setLogin(Login login) { this.log_in = login; }
        public string getFirstName() { return this.firstName; }
        public string getLastName() { return this.lastName; }
        public Login GetLogin() { return this.log_in; }
        public Contacts GetContacts() { return this.contacts; }
        public void setContacts(Contacts c) { this.contacts = c; }
        /***********SETTERS AND GETTERS******************************************/

        public void saveProfileToFile()
        {
            string fileName = "profiles.txt";

            if(File.Exists(fileName))
            {
                using(StreamWriter fout = new StreamWriter(fileName, true)) //append to the file
                {
                    fout.WriteLine(this.GetLogin().getEmail() + ";" + this.GetLogin().getPassword() + ";" + this.getFirstName() + ";" + this.getLastName() + ";"); //wirte all the profiel info
                }
            }
            else
            {
                using (FileStream stream = File.Create(fileName)); //create new file if one does not exist
                saveProfileToFile(); // re-call the function to save the info
            }
        }
        private void loadContacts(string email)
        {
            Contacts c = new Contacts(email);
            this.setContacts(c);
        }
    }
}
