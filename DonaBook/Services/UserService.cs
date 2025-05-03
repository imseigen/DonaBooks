using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using BookDonationConsole.Models;
using Kpl_tubes.Model;

namespace Kpl_tubes.Services
{
    public interface IUserService
    {
        void LoadUsers();
        User? Authenticate(string email, string password);
        List<User> GetAllUsers();
    }

    public class UserService : IUserService
    {
        private readonly string filePath = "data/users.json";
        private List<User> users = new();

        public UserService()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            if (!File.Exists(filePath))
            {
                users = new List<User>();
                return;
            }

            var json = File.ReadAllText(filePath);
            // Deserialize JSON jadi List<Dictionary<string, object>>
            var rawData = JsonSerializer
                .Deserialize<List<Dictionary<string, object>>>(json)
                ?? new List<Dictionary<string, object>>();

            users = rawData
                // Spesifikan TSource=Dictionary<string, object>, TResult=User?
                .Select<Dictionary<string, object>, User?>(u =>
                {
                    var role = u["Role"]?.ToString() ?? "";
                    var id = Convert.ToInt32(u["Id"]);
                    var name = u["Name"]?.ToString() ?? "";
                    var email = u["Email"]?.ToString() ?? "";
                    var address = u["Address"]?.ToString() ?? "";
                    var password = u["Password"]?.ToString() ?? "";
                    var contact = u["Contact"]?.ToString() ?? "";

                    return role.ToLower() switch
                    {
                        "donatur" => new Donatur(id, name, email, address, password, contact),
                        "penerima" => new Penerima(id, name, email, address, password, contact),
                        "volunteer" => new Volunteer(id, name, email, address, password, contact),
                        _ => null
                    };
                })
                .Where(u => u != null)
                .Cast<User>()
                .ToList();
        }

        public User? Authenticate(string email, string password)
        {
            return users
                .FirstOrDefault(u =>
                    string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase)
                    && u.Password == password
                );
        }

        public List<User> GetAllUsers() => users;
    }
}
