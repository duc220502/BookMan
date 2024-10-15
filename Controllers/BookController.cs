using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Controllers
{
    using BookMan.ConsoleAppp.Framework;
    using DataService;
    using Models;
    using Views;
    internal class BookController : ControllerBase
    {
        protected Repository repository;
        public BookController(SimpleDataAccess context)
        {
            repository = new Repository(context);
        }
        public void Single(int id, string path = "")
        {
            var model = repository.Select(id);
            Render(new BookSingleView(model), path);
        }
        public void Create(Book book = null)
        {
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }

            repository.Insert(book);
            Success("Book Created!");
        }

        public void Update(int id)
        {
            var model = repository.Select(id);
            Render(new BookUpdateView(model));
        }

        public void List(string path = "")
        {
            var model = repository.Select();
            Render(new BookListView(model), path);
        }
        public void Delete(int id , bool process = false)
        {
            if (process == false)
            {
                var b = repository.Select(id);
                Confirmation($"Do you want to delete this book ({b.Title}) ?", backroute:$"do delete ? id = {b.Id}");

            }
            else
            {
                repository.Delete(id);
                Success("Book Deleted");
                
            }
        }

        public void Filter (string key)
        {
            var model = repository.Select(key);

            if(model.Length == 0)
            {
                Information("No matched book found");
            }else
            {
                Render(new BookListView(model));
            }

        }

    }
}
