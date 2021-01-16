using System.ComponentModel.DataAnnotations;

namespace DigitArc.ProductModule.Entities.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public byte[] ImageOfProduct { get; set; }
    }
}