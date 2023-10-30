using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("-------------------------  Are you Sure to Run this Console App? -------------------------" +
                "\x0A Type Yes (To continue) " +
                "\x0A Type No (To Exit)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Yes":
                    Console.WriteLine("Please Enter your Name: ");
                    string userName = Console.ReadLine();
                    Console.WriteLine("Wait while we setup Application.");
                    Thread.Sleep(4000);
                    Console.Clear();
                    Console.WriteLine($"--------------- Welcome, {userName} ------------------" +
                        "\x0A ----------------- We've Following Methods --------------" +
                        "\x0A Press 1 for checkingDynamicObject." +
                        "\x0A Press 2 for checkingDateTime. " +
                        "\x0A Press 3 for  CheckingArr. " +
                        "\x0A Press 4 for sendEmail " +
                        "\x0A Press 5 for ReverseOfArray " +
                        "\x0A Press 6 for GetDeviceInfo." +
                        "\x0A Press 7 for Check KeyBoard Keys." +
                        "\x0A Press 8 for Sum of Array.");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    switch (num1)
                    {
                        case 1:
                            Arrays.checkingDynamicObject();
                            break;
                        case 2:
                            Arrays.checkingDateTime();
                            break;
                        case 3:
                            Arrays.CheckingArr();
                            break;
                        case 4:
                            Console.WriteLine("----- Loading Please Wait.... -----");
                            Thread.Sleep(4000);
                            Console.WriteLine("Please Email to send: ");
                            string inputEmail = Console.ReadLine();
                            Console.WriteLine("Enter Body or Subject Name: ");
                            string SubName = Console.ReadLine(); 
                            Arrays.sendEmail(inputEmail, SubName);
                            break;
                        case 5:
                            Console.WriteLine("Enter Elements of Array: ");
                            string inputArray = Console.ReadLine();
                            string[] inputConverted = inputArray.Split(',');
                            int[] finalArray = Array.ConvertAll(inputConverted, int.Parse);
                            Console.WriteLine($"Total Inputs Count: {finalArray.Length}");
                            Arrays.ReverseOfArray(finalArray, 0, (finalArray.Length - 1));
                            int incrementindex = 0;
                            for(var i =0; i < finalArray.Length; i++)
                            {
                                incrementindex++;
                                Console.WriteLine($"Reverse of {incrementindex} element  is: {finalArray[i]}");
                            }
                            Console.WriteLine("Press any key to Exit.");
                            Console.ReadKey();
                            break;
                        case 6:
                            var getDetails  = Arrays.GetDeviceInfo();
                            Console.WriteLine(getDetails);
                            Console.WriteLine("Press any key to Exit");
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Thread.Sleep(2000);
                            List<char> chars = new List<char>();
                            Console.WriteLine("Pressed Any Keys on your Keyboard. \x09 Press Enter to Quit.");
                            while (true)
                            {
                                ConsoleKeyInfo Info = Console.ReadKey();
                                chars.Add(Info.KeyChar);
                                if (Info.Key == ConsoleKey.Enter)
                                {
                                    break;
                                }
                            }
                            Console.WriteLine("\x09 \x09 \x09 Loading......");
                            string key = BitWiseOperators.CheckKeyPress(chars);
                            Thread.Sleep(3000);
                            Console.WriteLine(key);
                            Console.WriteLine("Press any key to Exit");
                            Console.ReadKey();
                            break;
                        case 8:
                            BitWiseOperators.SumOfAray();
                            break;


                    }
                    break;
                case "No":
                    Console.WriteLine("Closing your Application, Thanks");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}
