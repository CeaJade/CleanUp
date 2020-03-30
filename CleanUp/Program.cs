using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool valid;
                int input;
                do
                {
                    valid = true;
                    Console.Write("1) Disk Data \n2) Object Management List \n3) Head Layer \n4) Test \n5) List of all services \n6) Exit program \nInput:");
                    if (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 6)
                    {
                        Console.WriteLine("Invalid input");
                        Console.ReadKey();
                        Console.Clear();
                        valid = false;
                    }

                } while (valid == false);
                Console.Clear();

                switch (input)
                {
                    case 1:
                        foreach (ManagementObject managementObject in ObjectManager.DiskMetadata())
                        {

                            Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());

                            Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());

                            Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());

                            Console.WriteLine("---------------------------------------------------");
                        }

                        Console.Write("Hard disk serial: ");
                        ObjectManager.HardDiskSerialNumber();
                        break;

                    case 2:
                        foreach (ManagementObject obj in ObjectManager.ManagementObjectsList().Get())
                        {
                            var usage = obj["PercentProcessorTime"];
                            var name = obj["Name"];
                            Console.WriteLine("CPU");
                            Console.WriteLine(name + " : " + usage + "\n");
                        }
                        break;

                    case 3:
                        foreach (ManagementObject result in ObjectManager.HeadLayer())
                        {
                            Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                            Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                            Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                            Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
                        }
                        foreach (ManagementObject result in ObjectManager.ObjectQueryList())
                        {
                            Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                            Console.WriteLine("Org.:\t{0}", result["Organization"]);
                            Console.WriteLine("O/S :\t{0}", result["Name"]);
                        }
                        break;

                    case 4:
                        Console.WriteLine("testhest start\n");

                        //enumerate the collection.
                        foreach (ManagementObject m in ObjectManager.MOCtesthest())
                        {
                            // access properties of the WMI object
                            Console.WriteLine("BootDevice : {0}", m["BootDevice"]);
                        }

                        Console.WriteLine("\ntesthest slut");
                        break;

                    case 5:
                        Console.WriteLine("process søgning");
                        foreach (ManagementObject windowsService in ObjectManager.LISTAllServices())
                        {
                            PropertyDataCollection serviceProperties = windowsService.Properties;
                            foreach (PropertyData serviceProperty in serviceProperties)
                            {
                                if (serviceProperty.Value != null)
                                {
                                    Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                                    Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                                }
                            }
                            Console.WriteLine("---------------------------------------");
                        }
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
                Console.WriteLine("\n\nPress any key to go back...");
                Console.ReadKey();
                Console.Clear();
            }

        } //Slut main       
    }
}

