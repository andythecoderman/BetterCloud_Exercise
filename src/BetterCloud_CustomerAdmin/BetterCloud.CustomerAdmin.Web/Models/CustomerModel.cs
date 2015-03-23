using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BetterCloud.CustomerAdmin.Common;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;

namespace BetterCloud.CustomerAdmin.Web.Models
{
    public class CustomerModel
    {
        private ICustomerBusiness custBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();


        public List<CustomerDO> GetCustomers()
        {
            return custBiz.GetAllCustomers();
        }

        public void CreateCustomer(FormCollection formData)
        {
            var custDO = new CustomerDO
            {
                FirstName = formData["FirstName"],
                LastName = formData["LastName"],
                Email = formData["Email"]
            };

            custBiz.CreateCustomer(custDO);
        }

        public void UpdateCustomer(string customerId, FormCollection formData)
        {
            var custGuid = Guid.Parse(customerId);

            var custDO = new CustomerDO
            {
                CustomerId = custGuid,
                FirstName = formData["FirstName"],
                LastName = formData["LastName"],
                Email = formData["Email"]
            };

            custBiz.UpdateCustomer(custDO);
        }

        public CustomerDO LoadCustomerById(string customerId)
        {
            var custGuid = Guid.Parse(customerId);
            return custBiz.GetCustomer(custGuid);
        }

        public void DeleteCustomer(string customerId)
        {
            var custGuid = Guid.Parse(customerId);
            custBiz.DeleteCustomer(custGuid);

        }
    }
}