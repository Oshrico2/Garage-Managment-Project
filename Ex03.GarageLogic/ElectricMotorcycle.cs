using System;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapaciy;

        public ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber, 2, 29, 2.8f) { }

        public eLicenseType LicenseType
        {
            set 
            { 
                if (Enum.IsDefined(typeof(eLicenseType), value))
                {
                    m_LicenseType = value;
                }
                else
                {
                    throw new ArgumentException("Wrong License Type");
                }
                     
            }
        }

        public int EngineCapaciy
        {
            set { m_EngineCapaciy = value; }
        }

        public override string ToString()
        {
            string str;
            str = string.Format("License Type: {0}\nEngine Capaciy: {1}\n", m_LicenseType, m_EngineCapaciy);

            return base.ToString() + str;
        }


    }
}
