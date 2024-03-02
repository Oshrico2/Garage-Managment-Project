using System;
namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public readonly float r_MaxValue;
        public readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue,string i_WhatToFill)
            : base($"Value is out of range. Minimum value allowed: {i_MinValue}. Maximum value allowed: {i_MaxValue} {i_WhatToFill}.")
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }
    }
}