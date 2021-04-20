using Intercom.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Intercom.BDO;

namespace Intercom.DataAccess
{
    public class FileDataFetch : IDataFetch
    {
        private IDeserializer _deserializer;
        private IFileReader _fileReader;

        public FileDataFetch(IFileReader fileReader, IDeserializer deserializer)
        {
            _fileReader = fileReader;
            _deserializer = deserializer;
        }

        public IList<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();

            IList<string> lines = _fileReader.ReadAllLines();

            foreach(string line in lines)
            {
                customers.Add(_deserializer.Deserialize(line));
            }

            return customers;
        }
    }
}