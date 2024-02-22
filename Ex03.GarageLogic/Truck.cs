namespace Ex03.GarageLogic
{
    class Truck : GasVehicle
    {
        private bool m_TransportHazardousMaterial;
        private float m_CargoCapacity;

        public Truck() : base(5, 30, 4.8f)
        {

        }

        public bool TransportHazardousMaterial
        {
            set { m_TransportHazardousMaterial = value; }
        }

        public float CargoCapacity
        {
            set { m_CargoCapacity = value; }
        }
    }
}
