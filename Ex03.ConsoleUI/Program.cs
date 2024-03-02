using System;
namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            startProject();
        }

        private static void startProject()
        {
            while (UI.RunProgram() == true)
            {
                UI.RunProgram();
            }

            Console.ReadLine();
        }
    }
}