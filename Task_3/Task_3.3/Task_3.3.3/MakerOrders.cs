using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._3._3
{
    public class MakerOrders
    {
        private Pizzeria _pizzeriaMaker;

        public MakerOrders()
        {
            _pizzeriaMaker = new Pizzeria();

            _pizzeriaMaker.OrderCreated += null;
            _pizzeriaMaker.PizzaCooked += null;
        }

        public void StartPizzeria()
        {
            do
            {
                ShowAssortiment();

            } while (false);
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

    }
}
