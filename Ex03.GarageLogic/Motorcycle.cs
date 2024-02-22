namespace Ex03.GarageLogic
{
    class Motorcycle : GasVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapaciy;
        public Motorcycle() : base(2, 29, 2.8f) { }

        public eLicenseType LicenseType
        {
            set { m_LicenseType = value; }
        }

        public int EngineCapaciy
        {
            set { m_EngineCapaciy = value; }
        }

    }
}
