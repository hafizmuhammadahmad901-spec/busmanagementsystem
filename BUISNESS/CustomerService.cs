using System.Collections.Generic;
using BusTicketManagementSystem.MODEL;
using BusTicketManagementSystem.Repository;

namespace BusTicketManagementSystem.BUISNESS
{
    public class CustomerService
    {
        private BusRepository busRepository;
        private TicketRepository ticketRepository;
        private CustomerRepository customerRepository;

        public CustomerService(
            BusRepository busRepo,
            TicketRepository ticketRepo,
            CustomerRepository customerRepo)
        {
            busRepository = busRepo;
            ticketRepository = ticketRepo;
            customerRepository = customerRepo;
        }

        public bool SignUp(Customer customer)
        {
            foreach (Customer c in customerRepository.Customers)
            {
                if (c.Username == customer.Username)
                {
                    return false;
                }
            }

            customerRepository.AddCustomer(customer);
            return true;
        }

        public Customer Login(string username, string password)
        {
            foreach (Customer c in customerRepository.Customers)
            {
                if (c.Username == username && c.Password == password)
                {
                    return c;
                }
            }

            return null;
        }

        public List<Bus> GetAvailableBuses()
        {
            return busRepository.Buses;
        }

        public List<Ticket> GetMyTickets(string customerName)
        {
            List<Ticket> myTickets = new List<Ticket>();

            foreach (Ticket ticket in ticketRepository.Tickets)
            {
                if (ticket.customer_name == customerName)
                {
                    myTickets.Add(ticket);
                }
            }

            return myTickets;
        }

        public bool BookTicket(Ticket ticket)
        {
            foreach (Ticket oldTicket in ticketRepository.Tickets)
            {
                if (oldTicket.BusId == ticket.BusId &&
                    oldTicket.seat_number == ticket.seat_number)
                {
                    return false;
                }
            }

            ticketRepository.AddTicket(ticket);
            return true;
        }

        public void CancelTicket(int ticketId)
        {
            for (int i = 0; i < ticketRepository.Tickets.Count; i++)
            {
                if (ticketRepository.Tickets[i].TicketId == ticketId)
                {
                    ticketRepository.Tickets.RemoveAt(i);
                    break;
                }
            }
        }
    }

}