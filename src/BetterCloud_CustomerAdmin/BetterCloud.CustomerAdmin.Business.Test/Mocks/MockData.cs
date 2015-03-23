using System;
using BetterCloud.CustomerAdmin.Common.DataObjects;

namespace BetterCloud.CustomerAdmin.Business.Test.Mocks
{
    public class MockData
    {
        public static CustomerDO CreateCustomerDO(Guid customerId)
        {
            return new CustomerDO() { CustomerId = customerId, Email = "test@test.com"};
        }

        public static CustomerDO CreateCustomerDO()
        {
            var testCustId = Guid.Parse("DF4EA5EF-0DB3-4863-9DFB-B12DFA6EB63C"); //- Just some random guid I pulled
            return CreateCustomerDO(testCustId);
        }
    }
}