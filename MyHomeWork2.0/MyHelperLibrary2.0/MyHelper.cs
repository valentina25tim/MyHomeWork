using System;

namespace MyHelperLibrary2._0
{
    public class MyHelper
    {
        public static void PrintWithColor(string message, ConsoleColor color, bool newLine)
        {
            var s = newLine ? "\n" : "";
            Console.ForegroundColor = color;
            Console.Write($"{message} {s}");
            Console.ResetColor();
        }
    }
}
