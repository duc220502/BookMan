using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.DataService
{
    using Models;
    internal class Repository
    {
        protected readonly SimpleDataAccess _context ;

        public Repository(SimpleDataAccess context)
        {
            _context = context;
            _context.Load();
        }

        public void SaveChanges()=> _context.SaveChanges(); 
        public List<Book> books => _context.Books;
        public Book[] Select() => _context.Books.ToArray();

        public Book Select(int id)
        {
            foreach(var b in _context.Books)
            {
                if(b.Id == id) return b;
            }
            return null;
        }

        public Book[] Select(string key)
        {
            var temp = new List<Book>();
            var k = key.ToLower();

            foreach(var b in _context.Books)
            {
                bool logic = b.Title.ToLower().Contains(k) || b.Authors.ToLower().Contains(k) || b.Publisher.ToLower().Contains(k);


                if(logic) temp.Add(b);
            }
            return temp.ToArray();
        }

        public  void Insert(Book book)
        {
            var lastIndex = _context.Books.Count - 1;
            var id = lastIndex < 0 ? 1 : _context.Books[lastIndex].Id+1;
            book.Id = id;
            _context.Books.Add(book);
        }

        public bool Delete(int Id)
        {
            var b = Select(Id);
            if(b == null) return false;

            _context.Books.Remove(b);
            return true;    
        }

        public bool Update(int id , Book book)
        {
            var b = Select(id);
            if(b == null) return false;
            b.Authors = book.Authors;
            b.Description = book.Description;
            b.Edition = book.Edition;
            b.File = book.File;
            b.Isbn = book.Isbn;
            b.Publisher = book.Publisher;
            b.Title = book.Title;
            b.Year = book.Year;

            return true;
        }
    }
}
