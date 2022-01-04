using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostAdAspNetCoreMVC.Models
{
    public class Ad
    {
        private int id;
        private string title;
        private string description;
        private decimal price;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        [DataType(DataType.Text)] public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
        public virtual List<Image> Images { get; set; }

        public Ad()
        {
            Images = new List<Image>();
        }

    }
}
