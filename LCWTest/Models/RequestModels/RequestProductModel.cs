using System.ComponentModel.DataAnnotations;

namespace LCWTest.Models
{
    public class RequestProductModel
    {
        [Required]
        public int productId { get; set; }
        [Required]
        public int quantity { get; set; }
        public int isDelete { get; set; }
    }
}
