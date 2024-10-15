using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Framework
{
    using RoutingTable = Dictionary<string, ControllerAction>;
    public delegate void ControllerAction(Parameter parameter = null);
    public class Router
    {
        private static Router _instance;
        private readonly RoutingTable _routingTable;
        private readonly Dictionary<string, string> _helpTable;
        public static Router Instance => _instance ?? (_instance = new Router());
        private Router() 
        {
            _routingTable = new RoutingTable();
            _helpTable = new Dictionary<string, string>();
        }

        public string GetRoutes()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var k in _routingTable.Keys)
                sb.Append($"{k}, ");

            return sb.ToString();
        }
        public string GetHelp(string key)
        {
            if (_helpTable.ContainsKey(key))
                return _helpTable[key];
            else
                return "Documentation not ready yet";
        }

        public void Register(string route, ControllerAction action, string help = "")
        {
            if (!_routingTable.ContainsKey(route))
            {
                _routingTable[route] = action;
                _helpTable[route] = help;
            }
        }

        /*public void Forward(string Request)
        
        {
            var req = new Request(Request);
            if (!_routingTable.ContainsKey(req.Route))
                throw new Exception("Command not found!");

            if (req.Parameter == null)
                _routingTable[req.Route]?.Invoke();
            else
                _routingTable[req.Route]?.Invoke(req.Parameter);
                
        }*/
        public void Forward(string Request)
        {
            var req = new Request(Request);
            Console.WriteLine($"Routing to: {req.Route}");

            if (!_routingTable.ContainsKey(req.Route))
            {
                Console.WriteLine("Command not found!");
                throw new Exception("Command not found!");
            }

            Console.WriteLine("Executing command...");
            if (req.Parameter == null)
                _routingTable[req.Route]?.Invoke();
            else
                _routingTable[req.Route]?.Invoke(req.Parameter);

            Console.WriteLine("Command executed.");
        }

        private class Request
        {
            public string Route { get; private set; }

            public Parameter Parameter { get; private set; }

            public Request(string request)
            {
               Analyze(request);
            }

            private void Analyze(string request)
            {
                Console.WriteLine($"{request}");
                var firstIndex = request.IndexOf('?');
                if (firstIndex <0)
                {
                    Route = request.ToLower().Trim();
                }else
                {
                    if (firstIndex <= 1) throw new Exception("Invalid request parameter");

                    var tokens = request.Split(new[] { '?' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    Route = tokens[0].ToLower().Trim();

                    var parameterPart = request.Substring(firstIndex+1).Trim();

                    Parameter = new Parameter(parameterPart);
                }
            }

        }
    }
}
