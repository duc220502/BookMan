using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Framework
{
    public class Parameter
    {
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public string this[string key] 
        {
            get
            {
                if (_parameters.ContainsKey(key))
                    return _parameters[key];
                else return null;
            }
            
            set => _parameters[key] = value;
        
        }

        public bool ContainKeys(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public Parameter(string parameter)
        {
           var pairs = parameter.Split(new[] {'&'} , StringSplitOptions.RemoveEmptyEntries);

            foreach (var pair in pairs)
            {
                var p = pair.Split('=');
                if(p.Length == 2)
                {
                    var key = p[0].Trim();
                    var value = p[1].Trim();
                    this[key] = value;
                }
            }
        }
    }
}
