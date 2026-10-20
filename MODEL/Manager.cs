using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketManagementSystem.MODEL
{
    public class Manager
    {

        public int ManagerId { get; set; }
        public string Name { get; set; }
        public Manager()
        {
            ManagerId = 0;
            Name =  "";

        }
        public Manager(int ManagerId, string Name)
        {
            this.ManagerId = ManagerId;
            this.Name = Name;

        }
        public Manager(Manager other)
        {
            ManagerId =other.ManagerId;
            Name = other.Name;

        }
    }
}
