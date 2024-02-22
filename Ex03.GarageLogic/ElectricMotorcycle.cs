namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapaciy;

        public ElectricMotorcycle() : base(2, 29, 2.8f) { }

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
