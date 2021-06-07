using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Product
    {
        public ProductName ProductName { get; }
        public int Price { get; }

        public Product(ProductName productName, int price)
        {
            ProductName = productName;
            Price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Название продукта - " + ProductName + " Цена - " + Price + "$");
        }
    }
}
