namespace Ex03.GarageLogic
{
    public class Motorcycle : GasVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapaciy;
        public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber, 2, 29,eFuelType.Octan98, 5.8f) { }

        public eLicenseType LicenseType
        {
            set { m_LicenseType = value; }
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
