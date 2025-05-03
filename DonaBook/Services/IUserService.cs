using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDonationConsole.Models;
using Kpl_tubes.Model;

namespace kpl_tubes.Services
{
    public interface IUserService
    {
        void LoadUsers();
        User? Authenticate(string email, string password);
        List<User> GetAllUsers();
    }
}

