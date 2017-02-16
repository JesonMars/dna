using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DNACreatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dnaSerialStr =
                "[{\"Key\":\"TPOX\",\"Value\":\"2\"},{\"Key\":\"CSF1PO\",\"Value\":\"5\"},{\"Key\":\"PENTAD\",\"Value\":\"21\"},{\"Key\":\"VWA\",\"Value\":\"12\"},{\"Key\":\"TH01\",\"Value\":\"11\"},{\"Key\":\"FGA\",\"Value\":\"4\"},{\"Key\":\"PENTAE\",\"Value\":\"15\"},{\"Key\":\"AMEL\",\"Value\":\"sex\"},{\"Key\":\"Yindel\",\"Value\":\"Y\"},{\"Key\":\"DYS391\",\"Value\":\"Y\"},{\"Key\":\"SE33\",\"Value\":\"6\"},{\"Key\":\"YGATAH4\",\"Value\":\"Y\"}]";
            
            var jsonHelper = new JsonHelper();

            var dnaSerial = new Dictionary<string, string>();
            dnaSerial = jsonHelper.JsonDeserialize<Dictionary<string, string>>(dnaSerialStr);            
            Assert.IsNotNull(dnaSerial);
        }
        [TestMethod]
        public void Test1()
        {
            var dnaSerialStr = "['12','13','15']";
            var ne = Regex.Matches(dnaSerialStr, "[0-9,]*").Cast<Match>();
            var str = "";
            foreach (var match in ne.ToList())
            {
                str += match.Value;
            }
            
            Assert.IsNotNull(ne);
        }
    }
}
