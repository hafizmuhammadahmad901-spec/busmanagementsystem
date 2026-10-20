using System.Collections.Generic;
using BusTicketManagementSystem.MODEL;
using BusTicketManagementSystem.Repository;


namespace BusTicketManagementSystem.BUISNESS
{
    public class ManagerService
    {
        private BusRepository busRepository;
        private TicketRepository ticketRepository;

        public ManagerService(BusRepository busRepo, TicketRepository ticketRepo)
        {
            busRepository = busRepo;
            ticketRepository = ticketRepo;
        }
        public bool Login(string username, string password)
        {
            if (username == null || password == null) 
            {
                return false;
            
            }
            if(username == "manager" && password == "manager1234")
            {
                return true;
            }
            return false;
        }
        public List<Bus> GetAllBuses()
        {
            return busRepository.Buses;

        }
        public List<Ticket> GetALLTickets()
        {
            return ticketRepository.Tickets;
        }
        public void UpdateBusFare(int busid,double newfare)
        {
            foreach(Bus bus in busRepository.Buses)
            {
                if(bus.BusId == busid)
                {
                    bus.fare = newfare; 
                }
            }
        }


    }
}
