﻿namespace GameStore.App.BindingModels
{
   public class EditBindingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public string ImageThumbnail { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
