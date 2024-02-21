using System;
namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue { get; }
        private float m_MinValue { get; }
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        : base($"Value is out of range. Minimum value allowed: {i_MinValue}. Maximum value allowed: {i_MaxValue}.")
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
