﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.App.ViewModels
{
  public class GameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageThumbnail { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            string representation = "<div class=\"card col-4 thumbnail\">\r\n\r\n" +
                                    $"<img class=\"card-image-top img-fluid img-thumbnail\" src=\"{this.ImageThumbnail}\">\r\n\r\n" +
                                    "<div class=\"card-block\">\r\n" +
                                    $"<h4 class=\"card-title\">{this.Title}</h4>\r\n" +
                                    $"<p class=\"card-text\"><strong>Price</strong> - {this.Price}&euro;</p>\r\n" +
                                    $"<p class=\"card-text\"><strong>Size</strong> - {this.Size} GB</p>\r\n" +
                                    "<p class=\"card-text\"></p>\r\n</div>\r\n\r\n<div class=\"card-footer\">\r\n" +
                                   $"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/store/details?id={this.Id}\">Info</a>\r\n" +
                                    "</div>\r\n\r\n</div>";
            return representation;
        }
    }
}
