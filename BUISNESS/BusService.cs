using System.Collections.Generic;
using BusTicketManagementSystem.MODEL;
using BusTicketManagementSystem.Repository;




namespace BusTicketManagementSystem.BUISNESS
{
   public class BusService
    {
        private BusRepository busRepository;
        public  BusService(BusRepository repository)
        {
            busRepository = repository;

        }
        public void AddBus(Bus bus)
        {
            busRepository.AddBus(bus);

        }
        public List<Bus> GetAllBuses()
        {
            return busRepository.Buses;
        }
        

    }
}
