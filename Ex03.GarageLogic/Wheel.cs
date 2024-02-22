using Ex03.GarageLogic.Exceptions;
namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_WheelManufacturerName;
        private float m_AirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public string WheelManufacturerName
        {
            get { return m_WheelManufacturerName; }
            set { m_WheelManufacturerName = value; } 
        }

        public float AirPressure
        {
            get { return m_AirPressure; }
            set { m_AirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public void BlowWheel(float i_AirAmount)
        {
            if(this.m_AirPressure + i_AirAmount > this.m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(this.m_MaxAirPressure - this.m_AirPressure,m_MaxAirPressure);
            }
            else
            {
                m_AirPressure += i_AirAmount;
            }
        }
    }
}
