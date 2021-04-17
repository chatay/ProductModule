using System.ComponentModel.DataAnnotations;

namespace DigitArc.ProductModule.Entities.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImagePath { get; set; }
    }
}