using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._3._3.Entity
{
    public class Order
    {
        public int Id { get; private set; }

        public Pizza Pizza { get; private set; }

        public Order(int id, Pizza pizza)
        {
            Id = id;
            Pizza = pizza;
        }
    }
}
