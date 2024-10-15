using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.DataService
{
    using Models;
    internal class SimpleDataAccess
    {
        public SimpleDataAccess() { }   
        public List<Book> Books { get; set; }
        public void Load()
        {
            Books = new List<Book>()
            {
                new Book{Id = 1 ,Title = "A new book 1"},
                new Book{Id = 2 ,Title = "A new book 2"},
                new Book{Id = 3 ,Title = "A new book 3"}
            };
        }
        public void SaveChanges()
        {

        }
    }
}
