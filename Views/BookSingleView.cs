using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Views
{
    using Models;
    using Framework;
    internal class BookSingleView:ViewBase<Book>
    {

        public BookSingleView(Book model):base(model)
        {
           
        }

        public override void Render()
        {
            if(base.Model  == null)
            {
                ViewHelp.WriteLine("No book found , Sorry", ConsoleColor.Red);
                return;

            }

            ViewHelp.WriteLine("Book Detail Information", ConsoleColor.Green);
            var Model = base.Model as Book;
            Console.WriteLine($"Author :   {Model.Authors}");
            Console.WriteLine($"Title  :   {Model.Title}");
            Console.WriteLine($"Publisher  :   {Model.Publisher}");
            Console.WriteLine($"Year  :   {Model.Year}");
            Console.WriteLine($"Edition  :   {Model.Edition}");
            Console.WriteLine($"Isbn  :   {Model.Isbn}");
            Console.WriteLine($"Tags  :   {Model.Description}");
            Console.WriteLine($"Rating  :   {Model.Rating}");
            Console.WriteLine($"Reading  :   {Model.Reading}");
            Console.WriteLine($"File  :   {Model.File}");
            Console.WriteLine($"Isbn  :   {Model.FileName}");

        } 
       

    }
}
