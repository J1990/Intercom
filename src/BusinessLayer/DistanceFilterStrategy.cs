using Intercom.BDO;
using Intercom.Interfaces;

namespace Intercom.BusinessLayer
{
    public class DistanceFilterStrategy : IFilterStrategy
    {
        private int _rangeInKms;
        private GPSLocation _sourceLocation;

        public DistanceFilterStrategy(int rangeInKms, GPSLocation sourceLocation)
        {
            _sourceLocation = sourceLocation;
            _rangeInKms = rangeInKms;
        }

        public bool CanInclude(GPSLocation destinationLocation)
        {
            return DistanceCalculator.Calculate(_sourceLocation, destinationLocation) <= _rangeInKms;
        }
    }
}