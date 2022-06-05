using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCWTest.Models
{
    public class ResponseProductModel
    {
        public string barcode { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
