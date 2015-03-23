using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        private readonly ICustomerBusiness _custBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();


        public List<CustomerDO> GetCustomers()
        {
            return _custBiz.GetAllCustomers();
        }

        public void CreateCustomer(FormCollection formData)
        {
            var custDO = ParseFormData(formData, null);

            _custBiz.CreateCustomer(custDO);
        }

        public void UpdateCustomer(string customerId, FormCollection formData)
        {
            var custGuid = Guid.Parse(customerId);
            var custDO = ParseFormData(formData, custGuid);

            _custBiz.UpdateCustomer(custDO);
        }

       

        public CustomerDO LoadCustomerById(string customerId)
        {
            var custGuid = Guid.Parse(customerId);
            return _custBiz.GetCustomer(custGuid);
        }

        public void DeleteCustomer(string customerId)
        {
            var custGuid = Guid.Parse(customerId);
            _custBiz.DeleteCustomer(custGuid);

        }

        private static CustomerDO ParseFormData(NameValueCollection formData, Guid? custGuid)
        {
            var custDO = new CustomerDO
            {
                CustomerId = custGuid,
                FirstName = formData["FirstName"],
                LastName = formData["LastName"],
                Email = formData["Email"],
                Phone = formData["Phone"],
                Gender = formData["Gender"]
            };

            DateTime dt;
            if (DateTime.TryParse(formData["DOB"].Split(',')[0], out dt))
            {
                custDO.DOB = dt;
            }

            custDO.Address = new AddressDO
            {
                Street = formData["Address.Street"],
                City = formData["Address.City"],
                Suite = formData["Address.Suite"],
                State = formData["Address.State"],
                PostalCode = formData["Address.PostalCode"],
                Country = formData["Address.Country"]
            };
            return custDO;
        }

        public CustomerDO CreateInitCustomer()
        {
            return new CustomerDO();
        }
    }
}