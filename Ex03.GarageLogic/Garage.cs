using System;
using System.Collections.Generic;
using System.Linq;

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
            return s_VehiclesInGarage.Any(vehicle => vehicle.LicenseNumber == i_LicenseNumber);
        }
        public static void Insert(Type i_Type, string i_LicenseNumber, string i_OwnerName, string i_OwnerPhone)
        {
            Vehicle vehicle;
            vehicle = s_Factory.CreateVehicle(i_Type);
            vehicle.LicenseNumber = i_LicenseNumber;
            vehicle.OwnerPhone = i_OwnerPhone;
            vehicle.OwnerName = i_OwnerName;
            vehicle.VehicleStaus = eVehicleStatus.Repair;
            s_VehiclesInGarage.Add(vehicle);
            Console.WriteLine(vehicle.ToString());
        }
    }
}
