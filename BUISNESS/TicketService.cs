
using System.Collections.Generic;
using BusTicketManagementSystem.MODEL;
using BusTicketManagementSystem.Repository;


namespace BusTicketManagementSystem.BUISNESS
{
    public class TicketService
    {

        private TicketRepository ticketRepository;

        public TicketService(TicketRepository repository)
        {
           ticketRepository = repository;


        }
        public void BookTicket(Ticket ticket)
        {
            ticketRepository.AddTicket(ticket);

        }
        public List<Ticket> GetAllTickets()
        {
            return  ticketRepository.Tickets;
        }
        
    }
}
