using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LCWTest.Models
{
    public class CustomerOrderRequestModel
    {
        [Required]
        public int customerId { get; set; }
        [Required]
        public List<RequestProductModel> products { get; set; }
        public string address { get; set; }
    }
}
