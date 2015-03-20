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
                Assert.AreEqual(GenderTypes.Unspecified, customer.Gender);
                Assert.IsNull(customer.Address);
                Assert.IsNull(customer.DOB);
                Assert.AreEqual(string.Empty, customer.FirstName);
                Assert.AreEqual(string.Empty, customer.LastName);
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
