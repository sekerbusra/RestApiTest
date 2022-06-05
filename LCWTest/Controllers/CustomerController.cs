using LCWTest.Context;
using LCWTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace LCWTest.Controllers
{

    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly LCWDbContext _customerContext;

        public CustomerController(LCWDbContext customerContext)
        {
            _customerContext = customerContext;
        }

        [HttpGet]
        [Route("api/getCustomer")]
        public Customer Get([FromBody]GetCustomerRequestModel model)
        {
            var customer = _customerContext.Customers.Where(c => c.CustomerId == model.customerId).FirstOrDefault();
            return customer;
        }

        
    }
}
