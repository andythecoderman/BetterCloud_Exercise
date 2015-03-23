﻿using System;
using BetterCloud.CustomerAdmin.Business.Test.Mocks;
using BetterCloud.CustomerAdmin.Common;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterCloud.CustomerAdmin.Business.Test
{
    [TestClass]
    public class CustomerBusinessTest 
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Kernel.Instance.Bind<ICustomerBusiness, CustomerBusiness>();
            Kernel.Instance.Bind<ICustomerData, MockIDataAccess>();
        }


        [TestMethod]
        public void GetAllCustomers()
        {
            try
            {
                var cuBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();
                var customerList = cuBiz.GetAllCustomers();
                Assert.IsNotNull(customerList);
                Assert.IsTrue(customerList.Count > 0);
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
        public void GetCustomer()
        {
            try
            {
                var cuBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();
                var custId = new Guid();
                var custDO = cuBiz.GetCustomer(custId);
                Assert.IsNotNull(custDO);
                Assert.AreEqual(custId, custDO.CustomerId);
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
        public void CreateCustomer()
        {
            try
            {
                var cuBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();
                var custDO = new CustomerDO();
                var custId = cuBiz.CreateCustomer(custDO);
                Assert.IsNotNull(custId);
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
        public void UpdateCustomer()
        {
            try
            {
                var cuBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();
                var custDO = new CustomerDO();
                cuBiz.UpdateCustomer(custDO);
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
        public void DeleteCustomer()
        {
            try
            {
                var cuBiz = Kernel.Instance.GetInstance<ICustomerBusiness>();
                cuBiz.DeleteCustomer(new Guid());
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
