using Intercom.Interfaces;
using Intercom.BDO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Intercom.DataAccess
{
    public class JsonDeserializer : IDeserializer
    {
        public Customer Deserialize(string searializedCustomer)
        {
            dynamic obj = JsonConvert.DeserializeObject(searializedCustomer);

            GPSLocation location = new GPSLocation
            {
                Longitude = obj.longitude,
                Latitude = obj.latitude
            };

            Customer customer = new Customer
            {
                UserId = obj.user_id,
                Name = obj.name,
                Location = location
            };

            return customer;
        }
    }
}