using System;
using Xunit;
using Intercom.BDO;
using Intercom.Interfaces;
using Intercom.DataAccess;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Intercom.DataAccess.Tests
{
    public class FileDataFetchUnitTest
    {
        [Fact]
        public void Verify_ListOfCustomersIsReturnedFromJSONFile()
        {
            //Setup
            var mockFileReader = new Mock<IFileReader>();
            var deserializer = new JsonDeserializer();

            List<string> jsonData =  new List<string>();
            jsonData.Add("{\"latitude\": \"52.986375\", \"user_id\": 12, \"name\": \"Christina McArdle\", \"longitude\": \"-6.043701\"}");
            
            mockFileReader.Setup(reader => reader.ReadAllLines()).Returns(jsonData);

            FileDataFetch dataFetch = new FileDataFetch(mockFileReader.Object, deserializer);


            //Act
            var customers = dataFetch.GetAllCustomers();


            //Verify
            Assert.Single(customers);
            
            Customer customer = customers.First();

            Assert.Equal(52.986375, customer.Location.Latitude, 6);
            Assert.Equal(-6.043701, customer.Location.Longitude, 6);
            Assert.Equal(12, customer.UserId);
            Assert.Equal("Christina McArdle", customer.Name);

            mockFileReader.Verify();
        }
    }
}