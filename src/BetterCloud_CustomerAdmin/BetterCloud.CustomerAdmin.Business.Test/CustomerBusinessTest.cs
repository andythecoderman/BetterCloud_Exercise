using System;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;
using BetterCloud.CustomerAdmin.DataAccess.MSSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace BetterCloud.CustomerAdmin.Business.Test
{
    [TestClass]
    public class CustomerBusinessTest
    {
        private readonly IKernel _diKernel = new StandardKernel();

        [TestInitialize]
        public void Init()
        {
            _diKernel.Bind<ICustomerBusiness>().To<CustomerBusiness>();
            _diKernel.Bind<ICustomerData>().To<CustomerDAO>();
        }

        public void GetCustomer_Existing()
        {
            try
            {
                var cuBiz = _diKernel.Get<ICustomerBusiness>();
                var custDO = cuBiz.GetCustomer(Guid.Parse("844CB884-43C8-4B59-90CA-F07A3310095E")); //TODO: Mock Data
                Assert.IsNotNull(custDO);
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
