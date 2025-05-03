using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kpl_tubes.Model;

namespace Kpl_tubes.Services
{


    namespace kpl_tubes.Services
    {
        public interface IBookService
        {
            List<Book> GetAll();
            void Add(Book book);
            void Save();
        }
    }
}
