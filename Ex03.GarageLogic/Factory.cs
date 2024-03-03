using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    internal class Factory
    {
        private List<Type> supportedVehicleTypes;

        public Factory()
        {
            supportedVehicleTypes = new List<Type>
            {
                typeof(ElectricCar),
                typeof(ElectricMotorcycle),
                typeof(Truck),
                typeof(Car),
                typeof(Motorcycle),
            };
        }

        public Vehicle CreateVehicle(Type i_Type, string i_LicenseNumber)
        {
            object obj;

            if (i_Type == supportedVehicleTypes[0])
            {
                obj = new ElectricCar(i_LicenseNumber);
            }
            else if (i_Type == supportedVehicleTypes[1])
            {
                obj = new ElectricMotorcycle(i_LicenseNumber);
            }
            else if (i_Type == supportedVehicleTypes[2])
            {
                obj = new Truck(i_LicenseNumber);
            }
            else if (i_Type == supportedVehicleTypes[3])
            {
                obj = new Car(i_LicenseNumber);
            }
            else if (i_Type == supportedVehicleTypes[4])
            {
                obj = new Motorcycle(i_LicenseNumber);
            }
            else
            {
                throw new FormatException("Unsupported type!");
            }

            return obj as Vehicle;
        }
    }
}