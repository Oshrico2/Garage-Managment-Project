using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        public static bool IsExistsInGarage(string i_LicenseNumber)
        {
            bool isExistsInGarage = false;
            Vehicle foundVehicle = s_VehiclesInGarage.Find(vehicle => vehicle.LicenseNumber == i_LicenseNumber);

            if (foundVehicle != null)
            {
                foundVehicle.VehicleStatus = eVehicleStatus.Repair;
                isExistsInGarage = true;
            }

            return isExistsInGarage;
        }
        public static Dictionary<string, Type> InsertType(Type i_Type)
        {
            Vehicle vehicle;
            Dictionary<string, Type> setters = new Dictionary<string, Type>();

            vehicle = s_Factory.CreateVehicle(i_Type);
            vehicle.VehicleStatus = eVehicleStatus.Repair;
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
                    Type propertyType = vehicleProperty.PropertyType;
                    setters[vehicleProperty.Name] = propertyType;
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
    }
}
