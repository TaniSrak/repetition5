using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repetition5
{
    public class Shop //магазин для поиска продуктов
    {
        private List<Product> products = new List<Product>();
        private List<CustomerOrder> orders = new List<CustomerOrder>();

        public void AddProduct(Product product)
        { products.Add(product); }
        public void AddOrder(CustomerOrder order) 
        { orders.Add(order); }

        //поиск продукта по имени
        public IEnumerable<Product> FingProductByName(string name)
        {
            return products.Where(p => p.Name.Contains(name)).ToList();
        }

        //поиск по диапазону цен
        public IEnumerable<Product> FindProductsByPriceRange(decimal min, decimal max)
        {
            return products.Where(p => p.Price >= min && p.Price <= max).ToList();
        }
        //поиск заказчика по имени
        public IEnumerable <CustomerOrder> GetOrderByCustomerName(string customerName)
        {
            return orders.Where(o => o.CustomerName == customerName).ToList();
        }

    }
}
