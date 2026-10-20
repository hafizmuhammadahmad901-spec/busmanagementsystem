using System;
using System.Collections.Generic;
using BusTicketManagementSystem.MODEL;
using BusTicketManagementSystem.BUISNESS;
using BusTicketManagementSystem.Repository;

namespace BusTicketManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            BusRepository busRepository = new BusRepository();
            TicketRepository ticketRepository = new TicketRepository();
            CustomerRepository customerRepository = new CustomerRepository();

            BusService busService = new BusService(busRepository);
            TicketService ticketService = new TicketService(ticketRepository);

            AdminService adminService =
                new AdminService(busRepository, ticketRepository);

            ManagerService managerService =
                new ManagerService(busRepository, ticketRepository);

            CustomerService customerService = new CustomerService(
                busRepository,
                ticketRepository,
                customerRepository
            );

            Console.WriteLine("Bus Ticket Management System");

            int choice;

            do
            {
                Console.WriteLine("\n===== MAIN MENU =====");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Manager");
                Console.WriteLine("3. Customer");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter Admin Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter Admin Password: ");
                    string password = Console.ReadLine();

                    if (adminService.Login(username, password))
                    {
                        Console.WriteLine("Admin Login Successful!");
                        AdminMenu(adminService);
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password!");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Manager Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter Manager Password: ");
                    string password = Console.ReadLine();

                    if (managerService.Login(username, password))
                    {
                        Console.WriteLine("Manager Login Successful!");
                        ManagerMenu(managerService);
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password!");
                    }
                }
                else if (choice == 3)
                {
                    CustomerMenu(customerService);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Thank you for using the system!");
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }

            } while (choice != 4);
        }

        static void AdminMenu(AdminService adminService)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== ADMIN MENU =====");
                Console.WriteLine("1. View All Buses");
                Console.WriteLine("2. Add New Bus");
                Console.WriteLine("3. View All Tickets");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    foreach (Bus bus in adminService.GetAllBuses())
                    {
                        Console.WriteLine(
                            bus.BusId + " - " +
                            bus.BusName + " - " +
                            bus.source + " to " +
                            bus.destination + " - Rs. " +
                            bus.fare
                        );
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Bus ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    bool idExists = false;

                    foreach (Bus bus in adminService.GetAllBuses())
                    {
                        if (bus.BusId == id)
                        {
                            idExists = true;
                            break;
                        }
                    }

                    if (id <= 0 || idExists)
                    {
                        Console.WriteLine(
                            "Invalid or already existing Bus ID!"
                        );
                    }
                    else
                    {
                        Console.Write("Enter Bus Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Source: ");
                        string source = Console.ReadLine();

                        Console.Write("Enter Destination: ");
                        string destination = Console.ReadLine();

                        Console.Write("Enter Fare: ");
                        double fare = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Total Seats: ");
                        int seats = Convert.ToInt32(Console.ReadLine());

                        if (fare <= 0 || seats <= 0)
                        {
                            Console.WriteLine(
                                "Fare and seats must be greater than zero!"
                            );
                        }
                        else
                        {
                            Bus newBus = new Bus(
                                id, name, source, destination, fare, seats
                            );

                            adminService.AddBus(newBus);
                            Console.WriteLine("Bus added successfully!");
                        }
                    }
                }
                else if (choice == 3)
                {
                    List<Ticket> tickets = adminService.GetAllTickets();

                    if (tickets.Count == 0)
                    {
                        Console.WriteLine("No tickets booked yet.");
                    }
                    else
                    {
                        foreach (Ticket ticket in tickets)
                        {
                            Console.WriteLine(
                                "Ticket ID: " + ticket.TicketId +
                                " | Bus ID: " + ticket.BusId +
                                " | Customer: " + ticket.customer_name +
                                " | Seat: " + ticket.seat_number +
                                " | Fare: Rs. " + ticket.fare
                            );
                        }
                    }
                }
                else if (choice != 4)
                {
                    Console.WriteLine("Invalid choice!");
                }

            } while (choice != 4);
        }

        static void ManagerMenu(ManagerService managerService)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== MANAGER MENU =====");
                Console.WriteLine("1. View All Buses");
                Console.WriteLine("2. Update Bus Fare");
                Console.WriteLine("3. View All Bookings");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    foreach (Bus bus in managerService.GetAllBuses())
                    {
                        Console.WriteLine(
                            bus.BusId + " - " +
                            bus.BusName + " - " +
                            bus.source + " to " +
                            bus.destination + " - Rs. " +
                            bus.fare
                        );
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Bus ID: ");
                    int busId = Convert.ToInt32(Console.ReadLine());

                    bool busExists = false;

                    foreach (Bus bus in managerService.GetAllBuses())
                    {
                        if (bus.BusId == busId)
                        {
                            busExists = true;
                            break;
                        }
                    }

                    if (!busExists)
                    {
                        Console.WriteLine("Bus not found!");
                    }
                    else
                    {
                        Console.Write("Enter New Fare: ");
                        double newFare =
                            Convert.ToDouble(Console.ReadLine());

                        if (newFare <= 0)
                        {
                            Console.WriteLine(
                                "Fare must be greater than zero!"
                            );
                        }
                        else
                        {
                            managerService.UpdateBusFare(busId, newFare);
                            Console.WriteLine("Fare update completed.");
                        }
                    }
                }
                else if (choice == 3)
                {
                    List<Ticket> tickets = managerService.GetALLTickets();

                    if (tickets.Count == 0)
                    {
                        Console.WriteLine("No bookings available yet.");
                    }
                    else
                    {
                        foreach (Ticket ticket in tickets)
                        {
                            Console.WriteLine(
                                "Ticket ID: " + ticket.TicketId +
                                " | Customer: " + ticket.customer_name +
                                " | Bus ID: " + ticket.BusId +
                                " | Seat: " + ticket.seat_number +
                                " | Fare: Rs. " + ticket.fare
                            );
                        }
                    }
                }
                else if (choice != 4)
                {
                    Console.WriteLine("Invalid choice!");
                }

            } while (choice != 4);
        }

        static void CustomerMenu(CustomerService customerService)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== CUSTOMER MENU =====");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Back to Main Menu");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter Customer ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    Customer customer = new Customer(
                        id, name, username, password
                    );

                    if (customerService.SignUp(customer))
                    {
                        Console.WriteLine("Signup successful!");
                    }
                    else
                    {
                        Console.WriteLine("Username already exists!");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    Customer customer =
                        customerService.Login(username, password);

                    if (customer != null)
                    {
                        Console.WriteLine("Login successful!");
                        CustomerDashboard(customerService, customer);
                    }
                    else
                    {
                        Console.WriteLine(
                            "Invalid username or password!"
                        );
                    }
                }
                else if (choice != 3)
                {
                    Console.WriteLine("Invalid choice!");
                }

            } while (choice != 3);
        }

        static void CustomerDashboard(
            CustomerService customerService, Customer customer)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== CUSTOMER DASHBOARD =====");
                Console.WriteLine("Welcome, " + customer.Name);
                Console.WriteLine("1. View All Buses");
                Console.WriteLine("2. Book Ticket");
                Console.WriteLine("3. View My Tickets");
                Console.WriteLine("4. Logout");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    foreach (Bus bus in customerService.GetAvailableBuses())
                    {
                        Console.WriteLine(
                            bus.BusId + " - " +
                            bus.BusName + " - " +
                            bus.source + " to " +
                            bus.destination + " - Rs. " +
                            bus.fare
                        );
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Ticket ID: ");
                    int ticketId = Convert.ToInt32(Console.ReadLine());

                    bool ticketIdExists = false;

                    foreach (Ticket oldTicket in
                        customerService.GetMyTickets(customer.Name))
                    {
                        if (oldTicket.TicketId == ticketId)
                        {
                            ticketIdExists = true;
                            break;
                        }
                    }

                    Console.Write("Enter Bus ID: ");
                    int busId = Convert.ToInt32(Console.ReadLine());

                    Bus selectedBus = null;

                    foreach (Bus bus in customerService.GetAvailableBuses())
                    {
                        if (bus.BusId == busId)
                        {
                            selectedBus = bus;
                            break;
                        }
                    }

                    if (ticketId <= 0 || ticketIdExists)
                    {
                        Console.WriteLine(
                            "Invalid or already used Ticket ID!"
                        );
                    }
                    else if (selectedBus == null)
                    {
                        Console.WriteLine("Bus not found!");
                    }
                    else
                    {
                        Console.Write("Enter Seat Number: ");
                        int seatNumber =
                            Convert.ToInt32(Console.ReadLine());

                        if (seatNumber <= 0 ||
                            seatNumber > selectedBus.totalseats)
                        {
                            Console.WriteLine("Invalid seat number!");
                        }
                        else
                        {
                            Ticket ticket = new Ticket(
                                ticketId,
                                busId,
                                customer.Name,
                                seatNumber,
                                selectedBus.fare
                            );

                            bool booked =
                                customerService.BookTicket(ticket);

                            if (booked)
                            {
                                Console.WriteLine(
                                    "Ticket booked successfully!"
                                );
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Sorry! This seat is already booked on this bus."
                                );
                            }
                        }
                    }
                }
                else if (choice == 3)
                {
                    List<Ticket> myTickets =
                        customerService.GetMyTickets(customer.Name);

                    if (myTickets.Count == 0)
                    {
                        Console.WriteLine("You have no tickets.");
                    }
                    else
                    {
                        foreach (Ticket ticket in myTickets)
                        {
                            Console.WriteLine(
                                "Ticket ID: " + ticket.TicketId +
                                " | Bus ID: " + ticket.BusId +
                                " | Seat: " + ticket.seat_number +
                                " | Fare: Rs. " + ticket.fare
                            );
                        }
                    }
                }
                else if (choice != 4)
                {
                    Console.WriteLine("Invalid choice!");
                }

            } while (choice != 4);
        }
    }
}