using System.ComponentModel.DataAnnotations;

namespace LCWTest.Models.RequestModels
{
    public class GetCustomerOrdersRequestModel
    {
        [Required]
        public int customerId { get; set; }
    }
}
