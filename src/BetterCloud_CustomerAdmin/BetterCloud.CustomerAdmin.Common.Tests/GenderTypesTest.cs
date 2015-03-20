using System;
using BetterCloud.CustomerAdmin.Common.DataObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterCloud.CustomerAdmin.Common.Tests
{
    [TestClass]
    public class GenderTypesTest
    {
        [TestMethod]
        public void GenderType_GetGenderType_Male()
        {
            try
            {
                var gender = GenderTypes.GetGenderType("m");
                Assert.AreEqual(GenderTypes.Male, gender);

                gender = GenderTypes.GetGenderType("M");
                Assert.AreEqual(GenderTypes.Male, gender);

                gender = GenderTypes.GetGenderType("male");
                Assert.AreEqual(GenderTypes.Male, gender);

                gender = GenderTypes.GetGenderType("Male");
                Assert.AreEqual(GenderTypes.Male, gender);

            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GenderType_GetGenderType_Female()
        {
            try
            {
                var gender = GenderTypes.GetGenderType("f");
                Assert.AreEqual(GenderTypes.Female, gender);

                gender = GenderTypes.GetGenderType("F");
                Assert.AreEqual(GenderTypes.Female, gender);

                gender = GenderTypes.GetGenderType("female");
                Assert.AreEqual(GenderTypes.Female, gender);

                gender = GenderTypes.GetGenderType("Female");
                Assert.AreEqual(GenderTypes.Female, gender);

            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GenderType_GetGenderType_Unspecified()
        {
            try
            {
                var gender = GenderTypes.GetGenderType("");
                Assert.AreEqual(GenderTypes.Unspecified, gender);

                gender = GenderTypes.GetGenderType("unspecified");
                Assert.AreEqual(GenderTypes.Unspecified, gender);

                gender = GenderTypes.GetGenderType("Unspecified");
                Assert.AreEqual(GenderTypes.Unspecified, gender);
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GenderType_GetGenderType_Invalid()
        {
            const string invalidinput = "InvalidInput";
            bool wasThrown = false;
            try
            {
                try
                {
                    GenderTypes.GetGenderType(invalidinput);
                }
                catch (ArgumentException argEx)
                {
                    wasThrown = true;
                    const string msgFormat = "Gender Value {0} is not a property of {1}\r\nParameter name: value";
                    Assert.AreEqual(string.Format(msgFormat, invalidinput, typeof (GenderTypes).FullName), argEx.Message);

                    Assert.AreEqual("value", argEx.ParamName);
                }
                finally
                {
                    Assert.IsTrue(wasThrown, "GenderTypes.GetGenderType did not throw ArgumentException as expected");
                }
            }
            catch (AssertFailedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
