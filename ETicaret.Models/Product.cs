using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool? InStock { get; set; }
        public int CategoryId { get; set; }
        public string? Img { get; set; }
    }
}
