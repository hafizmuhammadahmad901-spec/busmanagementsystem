using System.Collections.Generic;
using System.IO;
using BusTicketManagementSystem.MODEL;

namespace BusTicketManagementSystem.Repository
{
    public class TicketRepository
    {
        public List<Ticket> Tickets { get; set; }

        public TicketRepository()
        {
            Tickets = new List<Ticket>();

            if (File.Exists("tickets.txt"))
            {
                StreamReader reader = new StreamReader("tickets.txt");

                while (!reader.EndOfStream)
                {
                    int ticketId = int.Parse(reader.ReadLine());
                    int busId = int.Parse(reader.ReadLine());
                    string customerName = reader.ReadLine();
                    int seatNumber = int.Parse(reader.ReadLine());
                    double fare = double.Parse(reader.ReadLine());

                    Ticket ticket = new Ticket(
                        ticketId, busId, customerName, seatNumber, fare
                    );

                    Tickets.Add(ticket);
                }

                reader.Close();
            }
        }

        public void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);

            StreamWriter writer = new StreamWriter("tickets.txt");

            foreach (Ticket t in Tickets)
            {
                writer.WriteLine(t.TicketId);
                writer.WriteLine(t.BusId);
                writer.WriteLine(t.customer_name);
                writer.WriteLine(t.seat_number);
                writer.WriteLine(t.fare);
            }

            writer.Close();
        }
        public void SaveTickets()
        {
            StreamWriter writer = new StreamWriter("tickets.txt");

            foreach (Ticket t in Tickets)
            {
                writer.WriteLine(t.TicketId);
                writer.WriteLine(t.BusId);
                writer.WriteLine(t.customer_name);
                writer.WriteLine(t.seat_number);
                writer.WriteLine(t.fare);
            }

            writer.Close();
        }
    }

}