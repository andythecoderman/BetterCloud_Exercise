using System;
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

        public Guid? CreateCustomer(CustomerDO customerDO)
        {
            Guid? newCustId;
            using (var conn = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(SpCustomerCreate, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                var outParam = BuildCustomerParams(customerDO, command, true);
                conn.Open();
                command.ExecuteNonQuery();
                newCustId = outParam.Value is Guid ? new Guid?((Guid) outParam.Value) : null;
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
                    CommandType = CommandType.StoredProcedure
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
            var custIdParam = new SqlParameter(ColCustomerId, customerDO.CustomerId);
            if (isCreate)
            {
                //- Set to recive new Guid on create
                custIdParam.Direction = ParameterDirection.InputOutput;
            }
            command.Parameters.Add(custIdParam);
            command.Parameters.Add(new SqlParameter(ColDOB, customerDO.DOB));
            command.Parameters.Add(new SqlParameter(ColEmail, customerDO.Email));
            command.Parameters.Add(new SqlParameter(ColFirstName, customerDO.FirstName));
            command.Parameters.Add(new SqlParameter(ColGender, customerDO.Gender));
            command.Parameters.Add(new SqlParameter(ColLastName, customerDO.LastName));
            command.Parameters.Add(new SqlParameter(ColPhone, customerDO.Phone));

            if (customerDO.Address == null) return custIdParam;

            command.Parameters.Add(new SqlParameter(ColCity, customerDO.Address.City));
            command.Parameters.Add(new SqlParameter(ColCountry, customerDO.Address.Country));
            command.Parameters.Add(new SqlParameter(ColLatitude, customerDO.Address.Latitude));
            command.Parameters.Add(new SqlParameter(ColLongitude, customerDO.Address.Longitude));
            command.Parameters.Add(new SqlParameter(ColPostalCode, customerDO.Address.PostalCode));
            command.Parameters.Add(new SqlParameter(ColState, customerDO.Address.State));
            command.Parameters.Add(new SqlParameter(ColStreet, customerDO.Address.Street));
            command.Parameters.Add(new SqlParameter(ColSuite, customerDO.Address.Suite));

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
                    Latitude = ParseValue<double>(reader, ColLatitude),
                    Longitude = ParseValue<double>(reader, ColLongitude),
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