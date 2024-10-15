using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleAppp.Framework
{
    internal static class ViewHelp
    {
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
                Console.ResetColor();
        }

        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
                Console.ResetColor(); ;
        }
        public static bool InputBool(string label, ConsoleColor lableColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            ViewHelp.Write($"{label} :  ", lableColor);
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            bool @char = key.KeyChar.Equals("y") ? true : false;
            return @char;
        }

        public static bool InputBool (string label , bool oldValue , ConsoleColor labelColor = ConsoleColor.Magenta , ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} : " , labelColor);
            WriteLine($"{oldValue}", ConsoleColor.Yellow);
            Write("New value>>", ConsoleColor.Green);

            Console.ForegroundColor = valueColor;
            string str = Console.ReadLine();
            if(string.IsNullOrEmpty(str))
                return oldValue;

            return str.ToBool();

        }

        public static int InputInt(string lable, ConsoleColor lableColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            while (true)
            {
                var str = InputString(lable, lableColor, valueColor);
                var result = int.TryParse(str, out int value);
                if (result)
                    return value;
            }

        }

        public static int InputInt(string lable , int oldValue , ConsoleColor lableColor = ConsoleColor.Magenta,ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{lable}", lableColor);
            WriteLine($"{oldValue}",ConsoleColor.Yellow);
            Write("New value >>",ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str)) return oldValue;
            if (str.ToInt(out int i)) return i; 

            return oldValue;

        }

        public static string InputString(string lable, ConsoleColor lableColor = ConsoleColor.Magenta, ConsoleColor valueColor = ConsoleColor.White)
        {
            ViewHelp.Write($"{lable} : ", lableColor, false);
            Console.ForegroundColor = valueColor;
            string value = Console.ReadLine();
            return value;
        }
        public static string InputString(string label , string oldValue , ConsoleColor labelColor = ConsoleColor.Magenta , ConsoleColor valueColor = ConsoleColor.White)
        {
            Write($"{label} : ", labelColor);
            WriteLine(oldValue , ConsoleColor.Yellow);
            Write("New value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valueColor;
            string newValue = Console.ReadLine();
            return string.IsNullOrEmpty(newValue.Trim())?oldValue : newValue;
        }
    }
}
