using System;
using System.Collections.Generic;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;

namespace BetterCloud.CustomerAdmin.Business.Test.Mocks
{
    /// <summary>
    /// Provides a Mock instance of the IDataAccess for Unit Testing
    /// </summary>
    public class MockIDataAccess : ICustomerData
    {
        public void Dispose()
        {
            
        }

        public List<CustomerDO> GetAllCustomers()
        {
            var customers = new List<CustomerDO>();

            for (int i = 0; i < 50; i++)
            {
                customers.Add(new CustomerDO()
                {
                    CustomerId = new Guid()
                    //TODO: Add more details
                });
            }
            return customers;
        }

        public CustomerDO GetCustomer(Guid customerId)
        {
            return new CustomerDO()
            {
                CustomerId = new Guid()
                //TODO: Add more details
            };
        }

        public Guid CreateCustomer(CustomerDO customerDO)
        {
            return new Guid();
        }

        public bool UpdateCustomer(CustomerDO customerDO)
        {
            return true;
        }

        public bool DeleteCustomer(Guid customerId)
        {
            return true;
        }
    }
}
