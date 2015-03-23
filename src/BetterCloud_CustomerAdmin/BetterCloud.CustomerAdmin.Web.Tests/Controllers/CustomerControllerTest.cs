using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.XPath;
using BetterCloud.CustomerAdmin.Common;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;
using BetterCloud.CustomerAdmin.Web.Controllers;
using BetterCloud.CustomerAdmin.Web.Tests.Mocks;
using Geocoding;
using Geocoding.Google;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterCloud.CustomerAdmin.Web.Tests.Controllers
{

    [TestClass]
    public class CustomerControllerTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Kernel.Instance.Bind<ICustomerBusiness, CustomerBusinessMock>();
            Kernel.Instance.Bind<IGeocoder, GoogleGeocoder>();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is List<CustomerDO>);
        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is CustomerDO);
        }

        [TestMethod]
        public void Create_Action()
        {
            // Arrange
            CustomerController controller = new CustomerController();

            // Act
            ViewResult result = controller.Create(new FormCollection()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Detail()
        {
            // Arrange
            CustomerController controller = new CustomerController();
            var mockCust = MockData.GetEditCustomerDO();

            // Act
            ViewResult result = controller.Details(mockCust.CustomerId.ToString()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is CustomerDO);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            CustomerController controller = new CustomerController();
            var mockCust = MockData.GetEditCustomerDO();

            // Act
            ViewResult result = controller.Edit(mockCust.CustomerId.ToString()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is CustomerDO);
        }

        [TestMethod]
        public void Edit_Action()
        {
            // Arrange
            CustomerController controller = new CustomerController();
            var mockCust = MockData.GetEditCustomerDO();

            // Act
            ActionResult result = controller.Edit(mockCust.CustomerId.ToString(), new FormCollection());

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            CustomerController controller = new CustomerController();
            var mockCust = MockData.GetEditCustomerDO();

            // Act
            ViewResult result = controller.Delete(mockCust.CustomerId.ToString()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is CustomerDO);
        }

        [TestMethod]
        public void Delete_Action()
        {
            // Arrange
            CustomerController controller = new CustomerController();
            var mockCust = MockData.GetEditCustomerDO();

            // Act
            ActionResult result = controller.Delete(mockCust.CustomerId.ToString(), new FormCollection());

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
