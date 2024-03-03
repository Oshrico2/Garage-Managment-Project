using Ex03.GarageLogic.Exceptions;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_WheelManufacturerName;
        private float m_AirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            this.r_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public string WheelManufacturerName
        {
            get { return m_WheelManufacturerName; }
            set { m_WheelManufacturerName = value; } 
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { this.BlowWheel(value); }
        }

        public void BlowWheel(float i_AirAmount)
        {
            if(this.m_AirPressure + i_AirAmount > this.r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0,r_MaxAirPressure - m_AirPressure, "For Blow Wheels");
            }
            else
            {
                m_AirPressure += i_AirAmount;
            }
        }
    }
}