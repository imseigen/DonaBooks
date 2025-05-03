using BookDonationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpl_tubes.Model
{
    public class Donatur : User
    {
        public Donatur(int id, string name, string email, string address, string password, string contact)
            : base(id, name, email, address, password, contact, "donatur") { }
    }
}

