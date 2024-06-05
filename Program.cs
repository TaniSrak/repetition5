using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repetition5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.AddProduct(new Product { Id = 1, Name = "Laptop", Price = 1000m });
            shop.AddProduct(new Product { Id = 2, Name = "Phone", Price = 500m });

            //создаем заказ
            var order = new CustomerOrder
            {
                CustomerName = "John Doe",
                CustomerAddress = "123 MAin St",
                CustomerPhone = "555-1234"
            };
            //добавляем в заказ продукты, но сначала просто их ищем
            var laptop = shop.FingProductByName("Laptop").FirstOrDefault();
            var phone = shop.FingProductByName("Phone").FirstOrDefault();

            if (laptop.Id != 0) order.AddProduct(laptop, 1);
            if (laptop.Id != 0) order.AddProduct(phone, 2);

            shop.AddOrder(order);

            //сохраняем в файл
            Console.WriteLine(JsonHelper.SerializeObject(order));
            JsonHelper.SaveToFile(order, "order.json");

            var loadedOrder = JsonHelper.LoadFromFile<CustomerOrder>("order.json");
            Console.WriteLine("\nloaded Order");
            Console.WriteLine("Customer: " + loadedOrder.CustomerName);
            Console.WriteLine("Total Prime: " + loadedOrder.GetTotalPrice());
            Console.ReadKey();

            //поиск заказов клиента
            var customerOrders = shop.GetOrderByCustomerName("John Doe");
            Console.WriteLine("\nOrders for Johm Doe: ");
            foreach ( var custOrder in customerOrders)
            {
                Console.WriteLine("Order Total: " + custOrder.GetTotalPrice());
            }
        }
    }
}

/*Задача: Система Учета Заказов в Интернет-Магазине
Описание задачи:

Разработать систему учета заказов для интернет-магазина, которая включает следующие компоненты и функции:

Структуры и интерфейсы:

Создайте структуру Product, которая будет содержать информацию о продукте (ID, имя, цена).
Создайте структуру OrderItem, которая будет содержать продукт и количество.
Создайте интерфейс IOrder, который будет содержать методы для работы с заказом (добавление продукта, удаление продукта, получение общей стоимости заказа).
Классы и наследование:

Создайте класс Order, который будет реализовывать интерфейс IOrder.
Создайте класс CustomerOrder, который будет наследовать класс Order и содержать информацию о клиенте (имя, адрес, телефон).
Коллекции и LINQ:

Используйте коллекции для хранения продуктов и заказов.
Реализуйте метод для поиска продуктов по заданному критерию (например, по имени или диапазону цен) с использованием LINQ.
Реализуйте метод для получения всех заказов определенного клиента.
Работа с JSON:

Реализуйте методы для сериализации и десериализации заказов и продуктов в/из JSON. */
