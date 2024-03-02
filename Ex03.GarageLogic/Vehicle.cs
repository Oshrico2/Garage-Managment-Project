using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_VehicleModel, m_OwnerName, m_OwnerPhone;
        private readonly string r_LicenseNumber;
        private float m_EnergyPrecentage;
        private List<Wheel> m_WheelList;
        private eVehicleStatus m_VehicleStatus;

        public string VehicleModel
        {
            set { m_VehicleModel = value; }
        }

        public List<Wheel> WheelList
        {
            get { return m_WheelList; }
        }
        
        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhone; }
            set { m_OwnerPhone = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
        }

        public void ChangeVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            this.m_VehicleStatus = i_VehicleStatus;
        }

        public Vehicle(string i_LicenseNumber, int i_WheelsAmount, float i_MaxAirPressure)
        {
            this.r_LicenseNumber = i_LicenseNumber;
            m_WheelList = new List<Wheel>(i_WheelsAmount);
            for (int i = 0; i < i_WheelsAmount; i++)
            {
                m_WheelList.Add(new Wheel(i_MaxAirPressure));
            }
        }

        protected void SetEnergyPrecentage(float i_EnergyPrecentage)
        {
            m_EnergyPrecentage = i_EnergyPrecentage;
        }

        public override string ToString()
        {
            return string.Format("Model: {0}\nLicense Number: {1}\nEnergy Percentage: {2}%\nNumber of Wheels: {3}, {4}/{5} air pressure to each\nOwner name: {6}\nOwner Phone: {7}\nStatus in Garage: {8}\n",
                                 m_VehicleModel,
                                 r_LicenseNumber,
                                 m_EnergyPrecentage.ToString("0.00"),
                                 m_WheelList.Count,
                                 m_WheelList.Count > 0 ? m_WheelList[0].AirPressure.ToString() : "N/A",
                                 m_WheelList.Count > 0 ? m_WheelList[0].MaxAirPressure.ToString() : "N/A",
                                 m_OwnerName,
                                 m_OwnerPhone,
                                 m_VehicleStatus);
        }
    }
}