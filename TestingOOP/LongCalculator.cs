using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using TestingOOP.Attributes;

namespace TestingOOP
{
    internal class LongCalculator
    {
        int[] userListNumber1 = new int[15];
        int[] userListNumber2 = new int[15];
        string userName = string.Empty;


       [HttpRoute("testing Name" , Version = 2.0)]
       public void Calcualtion()
       {
            Console.WriteLine("Enter your Name:");
            userName =  Console.ReadLine();
            Thread.Sleep(3000);
            Console.Clear();


            Console.WriteLine("*********************** 15 Digit Long Calculator ****************************");
            Console.WriteLine("*****************************************************************************");
            Console.WriteLine($"************************* Welcome {userName} *******************************\x0A \x0A");
            Console.WriteLine("Press 1 for Addition       (+)");
            Console.WriteLine("Press 2 for Subtraction    (-)");
            Console.WriteLine("Press 3 for Multipilcation (*)");
            Console.WriteLine("Press 4 for Division       (/)");
            Console.WriteLine("Press 5 for Power          (**)");
            Console.WriteLine("Press 6 for Modulus        (%)");

            string method = Console.ReadLine();
            switch (method)
            {
                case "1":
                    Console.Write("Enter First Number: ");
                    userListNumber1 = ParseNumber(Console.ReadLine());
                    Console.Write("Enter second Number: ");
                    userListNumber2 = ParseNumber(Console.ReadLine());

                    Console.WriteLine("Addition: " + NumberToString(Add(userListNumber1, userListNumber2)));
                    break;
                case "2":
                    Console.WriteLine("Enter First Number: ");
                    userListNumber1 = ParseNumber(Console.ReadLine());
                    Console.WriteLine("Enter second Number: ");
                    userListNumber2 = ParseNumber(Console.ReadLine());

                    Console.WriteLine("Subtraction: " + NumberToString(Subtraction(userListNumber1, userListNumber2)));
                    break;
                case "3":
                    Console.WriteLine("Enter First Number: ");
                    userListNumber1 = ParseNumber(Console.ReadLine());
                    Console.WriteLine("Enter second Number: ");
                    userListNumber2 = ParseNumber(Console.ReadLine());

                    Console.WriteLine("Multipilcation: " + NumberToString(Multiplication(userListNumber1, userListNumber2)));
                    break;
                case "4":
                    Console.WriteLine("Enter First Number: ");
                    userListNumber1 = ParseNumber(Console.ReadLine());
                    Console.WriteLine("Enter second Number: ");
                    userListNumber2 = ParseNumber(Console.ReadLine());

                    Console.WriteLine("Division: " + NumberToString(Divide(userListNumber1, userListNumber2)));
                    break;
                case "5":
                    Console.WriteLine("Enter First Number: ");
                    userListNumber1 = ParseNumber(Console.ReadLine());
                    Console.WriteLine("Enter second Number: ");
                    userListNumber2 = ParseNumber(Console.ReadLine());
                    break;
                case "6":
                    Console.WriteLine("Enter First Number: ");
                    userListNumber1 = ParseNumber(Console.ReadLine());
                    Console.WriteLine("Enter second Number: ");
                    userListNumber2 = ParseNumber(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Invalid Choice, Please Select From Above..\nCloseing application......");
                    Thread.Sleep(2000);
                    break;
            }
       } 
        static string NumberToString(int[] number)
        {
            return string.Join("", number);
        }

        static int[] ParseNumber(string number)
        {
            int[] result = new int[number.Length];
            for (int i = 0; i < number.Length; i++)
            {
                result[i] = int.Parse(number[i].ToString());
            }
            return result;
        }
        static int[] Add(int[] num1, int[] num2)
        {
            int maxLength = (num1.Length + num2.Length);
            int[] result = new int[maxLength + 1]; 

            int carry = 0;
            for (int i = 0; i < maxLength; i++)
            {
                int digit1 = (i < num1.Length) ? num1[i] : 0;
                int digit2 = (i < num2.Length) ? num2[i] : 0;

                int sum = digit1 + digit2 + carry;
                result[i] = sum % 10;
                carry = sum / 10;
            }

            return result;
        }
        static int[] Multiplication(int[] num1, int[] num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            int[] result = new int[len1 + len2];

            for (int i = len1 - 1; i >= 0; i--)
            {
                int carry = 0;

                for (int j = len2 - 1; j >= 0; j--)
                {
                    int product = num1[i] * num2[j] + result[i + j + 1] + carry;
                    result[i + j + 1] = product % 10;
                    carry = product / 10;
                }

                result[i] += carry;
            }
            int startIndex = 0;
            while (startIndex < result.Length && result[startIndex] == 0)
            {
                startIndex++;
            }

            if (startIndex == result.Length)
            {
                return new int[] { 0 };
            }

            int[] finalResult = new int[result.Length - startIndex];
            Array.Copy(result, startIndex, finalResult, 0, finalResult.Length);

            return finalResult;
        }
        static int[] Subtraction(int[] num1, int[] num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            int[] result = new int[Math.Max(len1, len2)];

            int borrow = 0;

            for (int i = 0; i < result.Length; i++)
            {
                int digit1 = (i < len1) ? num1[len1 - i - 1] : 0;
                int digit2 = (i < len2) ? num2[len2 - i - 1] : 0;

                int diff = digit1 - digit2 - borrow;

                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                result[result.Length - i - 1] = diff;
            }

            int startIndex = 0;
            while (startIndex < result.Length && result[startIndex] == 0)
            {
                startIndex++;
            }

            if (startIndex == result.Length)
            {
                return new int[] { 0 };
            }

            int[] finalResult = new int[result.Length - startIndex];
            Array.Copy(result, startIndex, finalResult, 0, finalResult.Length);

            return finalResult;
        }
        static int[] Divide(int[] num1, int[] num2)
        {
            if (IsZero(num2))
            {
                throw new DivideByZeroException("Division by zero is undefined.");
            }

            int[] result = new int[num1.Length];

            int currentIndex = 0;
            int[] currentDividend = new int[1];

            foreach (int digit in num1)
            {
                currentDividend = AppendDigit(currentDividend, digit);

                while (IsGreaterOrEqual(currentDividend, num2))
                {
                    currentDividend = Subtraction(currentDividend, num2);
                    result[currentIndex]++;
                }

                currentIndex++;
            }

            return result;
        }
        static int[] AppendDigit(int[] num, int digit)
        {
            int[] result = new int[num.Length + 1];
            Array.Copy(num, result, num.Length);
            result[num.Length] = digit;
            return result;
        }
        static bool IsZero(int[] num)
        {
            foreach (int digit in num)
            {
                if (digit != 0)
                {
                    return false;
                }
            }
            return true;
        }
        static bool IsGreaterOrEqual(int[] num1, int[] num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 > len2) return true;
            if (len1 < len2) return false;

            for (int i = 0; i < len1; i++)
            {
                if (num1[i] > num2[i]) return true;
                if (num1[i] < num2[i]) return false;
            }

            return true;
        }
        //public void Log(LogLevel logglevel, string message, params object[] args)
        //{
        //    if (!IsEnabled(logglevel))
        //    {
        //        return;
        //    }
        //}
        public ref struct Log
        {

        }

        private bool IsEnabled(LogLevel logglevel)
        {
            throw new NotImplementedException();
        }

        //[InterpolatedStringHandler]
        //public ref struct LoggingInterpolatedStringHandler
        //{
        //    public DefaultInterpolatedStringHandler __Stringhandler;
        //}

        
    }
}
