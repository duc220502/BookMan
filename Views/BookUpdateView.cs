using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Views
{
    using BookMan.ConsoleAppp.Framework;
    using Models;
    internal class BookUpdateView: ViewBase<Book>
    {

        public BookUpdateView(Book model):base(model)
        {
            
        }

        public override void Render()
        {
            ViewHelp.WriteLine("Update Book Information" , ConsoleColor.Green);

            var model = Model as Book;
            var authors = ViewHelp.InputString("Authors", model.Authors);
            var title = ViewHelp.InputString("Title", model.Title);
            var publisher = ViewHelp.InputString("Publisher", model.Publisher);
            var isbn = ViewHelp.InputString("Isbn", model.Isbn);
            var tags = ViewHelp.InputString("Tags", model.Tags);
            var description = ViewHelp.InputString("Description", model.Description);
            var file = ViewHelp.InputString("File", model.File);
            var year = ViewHelp.InputInt("Year" , model.Year);
            var edition = ViewHelp.InputInt("Edition", model.Edition);
            var rating = ViewHelp.InputInt("Rate", model.Rating);
            var reading = ViewHelp.InputBool("Reading", model.Reading);
        }

    }
}
