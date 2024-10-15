using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Views
{
    using BookMan.ConsoleAppp.Framework;
    using Models;
    internal class BookListView : ViewBase<Book[]>
    {

        public BookListView(Book[] model):base(model)
        {
            
        }

        public override void Render()
        {
            if (((Book[])Model).Length == 0)
            {
                ViewHelp.WriteLine("No book found", ConsoleColor.Yellow);
                return ;
            }

            ViewHelp.WriteLine("THE BOOK LIST",ConsoleColor.Green);
            foreach(Book b in Model as Book[])
            {
                ViewHelp.Write($"{b.Id}", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{b.Title}",b.Reading ? ConsoleColor.Cyan : ConsoleColor.White);

            }
        }
    }
}
