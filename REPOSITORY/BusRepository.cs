using System;
using System.Collections.Generic;
using System.IO;
using BusTicketManagementSystem.MODEL;

namespace BusTicketManagementSystem.Repository
{
    public class BusRepository
    {
        public List<Bus> Buses { get; set; }

        public BusRepository()
        {
            Buses = new List<Bus>();

            if (File.Exists("buses.txt"))
            {
                StreamReader reader = new StreamReader("buses.txt");

                while (!reader.EndOfStream)
                {
                    int id = int.Parse(reader.ReadLine());
                    string name = reader.ReadLine();
                    string source = reader.ReadLine();
                    string destination = reader.ReadLine();
                    double fare = double.Parse(reader.ReadLine());
                    int seats = int.Parse(reader.ReadLine());

                    Bus bus = new Bus(
                        id, name, source, destination, fare, seats
                    );

                    Buses.Add(bus);
                }

                reader.Close();
            }
            else
            {
                Buses.Add(new Bus(101, "Daewoo", "Lahore",
                    "Islamabad", 2500, 40));

                Buses.Add(new Bus(102, "Faisal Movers", "Lahore",
                    "Multan", 1800, 35));

                Buses.Add(new Bus(103, "Skyways", "Lahore",
                    "Faisalabad", 1000, 30));

                SaveBuses();
            }
        }

        public void AddBus(Bus bus)
        {
            Buses.Add(bus);
            SaveBuses();
        }

        public void SaveBuses()
        {
            StreamWriter writer = new StreamWriter("buses.txt");

            foreach (Bus bus in Buses)
            {
                writer.WriteLine(bus.BusId);
                writer.WriteLine(bus.BusName);
                writer.WriteLine(bus.source);
                writer.WriteLine(bus.destination);
                writer.WriteLine(bus.fare);
                writer.WriteLine(bus.totalseats);
            }

            writer.Close();
        }

        public void ShowAllBuses()
        {
            foreach (Bus bus in Buses)
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
    }

}