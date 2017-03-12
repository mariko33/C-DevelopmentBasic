using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.App.ViewModels
{
   public class GameAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            string representation = $"<tr>\r\n<td>{this.Name}</td>\r\n" +
                                    $"<td>{this.Size} GB</td>\r\n" +
                                    $"<td>{this.Price} &euro;</td>\r\n" +
                                    $"<td>\r\n<a href=\"/games/edit?id={this.Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n" +
                                    $"<a href=\"games/delete?id={this.Id}\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n</td>\r\n</tr>";
            return representation.ToString();
        }
    }
}
