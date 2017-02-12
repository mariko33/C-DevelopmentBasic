using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine("<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Calculator</title>\r\n</head>\r\n<body>\r\n<form action=\"Calculator.exe\" method=\"post\">\r\n    <input type=\"text\" name=\"firstNumber\">\r\n    <input type=\"text\" name=\"signOperator\">\r\n    <input type=\"text\" name=\"secondNumber\">\r\n    <input type=\"submit\" value=\"Calculate\">\r\n</form>\r\n\r\n</body>");
            var input = Console.ReadLine();
            if (input != null)
            {
                string[] token = input.Split(new char[] {'=', '&'}, StringSplitOptions.RemoveEmptyEntries);
                double firstNumber = double.Parse(token[1]);
                string sign = token[3];
                double secondNumber = double.Parse(token[5]);
                switch (sign)
                {
                    case "%2B": // +
                        Console.WriteLine(firstNumber+secondNumber);
                        break;
                    case "-": //-
                        Console.WriteLine(firstNumber-secondNumber);
                        break;
                    case "%2F": // /
                        Console.WriteLine(firstNumber/secondNumber);
                        break;
                    case "*": //*
                        Console.WriteLine(firstNumber*secondNumber);
                        break;
                    default:
                        Console.WriteLine("Invalid sign");
                        break;

                }
            }
        }
    }
}
