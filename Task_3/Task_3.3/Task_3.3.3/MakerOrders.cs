using System;
using System.Collections.Generic;
using System.Text;
using Task_3._3._3.Entity;

namespace Task_3._3._3
{
    public class MakerOrders
    {
        private Pizzeria _pizzeriaMaker;

        public MakerOrders()
        {
            _pizzeriaMaker = new Pizzeria();

            _pizzeriaMaker.OrderCreated += OrderCreated;
            _pizzeriaMaker.PizzaCooked += PizzaCooked;
        }

        public void StartPizzeria()
        {
            do
            {
                ShowAssortiment();
                Console.Write("Enter number of pizza: ");
                int.TryParse(Console.ReadLine().Trim(), out int select);
                ChangePizza(select);
                Console.Write("Enter any button for continue...");
                Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
            } while (true);
        }

        private void ChangePizza(int select)
        {
            switch (select)
            {
                case 1: _pizzeriaMaker.MakeOrder(TypePizza.Donna); break;
                case 2: _pizzeriaMaker.MakeOrder(TypePizza.Firm); break;
                case 3: _pizzeriaMaker.MakeOrder(TypePizza.Caesar); break;
                case 4: _pizzeriaMaker.MakeOrder(TypePizza.Pepperoni); break;
                case 5: _pizzeriaMaker.MakeOrder(TypePizza.Home); break;
                case 6: _pizzeriaMaker.MakeOrder(TypePizza.Florentine); break;
                case 7: _pizzeriaMaker.MakeOrder(TypePizza.Venice); break;
                default:
                    Console.WriteLine("Wrong choice, try again !!!");
                    break;
            }
        }

        private void ShowAssortiment()
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                "Place your order: ", "Assortment of Pizzas: "));

            for (int i = 0; i < _pizzeriaMaker.Assortment.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_pizzeriaMaker.Assortment[i]}");
            }
        }

        private void OrderCreated(Order order)
        {
            Console.WriteLine($"Order {order.Id}: {order.Pizza.Name} accepted. Wait for it {order.Pizza.TimeCook} minutes");
        }

        private void PizzaCooked(Order order)
        {
            Console.WriteLine($"Order {order.Id}: {order.Pizza.Name} cooked . Take your order");
        }
    }
}
