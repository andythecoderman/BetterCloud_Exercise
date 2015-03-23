﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;

namespace BetterCloud.CustomerAdmin.DataAccess.MSSQL
{
    public class CustomerDAO : ICustomerData
    {
        #region Column Definitions

        private const string CustomerDbConnection = "CustomerDBConnection";
        private const string SpCustomerGetAll = "spCustomerGetAll";
        private const string SpCustomerGetByCustomerId = "spCustomerGetByCustomerId";
        private const string SpCustomerCreate = "spCustomerCreate";
        private const string SpCustomerUpdate = "spCustomerUpdate";
        private const string SpCustomerDelete = "spCustomerDelete";
        private const string ColCustomerId = "CustomerId";
        private const string ColDOB = "DOB";
        private const string ColEmail = "Email";
        private const string ColFirstName = "FirstName";
        private const string ColGender = "Gender";
        private const string ColLastName = "LastName";
        private const string ColPhone = "Phone";
        private const string ColCity = "City";
        private const string ColCountry = "Country";
        private const string ColLatitude = "Latitude";
        private const string ColLongitude = "Longitude";
        private const string ColPostalCode = "PostalCode";
        private const string ColState = "State";
        private const string ColStreet = "Street";
        private const string ColSuite = "Suite";
        private const string ColAddressId = "AddressId";

        #endregion

        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings[CustomerDbConnection].ConnectionString;


        public List<CustomerDO> GetAllCustomers()
        {
            var customers = new List<CustomerDO>();
            
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(SpCustomerGetAll, conn) {CommandType = CommandType.StoredProcedure};
                conn.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(BuildCustomer(reader));   
                }
                reader.Close();
            }
            return customers;
        }

        public CustomerDO GetCustomer(Guid customerId)
        {
            CustomerDO customer = null;
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(SpCustomerGetByCustomerId, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@" + ColCustomerId, customerId);

                conn.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //- Should be only one
                    customer = BuildCustomer(reader);
                    break;
                }
                reader.Close();
            }
            return customer;
        }

        public Guid CreateCustomer(CustomerDO customerDO)
        {
            Guid newCustId;
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    var command = new SqlCommand(SpCustomerCreate, conn)
                           {
                               CommandType = CommandType.StoredProcedure

                           };
                    var outParam = BuildCustomerParams(customerDO, command, true);
                    conn.Open();
                    command.ExecuteNonQuery();
                    newCustId = (Guid)outParam.Value;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    throw;
                }
            }
            return newCustId;
        }

        public bool UpdateCustomer(CustomerDO customerDO)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(SpCustomerUpdate, conn) {CommandType = CommandType.StoredProcedure};
                BuildCustomerParams(customerDO, command);
                conn.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        

        public bool DeleteCustomer(Guid customerId)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(SpCustomerDelete, conn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 10
                };
                command.Parameters.Add(new SqlParameter(ColCustomerId, customerId));
                conn.Open();
                command.ExecuteNonQuery();
            }
            return true; 
        }

        public void Dispose()
        {
            //- Nothing to clean up
        }

        private static SqlParameter BuildCustomerParams(CustomerDO customerDO, SqlCommand command, bool isCreate = false)
        {
            SqlParameter custIdParam = null; 
            if (isCreate)
            {
                //- Set to recive new Guid on create
                custIdParam = new SqlParameter(ColCustomerId, SqlDbType.UniqueIdentifier);
                custIdParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(custIdParam);
           }
            else
            {
                command.Parameters.AddWithValue("@" + ColCustomerId, customerDO.CustomerId ?? (object)DBNull.Value);
            }

            if (customerDO.Address == null) customerDO.Address = new AddressDO();
            command.Parameters.AddWithValue("@" + ColEmail, customerDO.Email ?? (object) DBNull.Value);
            command.Parameters.AddWithValue("@" + ColPhone, customerDO.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColFirstName, customerDO.FirstName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColLastName, customerDO.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColDOB, customerDO.DOB ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColGender, customerDO.Gender ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColStreet, customerDO.Address.Street ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColCity, customerDO.Address.City ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColState, customerDO.Address.State ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColPostalCode, customerDO.Address.PostalCode ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColCountry, customerDO.Address.Country ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@" + ColSuite, customerDO.Address.Suite ?? (object) DBNull.Value);
            command.Parameters.AddWithValue("@" + ColLatitude, customerDO.Address.Latitude ?? (object) DBNull.Value);
            command.Parameters.AddWithValue("@" + ColLongitude, customerDO.Address.Longitude ?? (object) DBNull.Value);
            

            return custIdParam;
        }

        private CustomerDO BuildCustomer(SqlDataReader reader)
        {
            var custDO = new CustomerDO
            {
                CustomerId = ParseValue<Guid?>(reader, ColCustomerId),
                DOB = ParseValue<DateTime?>(reader, ColDOB),
                Email = ParseValue<string>(reader, ColEmail),
                FirstName = ParseValue<string>(reader, ColFirstName),
                LastName = ParseValue<string>(reader, ColLastName),
                Phone = ParseValue<string>(reader, ColPhone)
            };

            //- Add Address if avaliable
            var addrId = ParseValue<int?>(reader, ColAddressId);
            if (addrId != null)
            {
                custDO.Address = new AddressDO
                {
                    City = ParseValue<string>(reader, ColCity),
                    Country = ParseValue<string>(reader, ColCountry),
                    Latitude = ParseValue<double?>(reader, ColLatitude),
                    Longitude = ParseValue<double?>(reader, ColLongitude),
                    PostalCode = ParseValue<string>(reader, ColPostalCode),
                    State = ParseValue<string>(reader, ColState),
                    Street = ParseValue<string>(reader, ColStreet),
                    Suite = ParseValue<string>(reader, ColSuite)
                };
            }
            return custDO;
        }

        public T ParseValue<T>(SqlDataReader reader, string column)
        {
            var result = default(T);

            if (!reader.IsDBNull(reader.GetOrdinal(column)))
                result = (T)reader.GetValue(reader.GetOrdinal(column));

            return result;
        }
    }
}