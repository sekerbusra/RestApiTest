using LCWTest.Models.ResponseModels;
using System.Collections.Generic;

namespace LCWTest.Models
{
    public class CustomerOrderResponseModel : Result
    {
        public Customer customer { get; set; }
        public List<ResponseProductModel> products { get; set; }
    }
}
