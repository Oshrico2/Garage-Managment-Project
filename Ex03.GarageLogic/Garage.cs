using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private static List<Vehicle> s_VehiclesInGarage;
        private static Factory s_Factory;

        static Garage()
        {
            s_VehiclesInGarage = new List<Vehicle>();
            s_Factory = new Factory();
        }

        private static Vehicle findVehicleByLicenseNumber(string i_LicenseNumber)
        {
            Vehicle foundVehicle = s_VehiclesInGarage.Find(vehicle => vehicle.LicenseNumber == i_LicenseNumber);
            if(foundVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle with License Number: {0} does not exist in the garage",i_LicenseNumber));
            }
            else
            {
                return foundVehicle;
            }
        }
        public static bool IsExistsInGarage(string i_LicenseNumber)
        {
            bool isExistsInGarage = false;
            Vehicle vehicle = null;

            try
            {
                vehicle = findVehicleByLicenseNumber(i_LicenseNumber);
            }
            catch(ArgumentException ae) { }
            
            if (vehicle != null)
            {
                vehicle.ChangeVehicleStatus(eVehicleStatus.Repair);
                isExistsInGarage = true;
            }

            return isExistsInGarage;
        }

        public static Dictionary<string, Type> InsertVehicleType(Type i_Type, string i_LicenseNumber)
        {
            Vehicle vehicle;
            Dictionary<string, Type> setters = new Dictionary<string, Type>();

            vehicle = s_Factory.CreateVehicle(i_Type,i_LicenseNumber);
            s_VehiclesInGarage.Add(vehicle);
            chooseAttributes(vehicle, ref setters);

            return setters;
        }

        private static void chooseAttributes(Vehicle i_Vehicle ,ref Dictionary<string, Type> setters)
        {
            Type vehicleType = i_Vehicle.GetType(), wheelType = typeof(Wheel);

            foreach (PropertyInfo vehicleProperty in vehicleType.GetProperties())
            {
                
                if (vehicleProperty.CanWrite)
                {
                    //Type propertyType = vehicleProperty.PropertyType;
                    //setters[vehicleProperty.Name] = propertyType;
                    Type propertyType = vehicleProperty.PropertyType;
                    string propertyNameWithSpaces = Regex.Replace(vehicleProperty.Name, "([A-Z])", " $1").TrimStart();
                    setters[propertyNameWithSpaces] = propertyType;
                }
            }

            foreach (PropertyInfo wheelProperty in wheelType.GetProperties())
            {
                if (wheelProperty.CanWrite)
                {
                    setters[wheelProperty.Name] = wheelProperty.GetType();
                }
            }

        }

        public static void SetVehicleAttributes(Dictionary<string,string> i_UserInputs, string i_LicenseNumber)
        {
            Vehicle vehicle = findVehicleByLicenseNumber(i_LicenseNumber);
            Type vehicleType = vehicle.GetType();

            if (vehicle == null)
            {
                throw new FormatException("Wrong License number");
            }
            else
            {
                foreach (var item in i_UserInputs)
                {
                    PropertyInfo propertyInfo = vehicleType.GetProperty(item.Key);
                    if (propertyInfo != null && propertyInfo.CanWrite)
                    {
                        // Get the set method for the property
                        MethodInfo setMethod = propertyInfo.GetSetMethod();
                        if (setMethod != null)
                        {
                            object valueToSet = item.Value;

                            if (propertyInfo.PropertyType.IsEnum)
                            {
                                valueToSet = Enum.Parse(propertyInfo.PropertyType, (string)item.Value);
                            }
                            else
                            {
                                try
                                {
                                    valueToSet = Convert.ChangeType(item.Value, propertyInfo.PropertyType);
                                }
                                catch(FormatException fe)
                                { 
                                    throw new FormatException(string.Format("Invalid boolean value. Please use {0} for {1}",propertyInfo.PropertyType.Name,propertyInfo.Name), fe);
                                }
                            }

                            try 
                            { 
                                propertyInfo.SetValue(vehicle, valueToSet);
                            }
                            catch(Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }

                foreach (Wheel wheel in vehicle.WheelList)
                {
                    float airPressure = float.Parse(i_UserInputs["AirPressure"].ToString());
                    wheel.BlowWheel(airPressure);
                    wheel.WheelManufacturerName = i_UserInputs["WheelManufacturerName"];
                }

            }
        }

        public static List<string> GetListOfVehiclesInGarage(eVehicleStatus? i_VehicleStatus = null)
        {
            List<string> listOfVehiclesInGarage = new List<string>();

            foreach(Vehicle vehicle in s_VehiclesInGarage)
            {
                if(vehicle.VehicleStatus == i_VehicleStatus || i_VehicleStatus == null)
                {
                    listOfVehiclesInGarage.Add(vehicle.LicenseNumber);
                }
            }

            return listOfVehiclesInGarage;
        }

        public static void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_VehicleStatus)
        {
            Vehicle vehicleFound = findVehicleByLicenseNumber(i_LicenseNumber);
            vehicleFound.ChangeVehicleStatus(i_VehicleStatus);
        }

        public static void BlowMaxAirPressure(string i_LicenseNumber)
        {
            Vehicle vehicleFound = findVehicleByLicenseNumber(i_LicenseNumber);
            float airPressureToBlow;
            airPressureToBlow = vehicleFound.WheelList[0].MaxAirPressure - vehicleFound.WheelList[0].AirPressure;
            foreach (Wheel wheel in vehicleFound.WheelList)
            {
                wheel.BlowWheel(airPressureToBlow);
            }

        }

        public static void RefuelingOrCharging(string i_LicenseNumber, string i_Amount, eFuelType? i_FuelType = null)
        {
            Vehicle vehicleFound = findVehicleByLicenseNumber(i_LicenseNumber);

            if (!float.TryParse(i_Amount, out float amount))
            {
                throw new FormatException("Invalid quantity to fill format. Please provide a number.");
            }

            if (vehicleFound is GasVehicle gasVehicle)
            {
                if (i_FuelType.HasValue)
                {
                    gasVehicle.Refueling(amount, i_FuelType.Value);
                }
                else
                {
                    throw new ArgumentException("Fuel type must be provided for gas vehicles");
                }
            }
            else if (vehicleFound is ElectricVehicle electricVehicle)
            {
                if (i_FuelType == null)
                {
                    electricVehicle.Charging(amount);
                }
                else
                {
                    throw new ArgumentException("Fuel type should not be provided for electric vehicles");
                }
            }

        }

        public static string ShowDataOnVehicle(string i_LicenseNumber)
        {
            Vehicle vehicleFound = findVehicleByLicenseNumber(i_LicenseNumber);
            return vehicleFound.ToString();
        }

        public static eFuelType ConvertToEFuelType(string i_InputToConvert)
        {
            if (!Enum.TryParse(i_InputToConvert, true, out eFuelType parsedFuelType))
            {
                throw new FormatException("Invalid fuel type. Please provide a valid Fuel Type value.");
            }
            return parsedFuelType;
        }

        public static eVehicleStatus ConvertToEVehicleStatus(string i_InputToConvert)
        {
            if (!Enum.TryParse(i_InputToConvert, true, out eVehicleStatus parseVehicleStatus))
            {
                throw new FormatException("Invalid vehicle status. Please provide a status for the vehicle.");
            }
            return parseVehicleStatus;
        }



    }

}
