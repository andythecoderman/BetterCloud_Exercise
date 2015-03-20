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
                Assert.IsNull(customer.Address);
                Assert.IsNull(customer.DOB);
                Assert.IsNull(customer.FirstName);
                Assert.IsNull(customer.LastName);
                Assert.AreEqual(GenderTypes.Unspecified, customer.Gender);
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
