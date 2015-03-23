using System;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterCloud.CustomerAdmin.DataAccess.MSSQL.Tests
{
    [TestClass]
    public class DAOTest
    {
        [TestMethod]
        public void CreateCustomer()
        {
            CustomerDAO dao = new CustomerDAO();
            CustomerDO custDO = new CustomerDO();
            dao.CreateCustomer(custDO);
        }
    }
}
