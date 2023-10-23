//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestingOOP
//{
//    class Teacher : Student
//    {
//        public bool Validate()
//        {
//            int num1 = 20;
//            int num2 = 30;
//            var mult = GetName(num1, num2);
//            if (mult == 600)
//            {
//                Console.WriteLine($"The Multiplication of {num1} and {num2} = {mult}");
//                Console.ReadKey();
//                return true;
//            }

//            return false;


//        }
//        public override long GetName(int a, int b)
//        {
//            return a * b;
//        }
//        public override string GetName(string person, string FName)
//        {
//            throw new NotImplementedException();
//        }
//        public void checkString()
//        {
//            string name = "Ali Ahmed";
//            String fatherName = "Muneer Hussain";

//            Console.WriteLine($"Checkig the string with small is {name} and now the big is {fatherName}.");
//            Console.ReadKey();
//        }
//    }
//}
