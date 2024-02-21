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
            };
        }

        public Vehicle CreateVehicle(Type type)
        {
            object obj;
            if (type == supportedVehicleTypes[0])
            {
                obj = new ElectricCar();
            }
            else if (type == supportedVehicleTypes[1])
            {
                obj = new ElectricMotorcycle();
            }
            else
            {
                throw new ArgumentException("Unsupported type!");
            }
            return obj as Vehicle;
        }

    }
}
