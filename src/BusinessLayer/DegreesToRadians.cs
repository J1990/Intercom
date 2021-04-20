using System;

namespace Intercom.BusinessLayer
{
    public static class DegreesToRadians
    {
        public static double ConvertToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
    }
}