using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Supermarket
    {
        private int _money;
        private bool _isOpen = true;
        private Queue<Buyer> _buyers = new Queue<Buyer>();

        public void Work()
        {
            CreatBuyers();

            while (_isOpen)
            {
                Console.WriteLine("Баланс магазина: " + _money);
                Console.WriteLine("Очередь из клиентов и их покупки:\n");
                ShowAllBuyers();

                Console.WriteLine("1 - Обслужить первого клиента в очереди\n2 - Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (_buyers.Count > 0)
                        {
                            Console.Clear();
                            ServeBuyer();
                        }
                        break;
                    case "2":
                        _isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует...");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }

        }

        private void ServeBuyer()
        {
            var buyer = _buyers.Dequeue();
            int priceForProducts = buyer.CalculatePriceForProducts();

            Console.SetCursorPosition(0, 20);
            buyer.ShowProducts();
            Console.SetCursorPosition(0, 0);

            if (buyer.Money >= priceForProducts)
            {
                _money += priceForProducts;
                buyer.WriteOffMoney();
                Console.WriteLine("Все хорошо, покупатель оплатил весь товар, магазин заработал - " + priceForProducts + "$");
            }
            else
            {
                while (priceForProducts > buyer.Money)
                {
                    Console.SetCursorPosition(0, 20);
                    buyer.ShowProducts();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"У покупателя {buyer.Money} $, сумма покупок {priceForProducts} $\n\nНедостаточно денег, нужно убрать товар из корзины и повторить попытку\n");

                    buyer.RemoveProduct();
                    priceForProducts = buyer.CalculatePriceForProducts();

                    Console.WriteLine("\nНажмите любую клавишу для поторной попытки оплаты");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (buyer.GetCountProducts() == 0)
                {
                    Console.WriteLine("У вас нехватает денег ни на один товар, уходите");
                }
                else
                {
                    _money += priceForProducts;
                    buyer.WriteOffMoney();
                    Console.WriteLine("У покупателя хватило денег только на:\n");
                    buyer.ShowProducts();
                    Console.WriteLine("Вы все оплатили, всеГО хорошеГО, ждем Вас снова)\nмагазин заработал - " + priceForProducts + "$");
                }
            }
        }

        private void CreatBuyers()
        {
            Random rand = new Random();
            int countBuyers = 3;

            for (int i = 0; i < countBuyers; i++)
            {
                _buyers.Enqueue(new Buyer(rand.Next(10, 20)));
            }
        }

        private void ShowAllBuyers()
        {
            int buyerNumber = 1;

            foreach (var buyer in _buyers)
            {
                Console.WriteLine("Покупатель №" + (buyerNumber++) + " Его кошелек - " + buyer.Money + "$" + " и список его товаров:");
                buyer.ShowProducts();
                Console.WriteLine();
            }
        }
    }
}
