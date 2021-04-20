using Intercom.Interfaces;
using Intercom.DataAccess;
using System.Collections.Generic;
using Intercom.BDO;

namespace Intercom.BusinessLayer
{
    public class IntercomHost
    {
        IDataFetch _dataFetch;
        CustomerFilter _filter;
        
        public void Init(string customerDataFilePath, int rangeInKms, GPSLocation officeLocation)
        {
            IFileReader fileReader = new FileReader(customerDataFilePath);
            IDeserializer deserializer = new JsonDeserializer();
            _dataFetch = new FileDataFetch(fileReader, deserializer);
            DistanceFilterStrategy strategy = new DistanceFilterStrategy(rangeInKms, officeLocation);
            _filter = new CustomerFilter(strategy);
        }

        public IList<Customer> InviteFilteredCustomers()
        {
            IList<Customer> customers = _dataFetch.GetAllCustomers();
            
            return _filter.Pick(customers);
        }
    }
}