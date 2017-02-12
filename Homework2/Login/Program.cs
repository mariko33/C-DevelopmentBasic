using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine("<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Login</title>\r\n</head>\r\n<body>\r\n<form action=\"Login.exe\" method=\"post\">\r\n    <label for=\"name\">Name</label>\r\n    <input type=\"text\" name=\"name\" id=\"name\">\r\n    <br>\r\n    <label for=\"password\">Password</label>\r\n    <input type=\"password\" name=\"password\" id=\"password\">\r\n    <br>\r\n    <input type=\"submit\" value=\"Log in\">\r\n</form>\r\n</body>");
            var input = Console.ReadLine();
            if (input != null)
            {
                string[] token = input.Split(new char[] {'&', '='}, StringSplitOptions.RemoveEmptyEntries);
                string name = token[1];
                string password = token[3];
                Console.WriteLine($"Hi {name} your password is:{password}");
            }


        }
    }
}
