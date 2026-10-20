namespace BusTicketManagementSystem.MODEL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string name)
        {
            CustomerId = id;
            Name = name;
        }

        public Customer(int id, string name, string username, string password)
        {
            CustomerId = id;
            Name = name;
            Username = username;
            Password = password;
        }

        public Customer(Customer other)
        {
            CustomerId = other.CustomerId;
            Name = other.Name;
            Username = other.Username;
            Password = other.Password;
        }
    }

}