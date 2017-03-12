using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.App.ViewModels
{
  public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public override string ToString()
        {
            string representation = $"<h1 class=\"display-3\">{this.Title}</h1>\r\n" +
                                    "<br/>\r\n\r\n" +
                                    $"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.Trailer}\" frameborder=\"0\" allowfullscreen></iframe>" +
                                    $"\r\n\r\n<br/>\r\n<br/>\r\n\r\n<p></p>\r\n\r\n<p><strong>Price</strong> - {this.Price}&euro;</p>" +
                                    $"\r\n<p><strong>Size</strong> - {this.Size} GB</p>\r\n<p>" +
                                    $"<strong>Release Date</strong> - {this.ReleaseDate}</p>\r\n" +
                                    $"<a class=\"btn btn-outline-primary\" name=\"back\" href=\"/store/home\">Back</a>" +
                                    $"\r\n<form  method=\"post\">\r\n" +
                                    $"<input type=\"number\" value=\"{this.Id}\" name=\"Id\" hidden=\"hidden\" />\r\n" +
                                    $"<br/>\r\n<input type=\"submit\" class=\"btn btn-success\" value=\"Buy\" />\r\n</form>" +
                                    $"\r\n<br/>\r\n<br/>";
            return representation;
        }
    }
}
