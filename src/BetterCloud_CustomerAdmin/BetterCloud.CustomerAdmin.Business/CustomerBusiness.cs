using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BetterCloud.CustomerAdmin.Common;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;
using Geocoding;
using Geocoding.Google;

namespace BetterCloud.CustomerAdmin.Business
{
    /// <summary>
    /// Implementation of standard business class that handles consumer data via the DataAccess interfaces 
    /// </summary>
    public class CustomerBusiness : ICustomerBusiness
    {
        #region Fields
        private readonly ICustomerData _customerDAO = Kernel.Instance.GetInstance<ICustomerData>();
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const string MethodLogFormat = "{0} Called"; 
        #endregion

        #region ICustomerBusiness Implementation Methods
        public void Dispose()
        {
            if (_customerDAO != null)
            {
                _customerDAO.Dispose();
            }
        }

        public List<CustomerDO> GetAllCustomers()
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                var allCustomers = _customerDAO.GetAllCustomers();

                Log.Debug(allCustomers);
                return allCustomers;
            }
            catch (Exception ex)
            {
                var newEx = new Exception("Could not Load Customers", ex);
                Log.Error(newEx);
                throw newEx;
            }
        }

        public CustomerDO GetCustomer(Guid customerId)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                var customerDO = _customerDAO.GetCustomer(customerId);
                Log.Debug(customerDO);
                return customerDO;
            }
            catch (Exception ex)
            {
                var newEx = new Exception("Could not Load Customer", ex);
                Log.Error(newEx);
                throw newEx;
            }
        }

        public Guid CreateCustomer(CustomerDO customerDO)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                SetCoordinates(customerDO);

                var customerId = _customerDAO.CreateCustomer(customerDO);
                Log.Debug(customerId);

                return customerId;
            }
            catch (Exception ex)
            {
                var newEx = new Exception("Could not Create Customer", ex);
                Log.Error(newEx);
                throw newEx;
            }
        }

        public void UpdateCustomer(CustomerDO customerDO)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                SetCoordinates(customerDO);
                _customerDAO.UpdateCustomer(customerDO);
            }
            catch (Exception ex)
            {
                var newEx = new Exception("Could not Update Customer", ex);
                Log.Error(newEx);
                throw newEx;
            }
        }

        public void DeleteCustomer(Guid customerId)
        {
            try
            {
                Log.Info(string.Format(MethodLogFormat, MethodBase.GetCurrentMethod().Name));

                _customerDAO.DeleteCustomer(customerId);
            }
            catch (Exception ex)
            {
                var newEx = new Exception("Could not Delete Customer", ex);
                Log.Error(newEx);
                throw newEx;
            }
        } 

        #endregion

        #region Helper Methods
        private static void SetCoordinates(CustomerDO customerDO)
        {
            try
            {
                var geocoder = Kernel.Instance.GetInstance<IGeocoder>();
                var address = geocoder.Geocode(
                    customerDO.Address.Street,
                    customerDO.Address.City,
                    customerDO.Address.State,
                    customerDO.Address.PostalCode,
                    customerDO.Address.Country
                    ).FirstOrDefault();

                if (address != null)
                {
                    customerDO.Address.Latitude = address.Coordinates.Latitude;
                    customerDO.Address.Longitude = address.Coordinates.Longitude;
                }
            }
            catch (Exception ex)
            {
                //- Swallow and log this exception to prevent external API failure from breaking main app
                Log.Error(ex);
            }
        } 
        #endregion
    }
}
