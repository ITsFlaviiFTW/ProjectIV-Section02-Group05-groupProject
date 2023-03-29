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
    internal class Login
    {


        public void sendEmail()
        {
            const string API_KEY = "4B765D18F45A2A65A6448E3BDF79721C97201EA62A07DD3134E7615A3D453FB02E995AF31D2CD703B48D4DE10FC6B7C2";

            Configuration config = new Configuration();
            config.ApiKey.Add("X-ElasticEmail-ApiKey", API_KEY);

            var apiInstance = new EmailsApi(config);

            var to = new List<string>();
            to.Add("officialprinteduniverse@gmail.com");
            to.Add("timmerman.ny64@gmail.com");
            var recipients = new TransactionalRecipient(to: to);
            EmailTransactionalMessageData emailData = new EmailTransactionalMessageData(recipients: recipients);
            emailData.Content = new EmailContent();
            emailData.Content.Body = new List<BodyPart>();
            BodyPart htmlBodyPart= new BodyPart();
            htmlBodyPart.ContentType = BodyContentType.HTML;
            htmlBodyPart.Charset = "utf-8";
            htmlBodyPart.Content = "<p1>Verification Code: " + randomCode().ToString() +  "<p1>";
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
        public int randomCode()
        {
            Random rand = new Random();
            int verification = rand.Next(100000, 999999);
            return verification;
        }
    }
}
