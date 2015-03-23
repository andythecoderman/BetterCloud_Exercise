using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding;

namespace BetterCloud.CustomerAdmin.Web.Tests.Mocks
{
    public class GeocodingMock : IGeocoder
    {
        public IEnumerable<Address> Geocode(string address)
        {
            return new List<Address>();
        }

        public IEnumerable<Address> Geocode(string street, string city, string state, string postalCode, string country)
        {
            return new List<Address>();

        }

        public IEnumerable<Address> ReverseGeocode(Location location)
        {
            return new List<Address>();

        }

        public IEnumerable<Address> ReverseGeocode(double latitude, double longitude)
        {
            return new List<Address>();

        }
    }
}
