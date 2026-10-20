using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketManagementSystem.MODEL
{
    public class Admin
    {
        public int AdminId { get; set; }

        public string Name { get; set; }

        public Admin()
        {
            AdminId = 0;
            Name = "";
        }
        public Admin(int AdminId, string Name)
        {
            this.AdminId = AdminId;
            this.Name = Name;
        }
        public Admin(Admin other)
        {
            AdminId = other.AdminId;
            Name = other.Name;

        }

    }



}
