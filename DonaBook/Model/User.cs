namespace BookDonationConsole.Models
{
    public abstract class User
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Address { get; }
        public string Password { get; }
        public string Contact { get; }
        public string Role { get; }

        protected User(int id, string name, string email, string address, string password, string contact, string role)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Password = password;
            Contact = contact;
            Role = role;
        }
    }
}
