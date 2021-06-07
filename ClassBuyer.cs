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

        public int Money { get; private set; }

        public Buyer(int money)
        {
            Money = money;
            CreateProducts();
        }

        public void WriteOffMoneyForPurchase()
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
            Random rand = new Random();

            var product = _products[rand.Next(0, _products.Count)];

            Console.WriteLine("Покупатель убрал из корзины:" + product.ProductName);

            _products.Remove(product);
        }

        private void CreateProducts()
        {
            Random rand = new Random();

            int countProducts = rand.Next(1, 6);

            for (int i = 0; i < countProducts; i++)
            {
                _products.Add(new Product((ProductName)(rand.Next(0, 6)), rand.Next(2, 10)));
            }
        }

        public void ShowProducts()
        {
            foreach (var product in _products)
            {
                product.ShowInfo();
            }
        }
    }
}
