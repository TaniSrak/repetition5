using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace repetition5
{
    public class Order : IOrder //непосредственно сам заказ
    {
        protected List<OrderItem> items = new List<OrderItem>();

        //добавим продукт в сам заказ
        public void AddProduct(Product product, int quantity)
        {
            //существующий предмет
            var existingItem = items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem.Product.Id != 0)
            {
                items.Remove(existingItem); //удаляем
                existingItem.Quantity += quantity; //увеличиваем количество
                items.Add(existingItem); //добавляем

            }
            else
            {
                items.Add(new OrderItem { Product = product, Quantity = quantity });
            }
        }
        //удалять продукт
        public void RemoveProduct(int productId)
        {
            items.RemoveAll(i =>  i.Product.Id == productId);
        }
        //общая стоимость
        public decimal GetTotalPrice()
        {
            return items.Sum(i => i.Product.Price * i.Quantity);
        }
        public List<OrderItem> GetOrderItems() { return items; } //защищаем список от изменений

    }
}
