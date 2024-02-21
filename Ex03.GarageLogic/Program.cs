using System;
using System.Runtime.InteropServices;
using Ex03.GarageLogic;

class Program
{
    public static void Main()
    {
        Garage.Insert(typeof(ElectricCar), "123122", "Osher Cohen", "0549577307");
        Garage.Insert(typeof(ElectricCar), "12312312", "Guy Mizrahi", "054121514");
        Garage.Insert(typeof(ElectricMotorcycle), "12322q", "Yuli Sotnikov", "0546233568");

        
    }
}
