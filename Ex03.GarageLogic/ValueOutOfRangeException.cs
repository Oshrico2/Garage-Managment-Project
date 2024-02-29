using System;
namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue,string i_WhatToFill)
            : base($"Value is out of range. Minimum value allowed: {i_MinValue}. Maximum value allowed: {i_MaxValue} {i_WhatToFill}.")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
