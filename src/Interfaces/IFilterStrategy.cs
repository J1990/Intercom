using Intercom.BDO;

namespace Intercom.Interfaces
{
    public interface IFilterStrategy
    {
        bool CanInclude(GPSLocation destinationLocation);
    }
}