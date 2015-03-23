using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;

namespace BetterCloud.CustomerAdmin.Web.Tests.Mocks
{
    public class CustomerBusinessMock : ICustomerBusiness
    {
        public void Dispose()
        {
           
        }

        public List<CustomerDO> GetAllCustomers()
        {
            return new List<CustomerDO>();
        }

        public CustomerDO GetCustomer(Guid customerId)
        {
            return MockData.CreateCustomerDO(customerId);
        }

        public Guid CreateCustomer(CustomerDO customerDO)
        {
            customerDO.CustomerId = new Guid();
            return  (Guid) customerDO.CustomerId;
        }

        public void UpdateCustomer(CustomerDO customerDO)
        {
            
        }

        public void DeleteCustomer(Guid customerId)
        {
            
        }
    }
}
