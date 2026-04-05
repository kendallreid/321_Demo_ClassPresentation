using System;

class Customer
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void PlaceOrder(OrderService orderService)
    {
        orderService.CreateOrder(this);
    }
}

class OrderService
{
    public void CreateOrder(Customer customer)
    {
        Console.WriteLine("Creating order...");

        PaymentService paymentService = new PaymentService();
        bool paid = paymentService.ProcessPayment(customer);

        if (paid)
        {
            EmailService emailService = new EmailService();
            emailService.SendConfirmation(customer);
        }
    }
}

class PaymentService
{
    public bool ProcessPayment(Customer customer)
    {
        Console.WriteLine($"Processing payment for {customer.Name}");
        return true;
    }
}

class EmailService
{
    public void SendConfirmation(Customer customer)
    {
        Console.WriteLine($"Sending confirmation email to {customer.Name}");
    }
}
