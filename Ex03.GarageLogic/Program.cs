using System;
using System.Collections.Generic;
using System.Linq;
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
                setters = Garage.InsertVehicleType(typeof(Truck), "12345");
                DisplayOptions(setters, "12345");
                setters = Garage.InsertVehicleType(typeof(ElectricCar), "123456");
                DisplayOptions(setters, "123456");
                //setters = Garage.InsertVehicleType(typeof(ElectricCar), input);
                //DisplayOptions(setters);
                //setters = Garage.InsertVehicleType(typeof(Truck), input);
                //DisplayOptions(setters);
                Console.WriteLine(Garage.ShowDataOnVehicle("12345"));
                Console.WriteLine(Garage.ShowDataOnVehicle("123456"));

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //Garage.BlowMaxAirPressure(input);

        //Console.WriteLine(string.Join(", ", Garage.GetListOfVehiclesInGarage()));

    }


    public static void DisplayOptions(Dictionary<string, Type> setters,string i_LicenseNumber)
    {
        string input;
        Dictionary<string, string> userInputs = new Dictionary<string, string>();
 
        foreach (var pair in setters)
        {
            if (pair.Value.IsEnum)
            {
                string enumOptions = GetEnumOptions(pair.Value);
                Console.WriteLine(string.Format( "Enter Please {0}\nOptions: {1}",pair.Key, enumOptions));
            }
            else
            {
                Console.WriteLine(string.Format("Enter Please {0}", pair.Key));
            }
            input = Console.ReadLine();
            userInputs[pair.Key] = input;
        }
        Console.WriteLine();

        try
        {
            Garage.SetVehicleAttributes(userInputs, i_LicenseNumber);
        }
        catch(ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }


    }

    public static string GetEnumOptions(Type enumType)
    {
        if (!enumType.IsEnum)
            throw new ArgumentException("The specified type is not an enum.");

        return string.Join(", ", Enum.GetNames(enumType));
    }

    
}

