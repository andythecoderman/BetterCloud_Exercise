using System;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterCloud.CustomerAdmin.Common.Tests
{
    [TestClass]
    public class DataObjectsTests
    {
        [TestMethod]
        public void CreateCustomer_Default()
        {
            try
            {
                var customer = new CustomerDO();
                Assert.IsNull(customer.Id);
                Assert.IsNull(customer.CustomerId);
                Assert.IsNull(customer.Email);
                Assert.IsNull(customer.Phone);
                Assert.IsNull(customer.DOB);
                Assert.IsNull(customer.FirstName);
                Assert.IsNull(customer.LastName);
                Assert.AreEqual(GenderTypes.Unspecified, customer.Gender);
                
                Assert.IsNotNull(customer.Address);
                Assert.IsNull(customer.Address.Street);
                Assert.IsNull(customer.Address.City);
                Assert.IsNull(customer.Address.State);
                Assert.IsNull(customer.Address.PostalCode);
                Assert.IsNull(customer.Address.Country);
                Assert.IsNull(customer.Address.Suite);
                Assert.IsNull(customer.Address.Longitude);
                Assert.IsNull(customer.Address.Latitude);
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void CreateAddress_Default()
        {
            try
            {
                var addr = new AddressDO();
                Assert.IsNull(addr.Id);
                Assert.IsNull(addr.Street);
                Assert.IsNull(addr.City);
                Assert.IsNull(addr.State);
                Assert.IsNull(addr.PostalCode);
                Assert.IsNull(addr.Country);
                Assert.IsNull(addr.Suite);
                Assert.IsNull(addr.Latitude);
                Assert.IsNull(addr.Longitude);
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
