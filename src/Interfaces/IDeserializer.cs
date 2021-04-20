using Intercom.BDO;

namespace Intercom.Interfaces
{
    public interface IDeserializer
    {
        Customer Deserialize(string searializedCustomer);
    }
}