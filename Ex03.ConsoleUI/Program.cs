using System;
namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            while (UI.RunProgram() == true)
            {
                UI.RunProgram();
            }
            Console.ReadLine();
        }
    }
}
