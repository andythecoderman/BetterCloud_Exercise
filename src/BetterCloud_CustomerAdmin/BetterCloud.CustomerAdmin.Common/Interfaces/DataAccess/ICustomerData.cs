using System;
using System.Collections.Generic;
using BetterCloud.CustomerAdmin.Common.DataObjects;

namespace BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess
{
    public interface ICustomerData : IDisposable
    {
        /// <summary>
        /// Returns the full list of all Customers in the system
        /// </summary>
        /// <returns></returns>
        List<CustomerDO> GetAllCustomers();

        /// <summary>
        /// Returns a single Customer based on the CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        CustomerDO GetCustomer(Guid customerId);


        /// <summary>
        /// Creates new Customer recrod and returns the generated CustomerId
        /// </summary>
        /// <param name="customerDO"></param>
        /// <returns></returns>
        Guid CreateCustomer(CustomerDO customerDO);

        /// <summary>
        /// Replaces the existing Customer record with the <param name="customerDO"></param> with the matching CustomerId property
        /// </summary>
        /// <param name="customerDO"></param>
        /// <returns></returns>
        bool UpdateCustomer(CustomerDO customerDO);

        /// <summary>
        /// Purges the customer record with CustomerId matching the <param name="customerId"></param> argument
        /// </summary>
        /// <param name="customerId"></param>
        bool DeleteCustomer(Guid customerId);
    }
}
