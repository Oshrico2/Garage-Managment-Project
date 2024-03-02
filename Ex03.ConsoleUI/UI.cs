using System;
using Ex03.GarageLogic;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using System.Text;
namespace Ex03.ConsoleUI
{
    public abstract class UI
    {
        public static bool RunProgram()
        {
            bool isValidInput = false, quitFlag = true; ; 

            Console.WriteLine("Welcome to Garage Management");
            while (!isValidInput)
            {
                try
                {
                    menu(ref isValidInput);
                    if(isValidInput == true)
                    {
                        quitFlag= false;
                    }
                    else
                    {
                        isValidInput = true;
                        quitFlag = true;
                    }
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                    quitFlag= true;
                }
                catch(FormatException fe)
                {
                    Console.WriteLine($"Error: {fe.Message}");
                    quitFlag = true;
                }
            }

            return quitFlag;
        }

        private static void menu(ref bool i_IsValidInput)
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
7 - Display complete data by vehicle license number.
q - Quit");
            inputStr = Console.ReadLine();
            if (inputStr == "q")
            {
                i_IsValidInput = true;
                Console.Clear();
                Console.WriteLine("Goodbye");
            }
            else
            {
                int.TryParse(inputStr, out input);
                if (input >= 1 && input <= 7)
                {
                    chooseUserOption(input);
                }
                else
                {
                    throw new ValueOutOfRangeException(1, 7, "");
                }
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
                    displayFullDetailsHandler();
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
                        userInputs = displayAndSetAttributes(setters);
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
                    catch(Exception ex)
                    {
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine(ex.InnerException.Message);
                        }
                    }
                }
            }
        }

        private static void displayVehiclesInGarageHandler()
        {
            string input;
            eVehicleStatus status;
            List<string> listOfVehiclesInGarage = new List<string>();
            bool isValidInput = false;

            Console.WriteLine("Please write yes you want to show all the list or no if you want to filter\n");
            input = Console.ReadLine();
            if (input == "yes")
            {
                listOfVehiclesInGarage = Garage.GetListOfVehiclesInGarage();
                foreach (var vehicle in listOfVehiclesInGarage)
                {
                    Console.WriteLine(vehicle);
                }
            }
            else
            {
                while (!isValidInput)
                {
                    try
                    {
                        Console.WriteLine(String.Format("please choose which list you want to show. Options for status:\n{0}", getEnumOptions(typeof(eVehicleStatus))));
                        input = Console.ReadLine();
                        status = Garage.ConvertToEVehicleStatus(input);
                        listOfVehiclesInGarage = Garage.GetListOfVehiclesInGarage(status);
                        foreach (var vehicle in listOfVehiclesInGarage)
                        {
                            Console.WriteLine(vehicle);
                        }
                        isValidInput = true;
                    }
                    catch (ValueOutOfRangeException vore)
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

        private static void changeStatusHandler()
        {
            string inputLicenseNumber, inputVehicleStatus;
            bool isValidInput = false;

            Console.WriteLine(String.Format("Please enter license number and the status you want to change.\nOptions for status:\n{0}", getEnumOptions(typeof(eVehicleStatus))));
            while (!isValidInput)
            {
                try
                {
                    Console.Write("License Number:");
                    inputLicenseNumber = Console.ReadLine();
                    Console.Write("Status:");
                    inputVehicleStatus = Console.ReadLine();
                    Garage.ChangeVehicleStatus(inputLicenseNumber, Garage.ConvertToEVehicleStatus(inputVehicleStatus));
                    isValidInput = true;
                    Console.WriteLine("The vehicle ststus has been changed successfully");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
            }
        }

        private static void blowAirHandler()
        {
            string input;
            bool isValidInput = false;

            Console.WriteLine("Enter the license number of the vehicle for which you want to inflate wheels");
            while (!isValidInput)
            {
                try
                {
                    input = Console.ReadLine();
                    Garage.BlowMaxAirPressure(input);
                    isValidInput = true;
                    Console.WriteLine("The inflation of the wheels has been completed successfully");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
            }
        }

        private static void refuelVehicleHandler()
        {
            string inputLicenseNumber, inputFuelType, inputAmount;
            bool isValidInput = false;

            Console.WriteLine(String.Format("Please enter license number, type of fuel to fill, quantity to fill\nOptions for fuel types:\n{0}", getEnumOptions(typeof(eFuelType))));
            while (!isValidInput)
            {
                try
                {
                    Console.Write("License Number:");
                    inputLicenseNumber = Console.ReadLine();
                    Console.Write("Fuel Type:");
                    inputFuelType = Console.ReadLine();
                    Console.Write("Quantity:");
                    inputAmount = Console.ReadLine();       
                    Garage.RefuelingOrCharging(inputLicenseNumber, inputAmount, Garage.ConvertToEFuelType(inputFuelType));
                    isValidInput = true;
                    Console.WriteLine("The refueling has been completed successfully");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Console.WriteLine("Press b to back main menu");
                    if (isGoingBack(Console.ReadLine()))
                    {
                        break;
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
            }
        }

        private static void chargeVehicleHandler()
        {
            string inputLicenseNumber, inputAmount;
            bool isValidInput = false;

            Console.WriteLine("Please enter license number and quantity to charge");
            while (!isValidInput)
            {
                try
                {
                    Console.Write("License Number:");
                    inputLicenseNumber = Console.ReadLine();
                    Console.Write("Quantity:");
                    inputAmount = Console.ReadLine();
                    Garage.RefuelingOrCharging(inputLicenseNumber, inputAmount);
                    isValidInput = true;
                    Console.WriteLine("The charge has been completed successfully");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    Console.WriteLine("Press b to back main menu");
                    if (isGoingBack(Console.ReadLine()))
                    {
                        break;
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine(vore.Message);
                }
            }
        }

        private static void displayFullDetailsHandler()
        {
            string input, vehicleDetails;
            bool isValidInput = false;

            Console.WriteLine("Please enter license number and quantity to show details");
            while (!isValidInput)
            {
                try
                {
                    Console.Write("License Number: ");
                    input = Console.ReadLine();
                    vehicleDetails = Garage.ShowDataOnVehicle(input);
                    isValidInput = true;
                    Console.WriteLine(String.Format("Details for vehicle with License Number: {0}.\n{1}",input ,vehicleDetails));
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static Dictionary<string, string> displayAndSetAttributes(Dictionary<string, Type> i_Setters)
        {
            string input;
            Dictionary<string, string> userInputs = new Dictionary<string, string>();

            foreach (var pair in i_Setters)
            {
                if (pair.Value.IsEnum)
                {
                    string enumOptions = getEnumOptions(pair.Value);

                    Console.WriteLine(string.Format("Enter Please {0}\nOptions: {1}", handleCapitalLetters(pair.Key), enumOptions));
                }
                else
                {
                    Console.WriteLine(string.Format("Enter Please {0}", handleCapitalLetters(pair.Key)));
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
            Type vehicleType = null;

            Console.WriteLine("Select the type of vehicle you want without spaces:" + handleCapitalLetters(Garage.DisplayTypesOfVehicles()));
            inputStr = Console.ReadLine();
            vehicleType = Type.GetType("Ex03.GarageLogic." + inputStr + ", Ex03.GarageLogic");

            return vehicleType;
        }

        private static string handleCapitalLetters(string i_String)
        {
            StringBuilder result = new StringBuilder();

            result.Append(i_String[0]);
            for (int i = 1; i < i_String.Length; i++)
            { 
                if (char.IsUpper(i_String[i]))
                {
                    result.Append(' ');
                }

                result.Append(i_String[i]);
            }

            return result.ToString();
        }

        private static bool isGoingBack(string i_Str)
        {
            bool isGoingBack = false;

            if(i_Str == "b")
            {
                isGoingBack = true;
            }

            return isGoingBack;
        }
    }
}