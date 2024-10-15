namespace BookMan.ConsoleAppp
{

    using Controllers;
    using System.Runtime.CompilerServices;
    using DataService;
    using Framework;
    using BookMan.ConsoleAppp.Models;

    internal partial class Program
    {
         static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConfigRouter();

            while (true)
            {
                ViewHelp.Write("# Request >>>", ConsoleColor.Green);
                string request = Console.ReadLine();
                Router.Instance.Forward(request);
                Console.WriteLine();
            }
           
        }
        
        private static void About(Parameter parameter)
        {
            ViewHelp.WriteLine("Book manager version 1.0",ConsoleColor.Green);
            ViewHelp.WriteLine("By anhduc@gmail.com",ConsoleColor.Magenta);
        }
       
        private static void Help(Parameter parameter)
        {
            if(parameter == null)
            {
                ViewHelp.WriteLine("Supported Commands", ConsoleColor.Green);
                ViewHelp.WriteLine(Router.Instance.GetRoutes(), ConsoleColor.Yellow);
                ViewHelp.WriteLine("Type : help ? cmd = <command> to get command details",ConsoleColor.Cyan);
                return;

            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            var command = parameter["cmd"].ToLower();
            ViewHelp.WriteLine(Router.Instance.GetHelp(command));
        }
    }
}
