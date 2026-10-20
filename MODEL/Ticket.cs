using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketManagementSystem.MODEL
{
    public class Ticket
    {

        public int TicketId { get; set; }
        public int BusId {  get; set; }
        public string customer_name {  get; set; }
        public int seat_number { get; set; }
        public double fare {  get; set; }

        //Default constructor
        public Ticket()
        {
            TicketId = 0;
            BusId = 0;
            customer_name = "";
            seat_number = 0;
            fare = 0;





        }
        public Ticket(int TicketId, int BusId, string customer_name, int seat_number,double fare)
        {
            this.TicketId = TicketId;
            this .BusId = BusId;
            this.customer_name = customer_name;
            this.seat_number  = seat_number;
            this.fare = fare;

        }

        // COPY CONSTRUCTOR
        public Ticket(Ticket other)
        {
            TicketId = other.TicketId;
            BusId =other.BusId;
            customer_name =other.customer_name;
            seat_number =other.seat_number;
            fare =other.fare;
   
        }
    }
}
