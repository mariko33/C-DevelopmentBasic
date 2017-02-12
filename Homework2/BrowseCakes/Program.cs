using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseCakes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine("<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Browse Cakes</title>\r\n</head>\r\n<body>\r\n<a href=\"ByTheCake.exe\">Back to Home</a>\r\n<form action=\"BrowseCakes.exe\" method=\"get\">\r\n    <input type=\"text\" name=\"name\">\r\n    <input type=\"submit\" value=\"Search\">\r\n</form>\r\n</body>");
            var request = Environment.GetEnvironmentVariable("QUERY_STRING");
            if (request != null)
            {
                var token = request.Split('=');
                var keyword = token[1].ToLower();
                var cakes=new List<Cake>();
                using (var reader=new StreamReader("database.csv"))
                {
                    string line;
                    while ((line=reader.ReadLine())!=null)
                    {
                        string[] cakeInfo = line.Split(',');
                        string name = cakeInfo[0];
                        double price = double.Parse(cakeInfo[1]);
                        Cake cake=new Cake()
                        {
                            Name = name,
                            Price = price
                        };
                        cakes.Add(cake);

                    }
                }

                var filteredCakes = cakes.Where(c => c.Name.ToLower().Contains(keyword));
                foreach (var cake in filteredCakes)
                {
                    Console.WriteLine($"name = {cake.Name}, price = {cake.Price}</br>");
                }
            }
        }
    }
}
