namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    /// <summary>
    /// Address information 
    /// </summary>
    public class AddressDO : DataObject
    {
        private double? _latitude = null;
        private double? _longitude = null;
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Suite { get; set; }

        public double? Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public double? Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
    }
}
