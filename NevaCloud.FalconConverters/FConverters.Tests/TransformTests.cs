using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NevaCloud.FalconConverters;

namespace FConverters.Tests
{
    [TestClass]
    public class TransformTests
    {
        [TestMethod]
        public void StringToUrlTest()
        {
            string s = "Autohaus Markoetter - Bielefeld - Händler-Informationen";

            s = Transform.StringToUrl(s);


            Assert.IsTrue(s.Equals("Autohaus-Markoetter-Bielefeld-Händler-Informationen"));
        }
    }
}
