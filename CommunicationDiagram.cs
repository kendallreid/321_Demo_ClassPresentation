using System;

class User
{
    public string Name { get; set; }

    public User(string name)
    {
        Name = name;
    }

    public void BookTicket(BookingService bookingService)
    {
        bookingService.CreateBooking(this);
    }
}

class BookingService
{
    public void CreateBooking(User user)
    {
        Console.WriteLine("Starting booking...");

        SeatService seatService = new SeatService();
        bool seatAvailable = seatService.ReserveSeat();

        if (seatAvailable)
        {
            PaymentService paymentService = new PaymentService();
            bool paid = paymentService.ProcessPayment();

            if (paid)
            {
                TicketService ticketService = new TicketService();
                ticketService.GenerateTicket(user);
            }
        }
    }
}

class SeatService
{
    public bool ReserveSeat()
    {
        Console.WriteLine("Reserving seat...");
        return true;
    }
}

class PaymentService
{
    public bool ProcessPayment()
    {
        Console.WriteLine("Processing payment...");
        return true;
    }
}

class TicketService
{
    public void GenerateTicket(User user)
    {
        Console.WriteLine($"Ticket generated for {user.Name}");
    }
}
