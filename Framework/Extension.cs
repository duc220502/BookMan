using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Framework
{
    public static class Extension
    {
        public static int ToInt (this string value)
        {
            return int.Parse (value);
        }

        public static bool ToInt(this string value , out int result)
        {
            return int.TryParse (value , out result);
        }

        public static bool ToBool(this string value)
        {
            var v = value.ToLower ();
            if(v == "y" || v == "true")
                return true;

            return false;
        }

        public static string ToString(this bool value,string format)
        {
            if (format == "y/n")
                return value ? "yes" : "no";

            if (format == "c/k")
                return value ? "co" : "khong";

            return value? "false" : "false";
        }
    }
}
