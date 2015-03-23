using System;
using System.Collections.Generic;
using BetterCloud.CustomerAdmin.Common;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;

namespace BetterCloud.CustomerAdmin.Business
{
    /// <summary>
    /// Implementation of standard business class that handles consumer data via the DataAccess interfaces 
    /// </summary>
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerData _customerDAO = Kernel.Instance.GetInstance<ICustomerData>();

        public void Dispose()
        {
            if (_customerDAO != null)
            {
                _customerDAO.Dispose();
            }
        }

        public List<CustomerDO> GetAllCustomers()
        {
            return _customerDAO.GetAllCustomers();
        }

        public CustomerDO GetCustomer(Guid customerId)
        {
            return _customerDAO.GetCustomer(customerId);
        }

        public Guid CreateCustomer(CustomerDO customerDO)
        {
            return _customerDAO.CreateCustomer(customerDO);
        }

        public void UpdateCustomer(CustomerDO customerDO)
        {
            _customerDAO.UpdateCustomer(customerDO);
        }
        public void DeleteCustomer(Guid customerId)
        {
            _customerDAO.DeleteCustomer(customerId);
        }
    }
}
