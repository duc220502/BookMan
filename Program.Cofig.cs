using BookMan.ConsoleAppp.Controllers;
using BookMan.ConsoleAppp.DataService;
using BookMan.ConsoleAppp.Framework;
using BookMan.ConsoleAppp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp
{
    internal partial class Program
    {
        private static void ConfigRouter()
        {
            SimpleDataAccess simpleDataAccess = new SimpleDataAccess();


            BookController controller = new BookController(simpleDataAccess);

            Router r = Router.Instance;

            r.Register("about", About);
            r.Register("help", Help);
            //r.Register(route: "create", action: p => controller.Update(p["id"].ToInt()), help: "[update ? id = <value>]\r\ntim và cập nhật danh sách");
            r.Register(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id = <value>] \r \n hiển thị một cuốn sách theo id");

            r.Register("list", action: p => controller.List());
            r.Register("create", action: p => controller.Create());

            r.Register("single file", action: p => controller.Single(p["id"].ToInt(), p["path"]), help: "[singhle file ? id = <value> & path = <value> ]");

            r.Register(route: "do create", action: p => controller.Create(ToBook(p)), help: "This route should be used only in code");

            r.Register(route: "delete", action: p => controller.Delete(p["id"].ToInt()),help: "delete ? id = <value>");
            r.Register(route: "do delete" , action:p=>controller.Delete(p["id"].ToInt(),true),help:"This route should be used only in code ");

            r.Register(route: "filter", action: p => controller.Filter(p["key"]), help: "[filter ? key = <value>] rnTim sach theo tu khoa");
            Book ToBook(Parameter p)
            {
                Book book = new Book();
                if (p.ContainKeys("id")) book.Id = p["id"].ToInt();
                if (p.ContainKeys("authors")) book.Authors = p["authors"];
                if (p.ContainKeys("publisher")) book.Publisher = p["publisher"];
                if (p.ContainKeys("year")) book.Year = p["year"].ToInt();
                if (p.ContainKeys("edition")) book.Edition = p["edition"].ToInt();
                if (p.ContainKeys("tags")) book.Edition = p["tags"].ToInt();
                if (p.ContainKeys("description")) book.Edition = p["description"].ToInt();
                if (p.ContainKeys("file")) book.File = p["file"];
                if (p.ContainKeys("rating")) book.File = p["rating"];
                if (p.ContainKeys("reading")) book.File = p["reading"];
                return book;


            }
        }
    }
}
