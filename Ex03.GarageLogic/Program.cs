using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ex03.GarageLogic;

class Program
{
    public static void Main()
    {
        Dictionary<string, Type> setters;
        Console.WriteLine("Enter License Number");
        string input = Console.ReadLine();
        if(Garage.IsExistsInGarage(input))
        {
            Console.WriteLine("Car Exists in Garage in Reapir state");
        }
        else
        {
            try
            {
                setters = Garage.InsertType(typeof(ElectricMotorcycle));
                DisplayOptions(setters);
                setters = Garage.InsertType(typeof(ElectricCar));
                DisplayOptions(setters);
                setters = Garage.InsertType(typeof(ElectricMotorcycle));
                DisplayOptions(setters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
    }


    public static void DisplayOptions(Dictionary<string, Type> setters)
    {
        string input;
        foreach (var pair in setters)
        {
            if (pair.Value.IsEnum)
            {
                string enumOptions = GetEnumOptions(pair.Value);
                Console.WriteLine(string.Format( "Enter Please {0}\n Options: {1}",pair.Key, enumOptions));
            }
            else
            {
                Console.WriteLine(string.Format("Enter Please {0}", pair.Key));
            }
            //input = Console.ReadLine();

        }
        Console.WriteLine();
    }

    public static string GetEnumOptions(Type enumType)
    {
        if (!enumType.IsEnum)
            throw new ArgumentException("The specified type is not an enum.");

        return string.Join(", ", Enum.GetNames(enumType));
    }
}

