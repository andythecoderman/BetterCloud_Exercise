using System;
using System.Collections.Generic;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;

namespace BetterCloud.CustomerAdmin.Business
{
    /// <summary>
    /// Implementation of standard business class that handles consumer data via the DataAccess interfaces 
    /// </summary>
    public class CustomerBusiness : ICustomerBusiness
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public List<CustomerDO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerDO GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Guid CreateCustomer(CustomerDO customerDO)
        {
            throw new NotImplementedException();
        }

        void ICustomerBusiness.UpdateCustomer(CustomerDO customerDO)
        {
            throw new NotImplementedException();
        }
        public void DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
