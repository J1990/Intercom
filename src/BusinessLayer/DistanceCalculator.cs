using Intercom.BDO;
using System;

namespace Intercom.BusinessLayer
{
    public static class DistanceCalculator
    {
        static double earthRadiusInKms = 6371.0;

        public static double Calculate(GPSLocation location1, GPSLocation location2)
        {
            double loc1Lat = DegreesToRadians.ConvertToRadians(location1.Latitude);
            double loc1Long = DegreesToRadians.ConvertToRadians(location1.Longitude);

            double loc2Lat = DegreesToRadians.ConvertToRadians(location2.Latitude);
            double loc2Long = DegreesToRadians.ConvertToRadians(location2.Longitude);

            double deltaLong = Math.Abs(loc2Long - loc1Long);

            double delta = Math.Acos(Math.Sin(loc1Lat) * Math.Sin(loc2Lat) 
                                        + Math.Cos(loc1Lat) * Math.Cos(loc2Lat) * Math.Cos(deltaLong));

            return Math.Round(earthRadiusInKms * delta, 2);
        }
    }
}