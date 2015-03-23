using System;
using BetterCloud.CustomerAdmin.Common.DataObjects;

namespace BetterCloud.CustomerAdmin.Web.Tests.Mocks
{
    public class MockData
    {
        public static CustomerDO CreateCustomerDO(Guid customerId )
        {
            return new CustomerDO() {CustomerId = customerId};
        }
        public static CustomerDO GetCreateCustomerDO()
        {
            return new CustomerDO();
        }

        public static CustomerDO GetEditCustomerDO()
        {
            var testCustId = Guid.Parse("DF4EA5EF-0DB3-4863-9DFB-B12DFA6EB63C"); //- Just some random guid I pulled

            var custDO = new CustomerDO();
            custDO.CustomerId = testCustId;

            return custDO;
        }
    }
}