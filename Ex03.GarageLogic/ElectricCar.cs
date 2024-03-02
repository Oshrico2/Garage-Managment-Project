namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private eColor m_Color;
        private eDoorsAmount m_DoorsAmount;

        public ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber, 5, 30, 4.8f) { }

        public eColor Color
        {
            set { m_Color = value; }
        }

        public eDoorsAmount DoorsAmount
        {
            set { m_DoorsAmount = value; }
        }

        public override string ToString()
        {
            string str;

            str = string.Format("Color: {0}\nDoors Amount: {1}\n", m_Color, m_DoorsAmount);

            return base.ToString() + str;
        }
    }
}