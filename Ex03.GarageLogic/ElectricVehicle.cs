using Ex03.GarageLogic.Exceptions;
namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_AccumulatorTimeLeft;
        private readonly float m_MaxAccumulatorTime;

        public ElectricVehicle(string i_LicenseNumber, int i_WheelsAmount, float i_MaxAirPressure, float i_MaxAccumulatorTime)
        : base(i_LicenseNumber, i_WheelsAmount, i_MaxAirPressure)
        {
            this.m_MaxAccumulatorTime = i_MaxAccumulatorTime;
        }

        public float AccumulatorTimeLeft
        {
            set
            {
                this.Charging(value);
            }
        }

        public void Charging(float i_Hours)
        {
            if (this.m_AccumulatorTimeLeft + i_Hours > this.m_MaxAccumulatorTime)
            {
                throw new ValueOutOfRangeException(0, m_MaxAccumulatorTime - m_AccumulatorTimeLeft, "For Accumulator Time Left");
            }
            else
            {
                m_AccumulatorTimeLeft += i_Hours;
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format("Accumulator Time Left:{0}\nMax Accumulator Time:{1}\n", m_AccumulatorTimeLeft, m_MaxAccumulatorTime);

            return base.ToString() + str;
        }


    }
}
