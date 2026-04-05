using System;
using System.Collections.Generic;

class User
{
    public string Name { get; set; }

    public User(string name)
    {
        Name = name;
    }
}

class Order
{
    public User User { get; set; }
    public List<string> Items { get; set; } = new List<string>();

    public Order(User user)
    {
        User = user;
    }

    public void AddItem(string item)
    {
        Items.Add(item);
    }

    public void Checkout()
    {
        Payment payment = new Payment(this);
        payment.Process();
    }
}

class Payment
{
    private Order _order;

    public Payment(Order order)
    {
        _order = order;
    }

    public void Process()
    {
        Console.WriteLine($"Processing payment for {_order.User.Name}");
    }
}
