using System.Collections.Generic;
using System.Linq;
namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnergeyPrecentage;
        private List<Wheel> m_WheelList;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatus m_VehicleStaus;

        public string VehicleModel
        {
            set { m_VehicleModel = value; }
        }
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
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
            get { return m_VehicleStaus; }
            set { m_VehicleStaus = value; }
        }

        

        public Vehicle(int i_WheelsAmount, float i_MaxAirPressure)
        {
            m_WheelList = new List<Wheel>(i_WheelsAmount);

            for (int i = 0; i < i_WheelsAmount; i++)
            {
                m_WheelList.Add(new Wheel(i_MaxAirPressure));
            }
        }

        public override string ToString()
        {
            return string.Format("Model: {0}\nLicense Number: {1}\nEnergy Percentage: {2}\nNumber of Wheels: {3}, {4} air pressure to each\nOwner name: {5}\nOwner Phone: {6}\nStatus in Garage: {7}",
                                 m_VehicleModel,
                                 m_LicenseNumber,
                                 m_EnergeyPrecentage,
                                 m_WheelList.Count,
                                 m_WheelList.Count > 0 ? m_WheelList[0].MaxAirPressure.ToString() : "N/A",
                                 m_OwnerName,
                                 m_OwnerPhone,
                                 m_VehicleStaus);
        }
    }
}
