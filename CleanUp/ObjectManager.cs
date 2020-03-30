using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp
{
    class ObjectManager
    {
        public static ManagementObjectSearcher ManagementObjectsList()
        {
            return DalManager.GetManagementObjects();
        }

        public static ManagementObjectCollection ObjectQueryList()
        {
            return DalManager.GetObjectQuery();
        }

        public static ManagementObjectCollection MOCBootDevice()
        {
            return DalManager.GetMOCBootDevice();
        }

        public static ManagementObjectCollection HeadLayer()
        {
            return DalManager.GetHeadLayer();
        }

        public static ManagementObjectCollection DiskMetadata()
        {
            return DalManager.GetDiskMetadata();
        }

        public static string HardDiskSerialNumber()
        {
            return DalManager.GetHardDiskSerialNumber();
        }

        public static ManagementObjectCollection LISTAllServices()
        {
            return DalManager.GetLISTAllServices();
        }


    }
}
