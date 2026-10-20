using System.Collections.Generic;
using System.IO;
using BusTicketManagementSystem.MODEL;

namespace BusTicketManagementSystem.Repository
{
    public class CustomerRepository
    {
        public List<Customer> Customers { get; set; }

        public CustomerRepository()
        {
            Customers = new List<Customer>();

            if (File.Exists("customers.txt"))
            {
                StreamReader reader = new StreamReader("customers.txt");

                while (!reader.EndOfStream)
                {
                    int id = int.Parse(reader.ReadLine());
                    string name = reader.ReadLine();
                    string username = reader.ReadLine();
                    string password = reader.ReadLine();

                    Customer customer = new Customer(
                        id, name, username, password
                    );

                    Customers.Add(customer);
                }

                reader.Close();
            }
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);

            StreamWriter writer = new StreamWriter("customers.txt");

            foreach (Customer c in Customers)
            {
                writer.WriteLine(c.CustomerId);
                writer.WriteLine(c.Name);
                writer.WriteLine(c.Username);
                writer.WriteLine(c.Password);
            }

            writer.Close();
        }
    }

}