using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Task_3._3._3.Entity;
using System.Threading;

namespace Task_3._3._3
{
    public class Pizzeria
    {
        private int _idOrder = 0;

        public List<Pizza> Assortment  { get; private set; }

        public event Action<Order> OrderCreated;

        public event Action<Order> PizzaCooked ;

        public Pizzeria()
        {
            Assortment = new List<Pizza>
            {
                new Pizza(nameof(TypePizza.Donna), 5),
                new Pizza(nameof(TypePizza.Firm), 3),
                new Pizza(nameof(TypePizza.Caesar), 6),
                new Pizza(nameof(TypePizza.Pepperoni), 2),
                new Pizza(nameof(TypePizza.Home), 7),
                new Pizza(nameof(TypePizza.Florentine), 4),
                new Pizza(nameof(TypePizza.Venice), 5),
            };
        }

        public void MakeOrder(TypePizza pizza)
        {
            string namePizza = pizza.ToString();
            var pizzaOrder = Assortment.FirstOrDefault(x => x.Name == namePizza);

            if (pizzaOrder is null)
                throw new Exception($"Pizza {pizzaOrder} not found");

            var order = new Order(++_idOrder, pizzaOrder);
            
            OrderCreated?.Invoke(order);

            Cook(order);
        }

        private void Cook(Order order)
        {
            Thread.Sleep(order.Pizza.TimeCook * 1000);
            PizzaCooked?.Invoke(order);
        }
    }
}
