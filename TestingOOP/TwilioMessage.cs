using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;

namespace TestingOOP
{
    internal class TwilioMessage 
    {
        
        string accessID = "AC0c2f48abe2f3a94353edcc5e44e84bc5";
        string authTokn = "935e24ebeeff2a5eae5fcfb0dbf569eb";
       
        public string SendMessage()
        {
            try
            {
                var users = new List<string> { "whatsapp:+923346718523", "whatsapp:+923337517002", "whatsapp:+923067062992" , "whatsapp:+923407911079" };
                TwilioClient.Init(accessID, authTokn);
                foreach (var numbers in users)
                {
                    var message = MessageResource.Create(
                        body: "Hi, Ebad How are you?",
                        from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                        to: new Twilio.Types.PhoneNumber(numbers));
                    Console.WriteLine($"The Message ID is: {message.Sid} \x0A and Status: {message.Status} \x0A and Date: {message.DateUpdated}");
                }
                Thread.Sleep(9000);

                return "Success Send";
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
