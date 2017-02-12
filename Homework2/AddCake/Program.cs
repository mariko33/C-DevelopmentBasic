using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCake
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine("<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>AddCake</title>\r\n</head>\r\n<body>\r\n<form action=\"AddCake.exe\" method=\"post\">\r\n    <label for=\"name\">name</label>\r\n    <input type=\"text\" id=\"name\" name=\"name\">\r\n    <label for=\"price\">price</label>\r\n    <input type=\"text\" id=\"price\" name=\"price\">\r\n    <input type=\"submit\" value=\"Add Cake\">\r\n</form>\r\n</body>");
            string input = Console.ReadLine();
            string[] tokens = input.Split(new char[] {'=', '&'}, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[1].Replace('+', ' ');
            double price = double.Parse(tokens[3]);
            Cake cake=new Cake()
            {
                Name = name,
                Price = price
            };
            File.AppendAllText("database.csv",$"{cake.Name},{cake.Price}{Environment.NewLine}");
        }
    }
}
