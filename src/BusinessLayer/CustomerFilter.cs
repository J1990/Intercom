using Intercom.BDO;
using System.Collections.Generic;
using Intercom.Interfaces;
using System.Linq;

namespace Intercom.BusinessLayer
{
    public class CustomerFilter
    {
        IFilterStrategy _strategy;

        public CustomerFilter(IFilterStrategy strategy)
        {
            _strategy = strategy;
        }

        public IList<Customer> Pick(IList<Customer> allCustomers)
        {
            IList<Customer> filteredList = new List<Customer>();

            foreach(var customer in allCustomers)
            {
                GPSLocation location = new GPSLocation
                {
                    Latitude = customer.Location.Latitude,
                    Longitude = customer.Location.Longitude
                };

                if(_strategy.CanInclude(location))
                {
                    filteredList.Add(customer);
                }
            }

            return filteredList.OrderBy(cust => cust.UserId).ToList();
        }
    }
}