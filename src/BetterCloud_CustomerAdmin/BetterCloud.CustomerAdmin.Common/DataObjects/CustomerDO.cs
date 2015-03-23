using System;
using System.ComponentModel.DataAnnotations;

namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    /// <summary>
    /// POCO for containing customer information
    /// </summary>
    public class CustomerDO : DataObject
    {
        private string _gender = GenderTypes.Unspecified;
        private AddressDO _address = new AddressDO();

        /// <summary>
        /// Look up ID used for exact match searches. Portable across systems
        /// </summary>
        public Guid? CustomerId { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public AddressDO Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
