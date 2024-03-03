using Ex03.GarageLogic.Exceptions;
using System;
namespace Ex03.GarageLogic
{
    public abstract class GasVehicle : Vehicle
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelAmount;
        private float m_FuelAmount;

        public GasVehicle(string i_LicenseNumber, int i_WheelsAmount, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuelAmount)
        : base(i_LicenseNumber, i_WheelsAmount, i_MaxAirPressure)
        {
            this.r_FuelType = i_FuelType;
            this.r_MaxFuelAmount = i_MaxFuelAmount;
        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float FuelAmount
        {
            set
            {
                this.SetEnergyPrecentage(value / r_MaxFuelAmount * 100);
                this.Refueling(value, this.r_FuelType);
            }
        }

        public void Refueling(float i_Liters, eFuelType i_FuelType)
        {
            if (this.m_FuelAmount + i_Liters > this.r_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(0, r_MaxFuelAmount - m_FuelAmount, "For Fuel Amount");
            }
            else if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException(String.Format("Cannot refueling. Not the same fuel type. Try to use: {0}", this.FuelType.ToString()));
            }
            else
            {
                m_FuelAmount += i_Liters;
            }
        }

        public override string ToString()
        {
            string str;

            str = string.Format("Fuel Type: {0}\nFuel Amount: {1}\nMax Fuel Amount: {2}\n", r_FuelType, m_FuelAmount, r_MaxFuelAmount);

            return base.ToString() + str;
        }
    }
}