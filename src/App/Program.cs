using Intercom.BDO;
using Intercom.BusinessLayer;
using System;

namespace Intercom.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inputs
            int rangeInKms = 100;
            string customerDataFilePath = "data\\customers.txt";
            GPSLocation officeLocation = new GPSLocation
            {
                Longitude = -6.257664,
                Latitude = 53.339428
            };

            IntercomHost host = new IntercomHost();
            host.Init(customerDataFilePath, rangeInKms, officeLocation);

            foreach(var customer in host.InviteFilteredCustomers())
            {
                Console.WriteLine("UserId: " + customer.UserId + ", Customer Name: " + customer.Name);
            }
        }
    }
}
 