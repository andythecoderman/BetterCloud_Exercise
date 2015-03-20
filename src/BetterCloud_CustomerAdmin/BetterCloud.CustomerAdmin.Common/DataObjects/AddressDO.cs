namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    /// <summary>
    /// Address information 
    /// </summary>
    public class AddressDO : DataObject
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Suite { get; set; }
    }
}
