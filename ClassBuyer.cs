using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Buyer
    {
        private List<Product> _products = new List<Product>();
        private Random _random;

        public int Money { get; private set; }

        public Buyer(int money)
        {
            _random = new Random();
            Money = money;
            CreateProducts();
        }

        public void WriteOffMoney()
        {
            Money -= CalculatePriceForProducts();
        }

        public int GetCountProducts()
        {
            return _products.Count;
        }

        public int CalculatePriceForProducts()
        {
            int priceForProducts = 0;

            foreach (var product in _products)
            {
                priceForProducts += product.Price;
            }

            return priceForProducts;
        }

        public void RemoveProduct()
        {
            var product = _products[_random.Next(0, _products.Count)];

            Console.WriteLine("Покупатель убрал из корзины:" + product.ProductName);

            _products.Remove(product);
        }

        public void ShowProducts()
        {
            foreach (var product in _products)
            {
                product.ShowInfo();
            }
        }

        private void CreateProducts()
        {
            int countProducts = _random.Next(1, 6);

            for (int i = 0; i < countProducts; i++)
            {
                _products.Add(new Product((ProductName)(_random.Next(0, 6)), _random.Next(2, 10)));
            }
        }
    }
}