using System.Collections.Generic;
using BusTicketManagementSystem.MODEL;
using BusTicketManagementSystem.Repository;


namespace BusTicketManagementSystem.BUISNESS
{
    public  class AdminService
    {
        private BusRepository busRepository;
        private TicketRepository ticketRepository;
        public AdminService(BusRepository busRepo, TicketRepository ticketRepo)
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
            if (username == "admin" && password == "admin1234")
            {
                return true;
            }
            return false;
        }
        public void AddBus(Bus bus)
        {
            busRepository.AddBus(bus);

        }
        public List<Bus> GetAllBuses()
        {
            return busRepository.Buses;

        }
        public List<Ticket> GetAllTickets()
        { 
            return ticketRepository.Tickets; 
        }
    }
}
