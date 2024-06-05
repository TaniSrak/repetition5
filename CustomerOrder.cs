using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repetition5
{
    public class CustomerOrder : Order //заказчик
    {
        public string CustomerAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<OrderItem> items = new List<OrderItem>();


    }
}
