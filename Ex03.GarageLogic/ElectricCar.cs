namespace Ex03.GarageLogic
{
    class ElectricCar : ElectricVehicle
    {
        private eColor m_Color;
        private eDoorsAmount m_DoorsAmount;

        public ElectricCar() : base(5,30,4.8f)
        {

        }

        public eColor Color
        {
            set { m_Color = value; }
        }

        public eDoorsAmount DoorsAmount
        {
            set { m_DoorsAmount = value; }
        }
    }
}
