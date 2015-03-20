using System;

namespace BetterCloud.CustomerAdmin.Common.DataObjects
{
    public static class GenderTypes
    {
        public const string Male = "M";

        public const string Female = "F";

        public const string Unspecified = "";

        private const string InvalidGenderString = "Gender Value {0} is not a property of {1}";

        public static string GetGenderType(string value)
        {
            //- Gives some fault tolerance when proper value is not used. 
            var val = value.ToUpper();
            switch (val)
            {
                case Male:
                case Female:
                case Unspecified:
                    return val;
                case "MALE":
                    return Male;
                case "FEMALE":
                    return Female;
                case "UNSPECIFIED":
                    return Unspecified;
                default:
                    throw new ArgumentException(string.Format(InvalidGenderString, value, typeof(GenderTypes).FullName), "value");
            }
        }
    }
}
