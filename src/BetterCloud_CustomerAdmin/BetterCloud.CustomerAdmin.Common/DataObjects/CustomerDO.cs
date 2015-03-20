using System;

namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    /// <summary>
    /// POCO for containing customer information
    /// </summary>
    public class CustomerDO : DataObject
    {
        private string _gender = GenderTypes.Unspecified;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressDO Address { get; set; }

        public DateTime? DOB { get; set; }

        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = GenderTypes.GetGenderType(value);
            }
        }
    }
}
