using System.Collections.Generic;
using Intercom.BDO;

namespace Intercom.Interfaces
{
    public interface IDataFetch
    {
        IList<Customer> GetAllCustomers();
    }
}