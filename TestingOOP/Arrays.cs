using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingOOP
{
    abstract class Arrays
    {
        protected abstract string MyName();
        StringBuilder sB = new StringBuilder();
        public static void CheckingArr()
        {
            bool checkName;
            Stack<string> stack = new Stack<string>();
            Stack<string> removedCollection = new Stack<string>();
            string[] arr = { "ebadhassan71@gmail.com", "Hassan@gmail.com", "Amir", "Rizwan", "Ahtisham" };
            foreach(var item in arr)
            {
                stack.Push(item);
                Thread.Sleep(5000);
                Console.WriteLine($"You received Frind Request from {item}");
            }
            string inputName;
            Console.WriteLine("Any request you want to delete.?");
            inputName = Console.ReadLine();
            switch (inputName)
            {
                case "Amir":
                checkName =  stack.Contains(inputName);
                    while(stack.Count() > 0)
                    {
                        if (checkName == stack.Any())
                        {
                            Console.WriteLine($"{inputName} Found");
                            stack.Pop();
                            stack = new Stack<string>(removedCollection);
                        }
                        else { Console.WriteLine($"User {inputName} not found."); }
                    }
                    break;
            }
            Console.WriteLine("------- Wait Please While we Start Removing your Stack to free Resources -------");
            Thread.Sleep(5000);
            List<string> elementRemoved = new List<string>();
            while(stack.Count() > 0)
            {
                string removed = stack.Pop();
                elementRemoved.Add(removed);
                Console.WriteLine($"{removed} is Deleted From Stack.");
            }
            Console.WriteLine($"Your Data is Deleted {stack.Count()} data in your list now");
            Console.ReadKey();
        }
        public static void checkingDynamicObject()
        {
            dynamic x = new ExpandoObject();
            x.FirstName = "Ëbad Hassan";
            x.FatherName = "Muneer Hussain Shahid";
            x.ContactNo = 3346718523;
            Console.WriteLine("Dynamic Before Deleteing");
            Console.WriteLine("Start Removing the Contact no From Dynamic");
            Console.WriteLine(x);
            Thread.Sleep(5000);
            Console.WriteLine("----Now Removeing the Phone Number from Dynamic----");
            ((IDictionary<string, object>)x).Remove("ContactNo");
            foreach(var item in (IDictionary<string, object>)x)
            {
                Console.WriteLine(item.Value.ToString());
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        public static void checkingDateTime()
        {
            dynamic date1 = System.DateTime.Now;
            date1.AddDays(1);
            System.Console.WriteLine(date1);
            Console.WriteLine("Press any key to Exit.");
            Console.ReadKey(true);
        }
        public static void Circularlist(int[] arr, int startIndex, int endIndex)
        {
            while(startIndex < endIndex)
            {
                int[] finalArr = { };
                for(var i = 0; i < arr.Length - 1; i++)
                {
                    int temp = arr[0];
                    arr[0] = arr[i + 1];
                    arr[i + 1] = temp;
                    finalArr.Append(arr[i]);
                }
            }
        }
        public static string sendEmail(string toSendEmail, string subjectName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                if (toSendEmail != null || toSendEmail != "")
                {
                    Console.WriteLine("Enter from Email: ");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Enter from Password: ");
                    string password = Console.ReadLine();
                    mail.From = new MailAddress("nabsub.amjadabbas@gmail.com");
                    mail.To.Add(new MailAddress($"{toSendEmail}"));
                    mail.Subject = $"Hello Dear, {subjectName}";
                    mail.IsBodyHtml = true;
                    mail.Body ="<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n        }\r\n\r\n        .container {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            padding: 20px;\r\n        }\r\n\r\n        h1 {\r\n            color: #0078d4;\r\n        }\r\n\r\n        p {\r\n            font-size: 16px;\r\n        }\r\n\r\n        .button {\r\n            display: inline-block;\r\n            padding: 10px 20px;\r\n            background-color: #0078d4;\r\n            color: #fff;\r\n            text-decoration: none;\r\n            border-radius: 4px;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <h1>Your Email Subject</h1>\r\n        <p>Hello there,</p>\r\n        <p>This is the body of your email. You can customize the content here. You can add paragraphs, links, images, and more.</p>\r\n        <p>Here's a button you can use:</p>\r\n        <a class=\"button\" href=\"https://example.com\">Click Me</a>\r\n        <p>If you have any questions or need assistance, feel free to contact us.</p>\r\n        <p>Best regards,</p>\r\n        <p>Your Name</p>\r\n    </div>\r\n</body>\r\n</html>\r\n";
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(userName,password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    Thread.Sleep(5000);
                    Console.WriteLine($"Sending Email to {toSendEmail}, Please Wait");
                    client.Send(mail);
                    Console.WriteLine("Send Successfully");
                }
                return "Send";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static void ReverseOfArray(int[] arr, int StartIndex, int EndIndex)
        {
            Circularlist(arr, 0, EndIndex);
            while (StartIndex < EndIndex)
            {
                int temp = arr[StartIndex];
                arr[StartIndex] = arr[EndIndex];
                arr[EndIndex] = temp;
                StartIndex++;
                EndIndex--;
            }
        }
        public static string GetDeviceInfo()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            string rootDiroctory = "C:\\Windows";
            string RootName = Directory.GetDirectoryRoot(rootDiroctory);
            OperatingSystem os = Environment.OSVersion;
            DriveInfo driveInfo = new DriveInfo(rootDiroctory);
            var memoryInfo = GC.GetTotalMemory(true);
            var memoryType = GC.MaxGeneration;
            string PCHostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(PCHostName).AddressList[0].ToString();
            var ConcatString = $"Your Device Information is : " +
                $"\x0A Drive Format : {driveInfo.DriveFormat} " +
                $"\x0A Available Space: {driveInfo.AvailableFreeSpace} " +
                $"\x0A Operating System: {os.Version.ToString()}" +
                $"\x0A OS Name: {osName}" +
                $"\x0A Total Installed Memory: {memoryInfo}" +
                $"\x0A RAM Generation: {memoryType}" +
                $"\x0A IP Address: {myIP}" +
                $"\x0A Last updated: {DateTime.Now}";
            System.IO.File.WriteAllText(@"C:\ConsoleLog.Txt", ConcatString);
            return ConcatString;
        }
        public abstract long GetName(int a, int b);
        public abstract string GetName(string person, string FName);
        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            string originalString = "My Name is Ebad";
            string stringWithCommas = originalString.Replace(' ', ',');
            char[] charArrayNewUpdated = null;
            string[] stringArray = stringWithCommas.Split(',');
            for (int k = 0; k < stringArray.Length; k++)
            {
                string chrar = stringArray[k];
                char[] charArrayold = chrar.ToCharArray();
                charArrayNewUpdated = new char[charArrayold.Length];
                //char[] charArray = new char[charArrayold.Length];
                int j = 0;
                for (int i = charArrayold.Length - j; i > 0; i--)
                {
                    charArrayNewUpdated[j++] = charArrayold[i-1];
                    foreach (var c in charArrayNewUpdated) { Console.Write(c); }
                }
            }
                return new string(charArrayNewUpdated);
        }
        public static string ReplceHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<p>{0}</p>");

            sb.Replace("{0}", "prince of new era");

            return sb.ToString();
        }
    }
}
