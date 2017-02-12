

using System;

namespace ByTheCake
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type:text/html\r\n");
            Console.WriteLine("<head>");
            Console.WriteLine("<meta charset=\"UTF-8\">");
            Console.WriteLine("<meta name=\"description\" content=\"By the cake in By the Cake\">\r\n    <meta name=\"keywords\" content=\"cakes, buy\">\r\n    <meta name=\"author\" content=\"Maria Georgieva\">");
            Console.WriteLine("<title>ByTheCake</title>");
            Console.WriteLine("</head>");
            Console.WriteLine("<body>\r\n<h1>By The Cake</h1>\r\n<h2>Enjoy our awesome cakes</h2>\r\n<hr>");
            Console.WriteLine("<ul>\r\n    <li><a href=\"#\">Home</a>\r\n        <ol>\r\n        <li><a href=\"#cakes\">Our Cakes</a></li>\r\n            <li><a href=\"#stores\">Our Stores</a></li>\r\n    </ol>\r\n    </li>\r\n    <li><a href=\"AddCake.exe\">Add Cake</a></li>\r\n    <li><a href=\"BrowseCakes.exe\">Browse Cakes</a></li>\r\n    <li><a href=\"#aboutus\">About Us</a></li>\r\n</ul>\r\n");
            Console.WriteLine("<h2>Home</h2>\r\n<h3 id=\"cakes\">Our Cakes</h3>\r\n<p>Cake is a form of <span style=\"font-style: italic\">sweet dessert</span> that is typically baked. In its oldest forms,<span style=\"font-style: italic\">cakes</span> were modifications of breads, but cakes now cover a wide range of preparations that can be simple or elaborate, and that share features with other desserts such as pastries, meringues, custards, and pies.</p>\r\n<img src=\"http://2.bp.blogspot.com/-1byDPsoC2vA/Vq8IfiaoQlI/AAAAAAAASsw/vq0kmeunOxM/s1600/Happy_birthday_cake_images%2Bcopy.jpg\" width=\"300\"px height=\"300\"px>\r\n<h3 id=\"stores\">Our Stores</h3>\r\n<p>Our stores are located in 21 cities all over the world. Come and see what we have for you.</p>\r\n<img src=\"http://elitecakes.co.za/wp-content/gallery/elite-cakes/IMG-20160801-WA0048.jpg\" width=\"300\"px height=\"300\"px>\r\n");
            Console.WriteLine("<h2 id=\"aboutus\">About Us</h2>\r\n<dl>\r\n    <dt>By the Cake Ltd</dt>\r\n    <dd>Dreamed Cake</dd>\r\n    <dt>John Smit</dt>\r\n    <dd>Owner</dd>\r\n</dl>\r\n<pre style=\"background-color: #F94F80\">\r\n    City: Hong Kong    City: Salzburg\r\nAddress: ChoCoLad 18   Address: SchokoLeiden 73\r\nPhone: +78952804429    Phone: +49241432990\r\n\r\n</pre>\r\n");
            Console.WriteLine("<hr>\r\n<footer style=\"text-align: center\">\r\n    &copy; All Rights Reserved\r\n</footer>\r\n</body>");

        }

    
       
    }
}
