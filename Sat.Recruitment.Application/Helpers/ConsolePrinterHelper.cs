using Newtonsoft.Json;
using System;

namespace Sat.Recruitment.Application.Helpers
{
    public static class ConsolePrinterHelper
    {
        public static void PrintJson<T>(T obj, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
            Console.ResetColor();
        }

        public static void PrintString(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
