using System;
using Xunit;
using Intercom.BDO;
using Intercom.BusinessLayer;
using System.Collections.Generic;
using System.Linq;

namespace Intercom.BusinessLayer.Tests
{
    public class CustomerFilterUnitTest
    {
        [Fact]
        public void Verify_CustomersAreFilteredAsPerDistanceFromOfficeLocation()
        {
            int rangeInKms = 100;
            GPSLocation officeLocation = new GPSLocation
            {
                Longitude = -6.257664,
                Latitude = 53.339428
            };

            Customer customer1 = new Customer
            {
                UserId = 1,
                Name = "C1",
                Location = new GPSLocation
                        {
                            Longitude = -6.238335,
                            Latitude = 53.2451022
                        }
            };

            Customer customer2 = new Customer
            {
                UserId = 2,
                Name = "C2",
                Location = new GPSLocation
                        {
                            Longitude = -6.972413,
                            Latitude = 52.240382
                        }
            };

            Customer customer3 = new Customer
            {
                UserId = 3,
                Name = "C3",
                Location = new GPSLocation
                        {
                            Longitude = -6.8422408,
                            Latitude = 53.1489345
                        }
            };

            var strategy = new DistanceFilterStrategy(rangeInKms, officeLocation);

            CustomerFilter filter = new CustomerFilter(strategy);

            var allCustomers = new List<Customer>();
            allCustomers.Add(customer3);
            allCustomers.Add(customer2);
            allCustomers.Add(customer1);
            
            var result = filter.Pick(allCustomers);

            Assert.NotEmpty(result);

            Assert.Equal(1, result.ElementAt(0).UserId);
            Assert.Equal(3, result.ElementAt(1).UserId);
        }
    }
}