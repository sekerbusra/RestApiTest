using LCWTest.Context;
using LCWTest.Models;
using LCWTest.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LCWTest.Controllers
{
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly LCWDbContext _customerOrderContext;

        public CustomerOrderController(LCWDbContext customerOrderContext)
        {
            _customerOrderContext = customerOrderContext;
        }

        [HttpGet]
        [Route("api/customerOrder")]
        public CustomerOrderResponseModel CustomerOrder([FromBody] CustomerOrderRequestModel model)
        {
            var result = new CustomerOrderResponseModel();
            var products = new List<ResponseProductModel>();

            var _customer = _customerOrderContext.Customers.Where(c => c.CustomerId == model.customerId).FirstOrDefault();
            if (_customer != null)
            {
                if (!string.IsNullOrEmpty(model.address))
                {
                    _customer.Address = model.address;
                    _customerOrderContext.Customers.Update(_customer);
                }

                foreach (var item in model.products)
                {
                    var _product = _customerOrderContext.Products.Where(p => p.ProductId == item.productId).FirstOrDefault();

                    if (_product != null && item.quantity <= _product.Quantity)
                    {
                        var _customerOrder = _customerOrderContext.CustomerOrders.Where(co => co.CustomerId == model.customerId && co.ProductId == item.productId).FirstOrDefault();

                        if (_customerOrder != null)
                        {
                            if (item.isDelete == 1 || item.quantity == 0)
                            {
                                _customerOrderContext.CustomerOrders.Remove(_customerOrder);
                            }
                            else
                            {
                                _customerOrder.Quantity = item.quantity;
                                _customerOrder.Price = _product.Price * item.quantity;

                                _customerOrderContext.CustomerOrders.Update(_customerOrder);                               
                              
                            }
                            _customerOrderContext.SaveChanges();                            
                        }
                        else
                        {
                            var addModel = new CustomerOrder()
                            {
                                ProductId = _product.ProductId,
                                CustomerId = _customer.CustomerId,
                                Quantity = item.quantity,
                                Price = item.quantity * _product.Price
                            };
                            _customerOrderContext.CustomerOrders.Add(addModel);
                            _customerOrderContext.SaveChanges();
                        }
                        
                    }
                    else
                    {
                        result.code = 0;
                        result.message = "Bu id = " + item.productId + " ait ürün bulunamamıştır.";

                        return result;
                    }
                }

                var _customerOrders = _customerOrderContext.CustomerOrders.Where(co => co.CustomerId == _customer.CustomerId).ToList();
                foreach (var order in _customerOrders)
                {
                    var _orderProduct = _customerOrderContext.Products.Where(op => op.ProductId == order.ProductId).FirstOrDefault();
                    var productModel = new ResponseProductModel()
                    {
                        barcode = _orderProduct.Barcode,
                        price = order.Price,
                        description = _orderProduct.Description,
                        quantity = order.Quantity

                    };
                    products.Add(productModel);

                }
                var custOrder = new CustomerOrderResponseModel()
                {
                    customer = _customer,
                    products = products

                };
                return custOrder;
            }
            result.code = 0;
            result.message = "Bu id="+model.customerId+" ait kullanıcı bulunamadı.";

            return result;

        }

        [HttpGet]
        [Route("api/getCustomerOrdersById")]
        public CustomerOrderResponseModel GetCustomerOrdersById([FromBody]GetCustomerOrdersRequestModel model)
        {
            var result = new CustomerOrderResponseModel();
            var products = new List<ResponseProductModel>();

            var _customer = _customerOrderContext.Customers.Where(c => c.CustomerId == model.customerId).FirstOrDefault();

            if(_customer != null)
            {
                var _customerOrders = _customerOrderContext.CustomerOrders.Where(co => co.CustomerId == model.customerId).ToList();
                foreach(var item in _customerOrders)
                {
                    var _product = _customerOrderContext.Products.Where(p => p.ProductId == item.ProductId).FirstOrDefault();

                    var productModel = new ResponseProductModel()
                    {
                        barcode = _product.Barcode,
                        price = _product.Price,
                        description = _product.Description,
                        quantity = _product.Quantity

                    };
                    products.Add(productModel);
                }

                var custOrders = new CustomerOrderResponseModel()
                {
                    customer = _customer,
                    products = products

                };
                return custOrders;
            }

            result.code = 0;
            result.message = "Bu id=" + model.customerId + " ait kullanıcı bulunamadı.";

            return result;
        }
    }
}
