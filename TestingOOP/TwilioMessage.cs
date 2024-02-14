using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using TestingOOP.Models;
using System.IO;
using MongoDB.Bson;
using Com.CloudRail.SI.Types;
using System.Net.Http.Headers;

namespace TestingOOP
{
    public class TwilioMessage 
    {

        string accessID = "AC0c2f48abe2f3a94353edcc5e44e84bc5";
        string authTokn = "935e24ebeeff2a5eae5fcfb0dbf569eb";
        private readonly WhatsappBusinessRequestEndPoints _endPoints;
        HttpClient http = new HttpClient();

        public TwilioMessage()
        {
            this._endPoints = new WhatsappBusinessRequestEndPoints();
        }
        public string SendMessage()
        {
            try
            {
                var users = new List<string> { "whatsapp:+923346718523", "whatsapp:+923337517002", "whatsapp:+923067062992" , "whatsapp:+923407911079" };
                TwilioClient.Init(accessID, authTokn);
                foreach (var numbers in users)
                {
                    var message = MessageResource.Create(
                        body: "Testing My Name is Ebad",
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
        public string FileName(dynamic obj)
        {
            Random random = new Random();
            var RandomNumbers = "";
            var date = $"{DateTime.UtcNow:yyyyMMddHHmmss}";
            for (var i = 0; i < 5; i++)
            {
                RandomNumbers = random.Next().ToString();
            }
            return $"{obj}_{date}_{RandomNumbers}.json";
        }
        public async Task<ResponseData> SendWhatsAppMessage()
        {
            try
            {
                TextMessageRequest textMessage = new TextMessageRequest();
                MessageViewModal message = new MessageViewModal();
                textMessage.To = message.ReceipentNumber;
                textMessage.Text = new WhatsAppText();
                textMessage.Text.Body = message.Message;
                textMessage.Text.PreviewUrl = false;
                string jsonFile = "C:\\Users\\Hp\\source\\repos\\TestingOOP\\TestingOOP\\MessageTemplate.json";
                if (File.Exists(jsonFile))
                {
                    var uri = $"{_endPoints.BasePath}{_endPoints.BusinessNumberID}{_endPoints.PostMessagePath}";
                    var encodeJson = File.ReadAllText(jsonFile);
                    var content = new StringContent(encodeJson, Encoding.UTF8, "application/json");
                    Console.WriteLine(content);
                        http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_endPoints.bearerToken}");
                        HttpResponseMessage response = await http.PostAsync(uri, content);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = response.Content.ToString();
                            Console.WriteLine(responseBody);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"{response.Content} \x0A {response.StatusCode} \x0A {response.ReasonPhrase} \x0A {response.RequestMessage}");
                            Console.ReadKey();
                        }
                    
                }
                return  new ResponseData() { Message = "" };
            }
            catch (Exception ex)
            {

                return new ResponseData() { Message = ex.Message };
            }
        }
        public string GenerateGloalUserId()
        {
            string boundary = $"----------{Guid.NewGuid():N}";
            Console.WriteLine(boundary);
            Thread.Sleep(5000);
            return boundary;
        }
        public async Task<string> GetMessageTemplates()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://graph.facebook.com/v17.0/170773602786489/message_templates");
            request.Headers.Add("Authorization", "Bearer EAAJ8Wwc939sBOz3fLfvGBSMy4Rs2jyUXxZCwxHt5bqfaZChAW1nUjSir9ZA98a2V7ABiMSTZAycZAZCgQ9ZA6VXgqiprqT678VHTr5DPtPnoRZCyFav5o6kAjZBsX31DSMisEbWNKCbxb9WyMxyMmYo8768yIb4Rhh1iSDMfiK5LawvP9zlULUmSWEsNd7Kg2wdEi");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());


            return "";
        }
        public async Task<ResponseData> PostMessageTmplate()
        {
            var postURL = $"{_endPoints.BasePath}{_endPoints.BusinessProfileId}{_endPoints.PostTemplatePath}";
            string templateJson = "C:\\Users\\Hp\\source\\repos\\TestingOOP\\TestingOOP\\MessageBodyTemplate.json";
            try
            {
                if (File.Exists(templateJson))
                {
                    var jsonReader = File.ReadAllText(templateJson);
                    var context = new StringContent(jsonReader, Encoding.UTF8, "application/json");
                    if (context != null)
                    {
                        http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_endPoints.bearerToken}");
                        HttpResponseMessage response = await http.PostAsync(postURL, context);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = response.IsSuccessStatusCode ? response.Content.ToString() : null;
                            Console.WriteLine(responseBody);
                        }
                        else
                        {
                            Console.WriteLine($"Error while sending Message Template to Meta \x0A {response.StatusCode} \x0A {response.Headers} \x0A {response.Content}");

                        }
                    }
                   
                }
                return new ResponseData()
                {
                    Message = ""
                };

            }
            catch (Exception ex)
            {
                return new ResponseData() { Message = ex.Message};
            }
        } 
    }
}
