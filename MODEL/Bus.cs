using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketManagementSystem.MODEL
{
    
    
    public class Bus
    {
    

        public int BusId { get; set; }
        public string BusName { get; set; }
        public string source {  get; set; }
        public string destination {  get; set; }
        public double fare {  get; set; }
        public int totalseats {  get; set; }

        // DEFAULT CONSTRUCTOR
        public Bus()
        {
            BusId = 0;
            BusName = "";
            source = "";
            destination = "";
            fare = 0;
            totalseats = 0;

        }
        // PARAMETRIZED CONSTRUCTOR

        public Bus(int BusId,string BusName,string source,string destination, double fare, int totalseats)
        {
            this.BusId = BusId;
            this.BusName = BusName;
            this.source = source;
            this.destination = destination;
            this.fare = fare;
            this.totalseats = totalseats;

        }

        public Bus(Bus other)
        {
            BusId = other.BusId;
            BusName = other.BusName;
            source = other.source;
            destination = other.destination;
            fare = other.fare;
            totalseats = other.totalseats;

        }
            


    }

}

