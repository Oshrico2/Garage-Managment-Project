using Ex03.GarageLogic.Exceptions;
namespace Ex03.GarageLogic
{
    abstract class ElectricVehicle : Vehicle
    {
        private float m_AccumulatorTimeLeft;
        private float m_MaxAccumulatorTime;

        public ElectricVehicle(int i_WheelsAmount,float i_MaxAirPressure, float i_MaxAccumulatorTime)
        : base(i_WheelsAmount, i_MaxAirPressure)
        {
            this.m_MaxAccumulatorTime = i_MaxAccumulatorTime;
        }

        public void Charge(float i_Hours)
        {
            if (this.m_AccumulatorTimeLeft + i_Hours > this.m_MaxAccumulatorTime)
            {
                throw new ValueOutOfRangeException(this.m_MaxAccumulatorTime - this.m_AccumulatorTimeLeft, m_MaxAccumulatorTime);
            }
            else
            {
                m_AccumulatorTimeLeft += i_Hours;
            }
        }

        
    }
}
