using Ex03.GarageLogic.Exceptions;
using System;
namespace Ex03.GarageLogic
{
    abstract class GasVehicle : Vehicle
    {
        private eFuelType m_FuelType;
        private float m_FuelAmount;
        private float m_MaxFuelAmount;

        public GasVehicle(int i_WheelsAmount, float i_MaxAirPressure, float i_MaxFuelAmount)
        : base(i_WheelsAmount, i_MaxAirPressure)
        {
            this.m_MaxFuelAmount = i_MaxFuelAmount;
        }

        public eFuelType GetM_FuelType()
        {
            return m_FuelType;
        }

        public void refueling(float i_Liters, eFuelType i_FuelType)
        {
            if (this.m_FuelAmount + i_Liters > this.m_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(this.m_MaxFuelAmount - this.m_FuelAmount, m_MaxFuelAmount);
            }
            else if (i_FuelType != m_FuelType)
            {
                throw new Exception("Cannot refueling. Not the Same fuel type");
            }
            else
            {
                m_MaxFuelAmount += i_Liters;
            }
        }

    }
}
