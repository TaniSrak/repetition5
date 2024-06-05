using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repetition5
{
    public interface IOrder //работа с заказом
    {
        void AddProduct(Product product, int quantity);
        void RemoveProduct(int ProductId);
        decimal GetTotalPrice();

    }
}
