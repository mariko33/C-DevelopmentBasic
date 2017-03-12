using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.App.Models
{
   public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public string ImageThumbnail { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual ICollection<User>Owners { get; set; }

    }
}
