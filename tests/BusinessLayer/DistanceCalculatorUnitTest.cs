using System;
using Xunit;
using Intercom.BDO;
using Intercom.BusinessLayer;

namespace Intercom.BusinessLayer.Tests
{
    public class DistanceCalculatorUnitTest
    {
        [Fact]
        public void Verify_DistanceIsAccuratelyCalculatedBetweenTwoLocations()
        {
            double expectedDistance = 10.57;

            var location1 = new GPSLocation
            {
                Longitude = -6.257664,
                Latitude = 53.339428 
            };
            
            var location2 = new GPSLocation
            {
                Longitude = -6.238335,
                Latitude = 53.2451022
            };

            double actualDistance = DistanceCalculator.Calculate(location1, location2);

            Assert.Equal(expectedDistance, actualDistance, 2);
        }
    }
}