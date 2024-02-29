using Ex03.GarageLogic.Exceptions;
using System;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_WheelManufacturerName;
        private float m_AirPressure;
        private readonly float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public string WheelManufacturerName
        {
            get { return m_WheelManufacturerName; }
            set { m_WheelManufacturerName = value; } 
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set 
            {
                this.BlowWheel(value);
            }
        }

        public void BlowWheel(float i_AirAmount)
        {
            if(this.m_AirPressure + i_AirAmount > this.m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0,m_MaxAirPressure - m_AirPressure, "For Blow Wheels");
            }
            else
            {
                m_AirPressure += i_AirAmount;
            }
        }
    }
}
