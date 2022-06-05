using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCWTest.Models.RequestModels
{
    public class UpdateCustomerOrderRequestModel
    {
        public int customerId { get; set; }
        public List<RequestProductModel> products { get; set; }
    }
}
