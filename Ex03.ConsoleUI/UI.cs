using System;
using Ex03.GarageLogic;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using System.Linq;
namespace Ex03.ConsoleUI
{
    public abstract class UI
    {
        public static void RunProgram()
        {
            bool isValidInput = false;

            Console.WriteLine("Welcome to Garage Management");
            while (!isValidInput)
            {
                try
                {
                    menu();
                    isValidInput = true;
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine($"Error: {fe.Message}");
                }
            }
        }
            

        private static void menu()
        {
            string inputStr;
            int input;
            Console.WriteLine(
                @"Select the number of the action you want to do:
            1 - Insert car to garage.
            2 - Display the license numbers of the vehicles in the garage.
            3 - Change the status of a car in the garage.
            4 - To inflate the air of car wheels to the maximum.
            5 - Refuel a fuel-driven vehicle.
            6 - Charge an electric vehicle.
            7 - Display complete data by vehicle license number");

            inputStr = Console.ReadLine();
            int.TryParse(inputStr, out input);

            if(input >= 1 && input <= 7)
            {
                chooseUserOption(input);
            }
            else
            {
                throw new ValueOutOfRangeException(1, 7);
            }

        }

        private static void chooseUserOption(int i_Input)
        {
            switch (i_Input)
            {
                case 1:
                    insertVehicleHandler();
                    break;
                case 2:
                    displayVehiclesInGarageHandler();
                    break;
                case 3:
                    changeStatusHandler();
                    break;
                case 4:
                    blowAirHandler();
                    break;
                case 5:
                    refuelVehicleHandler();
                    break;
                case 6:
                    chargeVehicleHandler();
                    break;
                case 7:
                    displayFullDataHandler();
                    break;
            }
        }

        private static void insertVehicleHandler()
        {
            Dictionary<string, Type> setters = null;
            Dictionary<string, string> userInputs;
            bool isValidInput = false;

            Console.WriteLine("Enter License Number");
            string input = Console.ReadLine();
            if (Garage.IsExistsInGarage(input))
            {
                Console.WriteLine("Car Exists in Garage in Reapir state");
            }
            else
            {
                while (!isValidInput)
                {
                    try
                    {
                        setters = Garage.InsertVehicleType(chooseVehicleType(), input);
                        isValidInput = true;
                    }
                    catch(FormatException fe)
                    {
                        Console.WriteLine($"An error occurred: {fe.Message} Choose Valid Type of Vehicle");
                    }
                }

                isValidInput = false;

                while (!isValidInput)
                {
                    try
                    {
                        userInputs = displayAndSetAttributes(setters, input);
                        Garage.SetVehicleAttributes(userInputs, input);
                        isValidInput = true;
                        Console.WriteLine("The Vehicle arrived at the garage successfully ");
                    }
                    catch(ValueOutOfRangeException vore)
                    {
                        Console.WriteLine(vore.Message);
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine($"An error occurred: {fe.Message}");
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine($"An error occurred: {ae.Message}");
                    }
                }
                
            }
        }

        private static void displayVehiclesInGarageHandler()
        {

        }

        private static void changeStatusHandler()
        {

        }

        private static void blowAirHandler()
        {

        }

        private static void refuelVehicleHandler()
        {

        }

        private static void chargeVehicleHandler()
        {

        }

        private static void displayFullDataHandler()
        {
            
        }

        private static Dictionary<string, string> displayAndSetAttributes(Dictionary<string, Type> setters, string i_LicenseNumber)
        {
            string input;
            Dictionary<string, string> userInputs = new Dictionary<string, string>();

            foreach (var pair in setters)
            {
                if (pair.Value.IsEnum)
                {
                    string enumOptions = getEnumOptions(pair.Value);
                    Console.WriteLine(string.Format("Enter Please {0}\nOptions: {1}", pair.Key, enumOptions));
                }
                else
                {
                    Console.WriteLine(string.Format("Enter Please {0}", pair.Key));
                }
                input = Console.ReadLine();
                userInputs[pair.Key] = input;

            }
            Console.WriteLine();

            return userInputs;
        }

        private static string getEnumOptions(Type i_EnumType)
        {
            if (!i_EnumType.IsEnum)
                throw new ArgumentException("The specified type is not an enum.");

            return string.Join(", ", Enum.GetNames(i_EnumType));
        }

        private static Type chooseVehicleType()
        {
            string inputStr;
            bool isValidInput = false;
            Type vehicleType = null;

            Console.WriteLine(
                @"Select the type of vehicle you want:
            Car.
            Motorcycle.
            ElectricCar.
            ElectricMotorcycle.
            Truck.");
            inputStr = Console.ReadLine();
            vehicleType = Type.GetType("Ex03.GarageLogic." + inputStr + ", Ex03.GarageLogic");

            return vehicleType;
        }
    }
}
