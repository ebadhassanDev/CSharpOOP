using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core.Tokens;

namespace TestingOOP
{
    internal class BitWiseOperators
    {
        private static int result;
        public static int OROPerator(int n1, int n2)
        {
            result = n1 | n2;
            Console.WriteLine($"The Convertion of {n1} & {n2} using OR Operator is: {result}");
            return result;
        }
        public static int SumOfAray()
        {
            int[] arr = { 1, 2, 3, 9, 6, 78, 32, 65, 21, 65 };

            Console.WriteLine($"The Original Array pass to this function is: ${arr}");
            int sum = 0;
            for(var i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"The Sum of Array is {sum}");
            Console.ReadKey();
            return sum;
        }
        public static string CheckKeyPress(List<char> a)
        {
            string message = "";
            foreach(char element in a)
            {
                if (element == 32) message += $"\x0A You Pressed Space.";
                else message += $"\x0A You Pressed {element.ToString()}";
            }
            return message;
        }
        public static string FindDiffElement()
        {
            List<int> DiffElements = new List<int>();
            int[] commonElement;
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] arr2 = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };

            DiffElements = arr.Where(x => !arr2.Contains(x)).ToList();
            commonElement = arr.Intersect(arr2).ToArray();
            var obj = new { DiffElements, commonElement }.ToString();
            return obj;
        }

    }
}
