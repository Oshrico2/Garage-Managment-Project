namespace Ex03.GarageLogic
{
    public class Truck : GasVehicle
    {
        private bool m_TransportHazardousMaterial;
        private float m_CargoCapacity;


        public Truck(string i_LicenseNumber) : base(i_LicenseNumber, 12, 28,eFuelType.Soler, 110f)
        {

        }

        public bool TransportHazardousMaterial
        {
            set 
            { 
                m_TransportHazardousMaterial = value; 
            }
        }

        public float CargoCapacity
        {
            set 
            {
                m_CargoCapacity = value; 
            }
        }

        public override string ToString()
        {
            string str;
            str = string.Format("Is Transport Hazardous Material:{0}\nCargo Capacity:{1}\n", m_TransportHazardousMaterial, m_CargoCapacity);

            return base.ToString() + str;
        }
    }
}
